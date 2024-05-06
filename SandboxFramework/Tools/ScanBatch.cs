using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using CsvHelper;
using CsvHelper.Configuration;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Messages;
using Microsoft.Xrm.Sdk.Metadata;

namespace SandboxFramework.Tools
{
    public static class ScanBatch
    {
        private static IOrganizationService OrganizationService => Tools.OrganizationService.GetOrganizationServiceInTest();

        public static void ScanBatchJob(string entityLogicalName)
        {
            var request = new RetrieveEntityRequest
            {
                EntityFilters = EntityFilters.Attributes,
                LogicalName = entityLogicalName
            };

            var response = (RetrieveEntityResponse)OrganizationService.Execute(request);
            var fieldsFromFile = ScanBatchText();

            var batchFieldList = new List<BatchContainer>();

            var count = 0;

            foreach (var attr in response.EntityMetadata.Attributes)
            {
                var customAttributesFromBatchFile = attr.IsCustomAttribute.GetValueOrDefault() && fieldsFromFile.Contains(attr.LogicalName);

                if (!customAttributesFromBatchFile)
                {
                    continue;
                }

                var label = attr.DisplayName;
                var attributeType = attr.AttributeType.ToString();

                var displayName = label.UserLocalizedLabel.Label;
                displayName = displayName.Replace("-", "");
                displayName = displayName.Replace(" ", "");
                var displayNameSplit = displayName.Split(' ');
                
                for (var i = 0; i < displayNameSplit.Length; i++)
                {
                    var letters = displayNameSplit[i].ToCharArray();
                    letters[0] = char.ToUpper(letters[0]);
                    displayNameSplit[i] = new string(letters);
                }

                var displayNameJoined = string.Join(" ", displayNameSplit);
                var replacePattern = @"[^a-zA-Z0-9]";
                displayNameJoined = Regex.Replace(displayNameJoined, replacePattern, "");

                var batchContainer = new BatchContainer
                {
                    DisplayName = displayNameJoined,
                    FieldName = attr.LogicalName,
                    DataType = DataTypeConverter(attributeType)
                };

                batchFieldList.Add(batchContainer);

                count++;
            }
            
            Console.WriteLine();
            
            batchFieldList = batchFieldList.OrderBy(x => x.DisplayName).ToList();

            foreach (var field in batchFieldList)
            {
                Console.WriteLine($"public const string Field{field.DisplayName} = \"{field.FieldName}\";");
            }

            Console.WriteLine();

            foreach (var field in batchFieldList)
            {
                Console.WriteLine
                (
                    $"[AttributeLogicalName(Field{field.DisplayName})] \n" +
                    $"public {field.DataType} {field.DisplayName} \n" +
                    $"{{ \n" +
                    $"    get => Get<{field.DataType}>(); \n" +
                    $"    set => Set(value);" +
                    $"\n}}"
                );

                Console.WriteLine();
            }

            Console.WriteLine();

            foreach (var field in batchFieldList)
            {
                Console.WriteLine($"Map(x => x.{field.DisplayName}).Name(\"COLUMNNAME\"){TypeConverterGenerator(field.DataType)};");
            }
        }

        private static List<string> ScanBatchText()
        {
            var fullPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "batchtext.txt");
            var fileContents = File.ReadAllText(fullPath);
            var batchFields = new HashSet<string>();

            var matchCounts = new Dictionary<string, int>();
            var regex = new Regex(@"\bnew_\w*", RegexOptions.Compiled);
            var matchLines = new Dictionary<string, string>();
            var proposedFields = new List<string>();

            using (var reader = new StringReader(fileContents))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    var matches = regex.Matches(line);
                    foreach (Match match in matches)
                    {
                        if (match.Value.Contains("_base") || UnnecessaryFields.Contains(match.Value))
                        {
                            continue;
                        }

                        if (matchCounts.ContainsKey(match.Value))
                        {
                            matchCounts[match.Value]++;
                        }
                        else
                        {
                            matchCounts[match.Value] = 1;
                            matchLines[match.Value] = line;
                        }
                    }
                }
            }

            foreach (var match in matchCounts)
            {
                if (match.Value > 1)
                {
                    batchFields.Add(match.Key);
                    continue;
                }

                if (matchLines[match.Key].Contains("<attribute name="))
                {
                    continue;
                }

                var message = $"'{match.Key}' is unique. Found in line: '{matchLines[match.Key].Trim()}'";

                if (matchLines[match.Key].ToLower().Contains("lookup"))
                {
                    var rx = new Regex(@"Row.\w*", RegexOptions.Compiled | RegexOptions.IgnoreCase);

                    var matches = rx.Matches(matchLines[match.Key]);
                    
                    proposedFields.AddRange
                    (
                        from Match rowMatch in matches
                        select rowMatch.Value.Substring(4)
                        into restOfWord
                        select $"BatchRelatedField{restOfWord}"
                    );
                }

                Console.WriteLine(message);
            }

            Console.WriteLine();

            foreach (var field in proposedFields)
            {
                var letters = field.ToLower().ToCharArray();
                letters[1] = char.ToUpper(letters[1]);
                var fieldResized = new string(letters);
                
                Console.WriteLine("public string " + fieldResized + " { get; set; }");
            }

            return batchFields.ToList();
        }

        private static readonly string[] UnnecessaryFields =
        {
            "new_batchid",
            "new_identifier",
            "new_data",
            "new_sourcefrom",
            "new_uniqueid",
            "new_processaction",
            "new_errortext",
            "statuscode",
            "new_action",

            // Entity names
            "new_batchcountsummary",
            "new_dailyjob"
        };

        public static string DataTypeConverter(string attributeType)
        {
            switch (attributeType)
            {
                case "Boolean":
                    return "bool?";
                case "DateTime":
                    return "DateTime?";
                case "Money":
                    return "Money";
                case "Memo":
                    return "string";
                case "String":
                    return "string";
                case "Double":
                    return "double?";
                case "Integer":
                    return "int?";
                case "Picklist":
                    return "OptionSetValue";
                case "Lookup":
                    return "EntityReference";
                case "Customer":
                    return "EntityReference";
                default:
                    return "string";
            }
        }

        private static string TypeConverterGenerator(string dataType)
        {
            switch (dataType)
            {
                case "bool":
                    return ".TypeConverter<BooleanTypeConverter>()";
                case "DateTime":
                    return ".TypeConverter<DateTimeTypeConverter>()";
                case "Money":
                    return ".TypeConverter<BatchJobDataHandlers.MoneyConverter>()";
                case "double":
                    return ".TypeConverter<BatchJobDataHandlers.DoubleConverter>()";
                case "OptionSetValue":
                    return ".TypeConverter<OptionSetValueTypeConverter>()";
                case "EntityReference":
                    return "; //- Entity Reference - Map to Batch Related Field -";
                case "int":
                    return ".TypeConverter<BatchJobDataHandlers.IntegerConverter>()";
                
                default:
                    return null;
            }
        }

        public class BatchContainer
        {
            public string DisplayName { get; set; }
            public string FieldName { get; set; }
            public string DataType { get; set; }
        }

        public static void GetColumnsWithoutEmptyValues(string csvFilePath)
        {
            Console.WriteLine();
            Console.WriteLine("Columns without empty values:");
            var dt = new DataTable();

            var csvConfiguration = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                Delimiter = ";",
                HasHeaderRecord = true,
                MissingFieldFound = null,
                BadDataFound = null
            };

            using (var reader = new StreamReader(csvFilePath))
            using (var csv = new CsvReader(reader, csvConfiguration))
            {
                using (var dr = new CsvDataReader(csv))
                {
                    dt.Load(dr);
                }
            }

            var columnsWithoutEmptyValues =
            (
                from DataColumn column in dt.Columns
                where dt.AsEnumerable().All(row => !row.IsNull(column) && !string.IsNullOrWhiteSpace(row[column].ToString()))
                select column.ColumnName
            ).ToList();

            columnsWithoutEmptyValues.ForEach(x => { Console.Write(x + ";"); });
            Console.WriteLine();
        }
        
        public static void GetColumnsWithEmptyValues(string csvFilePath)
        {
            Console.WriteLine();
            Console.WriteLine("Columns with empty values:");
            var dt = new DataTable();

            var csvConfiguration = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                Delimiter = ";",
                HasHeaderRecord = true,
                MissingFieldFound = null,
                BadDataFound = null
            };

            using (var reader = new StreamReader(csvFilePath))
            using (var csv = new CsvReader(reader, csvConfiguration))
            {
                using (var dr = new CsvDataReader(csv))
                {
                    dt.Load(dr);
                }
            }

            var columnsWithEmptyValues =
            (
                from DataColumn column in dt.Columns
                where dt.AsEnumerable().Any(row => row.IsNull(column) || string.IsNullOrWhiteSpace(row[column].ToString()))
                select column.ColumnName
            ).ToList();

            columnsWithEmptyValues.ForEach(x => { Console.Write(x + ";"); });
            Console.WriteLine();
        }
    }
}