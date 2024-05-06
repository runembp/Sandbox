using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Messages;
using Microsoft.Xrm.Sdk.Metadata;

namespace SandboxFramework.Tools
{
    public static class Utility
    {
        private static IOrganizationService OrganizationService => Tools.OrganizationService.GetOrganizationServiceInTest();

        public static void GetFieldsFromEntity(string entityLogicalName)
        {
            var request = new RetrieveEntityRequest
            {
                EntityFilters = EntityFilters.Attributes,
                LogicalName = entityLogicalName
            };

            var response = (RetrieveEntityResponse)OrganizationService.Execute(request);
            var batchFieldList = new List<ScanBatch.BatchContainer>();

            foreach (var attr in response.EntityMetadata.Attributes)
            {
                var customAttributesFromBatchFile = attr.IsCustomAttribute.GetValueOrDefault();

                if (!customAttributesFromBatchFile)
                {
                    continue;
                }

                var label = attr.DisplayName;
                
                if(label.UserLocalizedLabel == null)
                {
                    continue;
                }
                
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
                const string replacePattern = "[^a-zA-Z0-9]";
                displayNameJoined = Regex.Replace(displayNameJoined, replacePattern, "");

                var batchContainer = new ScanBatch.BatchContainer
                {
                    DisplayName = displayNameJoined,
                    FieldName = attr.LogicalName,
                    DataType = DataTypeConverter(attributeType)
                };

                batchFieldList.Add(batchContainer);
            }
            
            batchFieldList = batchFieldList.OrderBy(x => x.DisplayName).ToList();

            foreach (var field in batchFieldList)
            {
                Console.WriteLine($"public const string Field{field.DisplayName} = \"{field.FieldName}\";");
            }
            
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
        }

        private static string DataTypeConverter(string attributeType)
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
    }
}