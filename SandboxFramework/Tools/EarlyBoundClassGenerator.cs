using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Messages;
using Microsoft.Xrm.Sdk.Metadata;

namespace SandboxFramework.Tools
{
    public class EarlyBoundClassGenerator
    {
        private static IOrganizationService OrganizationService => Tools.OrganizationService.GetOrganizationServiceInTest();

        public void Starter()
        {
            GenerateEarlyBoundClasses("new_dailyjob", "DailyJobEntity");
        }

        private static void GenerateEarlyBoundClasses(string entityLogicalName, string className)
        {
            var fileStringBuilder = new StringBuilder();
            SetupClassNameAndConstructor(className, entityLogicalName, fileStringBuilder);

            var attributes = RetrieveAttributes(entityLogicalName);

            var userLocalizedLabels = RetrieveCustomAttributesLabelsToDictionary(attributes);
            GenerateFields(userLocalizedLabels, fileStringBuilder);

            fileStringBuilder.AppendLine();
            
            var userLocalizedAttributesWithTypes = RetrieveCustomAttributesToDictionary(attributes);
            GenerateProperties(userLocalizedAttributesWithTypes, userLocalizedLabels, fileStringBuilder);
            
            fileStringBuilder.AppendLine("}");
            fileStringBuilder.AppendLine("}");
            
            WriteToFile(className, fileStringBuilder.ToString());
            
            AddFileToProject(className);
        }

        private static void SetupClassNameAndConstructor(string className, string entityLogicalName, StringBuilder fileStringBuilder)
        {
            fileStringBuilder.AppendLine("using System.Reflection;");
            fileStringBuilder.AppendLine("using Microsoft.Xrm.Sdk;");
            fileStringBuilder.AppendLine("using Microsoft.Xrm.Sdk.Client;");
            fileStringBuilder.AppendLine("using DTL.Entities;");
            fileStringBuilder.AppendLine();
            fileStringBuilder.AppendLine("namespace REPLACETHIS");
            fileStringBuilder.AppendLine("{");
            fileStringBuilder.AppendLine("[EntityLogicalName(EntityLogicalName)]");
            fileStringBuilder.AppendLine($"public class {className} : BaseEntity");
            fileStringBuilder.AppendLine("{");
            fileStringBuilder.AppendLine($"public {className}()");
            fileStringBuilder.AppendLine("{");
            fileStringBuilder.AppendLine($"LogicalName = typeof({className}).GetCustomAttribute<EntityLogicalNameAttribute>().LogicalName;");
            fileStringBuilder.AppendLine("}");
            fileStringBuilder.AppendLine();
            fileStringBuilder.AppendLine($"public const string EntityLogicalName = {entityLogicalName};");
        }

        private static List<AttributeMetadata> RetrieveAttributes(string entityLogicalName)
        {
            var retrieveEntityRequest = new RetrieveEntityRequest
            {
                EntityFilters = EntityFilters.Attributes,
                LogicalName = entityLogicalName
            };

            var retrieveEntityResponse = (RetrieveEntityResponse)OrganizationService.Execute(retrieveEntityRequest);

            return retrieveEntityResponse.EntityMetadata.Attributes.ToList();
        }

        private static Dictionary<string, string> RetrieveCustomAttributesLabelsToDictionary(IEnumerable<AttributeMetadata> attributes)
        {
            var userLocalizedLabels = attributes
                .Where(attribute => attribute.LogicalName.Contains("new_"))
                .Where(attribute => attribute.DisplayName != null)
                .Where(attribute => attribute.DisplayName.UserLocalizedLabel != null)
                .ToDictionary(
                    attribute => $"Field{attribute.DisplayName.UserLocalizedLabel.Label.Replace(" ", string.Empty)}",
                    attribute => attribute.LogicalName
                );
            
            return userLocalizedLabels;
        }

        private static void GenerateFields(Dictionary<string, string> userLocalizedLabels, StringBuilder fileStringBuilder)
        {
            foreach (var label in userLocalizedLabels)
            {
                fileStringBuilder.AppendLine($"public const string {label.Key} = \"{label.Value}\";");
            }
        }

        private static Dictionary<string, string> RetrieveCustomAttributesToDictionary(IEnumerable<AttributeMetadata> attributes)
        {
            var filteredAttributes = attributes.Where(attribute => attribute.LogicalName.Contains("new_")).ToList();
            var userLocalizedAttributes = new Dictionary<string, string>(filteredAttributes.Count);

            foreach (var attribute in filteredAttributes)
            {
                string attributeType;

                switch (attribute.AttributeType)
                {
                    case AttributeTypeCode.String:
                        attributeType = "string";
                        break;
                    case AttributeTypeCode.Integer:
                        attributeType = "int?";
                        break;
                    case AttributeTypeCode.Double:
                        attributeType = "double?";
                        break;
                    case AttributeTypeCode.Decimal:
                        attributeType = "decimal?";
                        break;
                    case AttributeTypeCode.Money:
                        attributeType = "Money";
                        break;
                    case AttributeTypeCode.DateTime:
                        attributeType = "DateTime?";
                        break;
                    case AttributeTypeCode.Boolean:
                        attributeType = "bool?";
                        break;
                    case AttributeTypeCode.Lookup:
                        attributeType = "EntityReference";
                        break;
                    case AttributeTypeCode.Picklist:
                        attributeType = "OptionSetValue";
                        break;
                    case AttributeTypeCode.Memo:
                        attributeType = "string";
                        break;
                    case AttributeTypeCode.Uniqueidentifier:
                        attributeType = "Guid";
                        continue;
                        break;
                    case AttributeTypeCode.Customer:
                        attributeType = "EntityReference";
                        break;
                    case AttributeTypeCode.Owner:
                        attributeType = "EntityReference";
                        break;
                    case AttributeTypeCode.State:
                        attributeType = "int?";
                        break;
                    case AttributeTypeCode.Status:
                        attributeType = "int?";
                        break;
                    case AttributeTypeCode.Virtual:
                        attributeType = "string";
                        continue;
                        break;
                    case AttributeTypeCode.BigInt:
                        attributeType = "long?";
                        break;
                    case AttributeTypeCode.ManagedProperty:
                        attributeType = "string";
                        break;
                    case AttributeTypeCode.EntityName:
                        attributeType = "string";
                        break;
                    case AttributeTypeCode.CalendarRules:
                        attributeType = "string";
                        break;
                    case AttributeTypeCode.PartyList:
                        attributeType = "EntityCollection";
                        break;
                    case null:
                        Console.WriteLine("Attribute type is null. {0}", attribute.AttributeType);
                        throw new Exception();
                    default:
                        Console.WriteLine("Unknown attribute type. {0}", attribute.AttributeType);
                        throw new Exception();
                }

                var attributeUserlocalizedLabel = attribute.DisplayName.UserLocalizedLabel.Label.Replace(" ", string.Empty);
                userLocalizedAttributes.Add(attributeUserlocalizedLabel, attributeType);
            }

            return userLocalizedAttributes;
        }

        private static void GenerateProperties(Dictionary<string, string> labelType, Dictionary<string, string> fieldLabels, StringBuilder fileStringBuilder)
        {
            for (var i = 0; i < labelType.Count; i++)
            {
                var labelTypePair = labelType.ElementAt(i);
                var fieldLabel = fieldLabels.Keys.First(label => label.Contains(labelTypePair.Key));
                
                fileStringBuilder.AppendLine($"[AttributeLogicalName({fieldLabel})]");
                fileStringBuilder.AppendLine($"public {labelTypePair.Value} {labelTypePair.Key}");
                fileStringBuilder.AppendLine("{");
                fileStringBuilder.AppendLine($"    get => Get<{labelTypePair.Value}>();");
                fileStringBuilder.AppendLine("    set => Set(value);");
                fileStringBuilder.AppendLine("}");
                fileStringBuilder.AppendLine();
            }
        }
        
        private static void WriteToFile(string filename, string content)
        {
            var directory = new DirectoryInfo(Directory.GetCurrentDirectory());
            var projectDirectory = directory.Parent.Parent;

            var directoryPath = Path.Combine(projectDirectory.FullName, "Entities");
            Directory.CreateDirectory(directoryPath);

            var filePath = Path.Combine(directoryPath, filename + ".cs");
            File.WriteAllText(filePath, content);
        }
        
        private static void AddFileToProject(string filename)
        {
            var projectPath = FindProjectPath();
            
            var process = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "dotnet",
                    Arguments = $"add {projectPath} Entities/{filename}",
                    RedirectStandardOutput = true,
                    UseShellExecute = false,
                    CreateNoWindow = true,
                }
            };

            process.Start();
            process.WaitForExit();
        }
        
        private static string FindProjectPath()
        {
            var directory = new DirectoryInfo(Directory.GetCurrentDirectory());
            var csprojFile = directory.Parent.Parent.GetFiles("*.csproj", SearchOption.AllDirectories).FirstOrDefault();

            return csprojFile?.FullName;
        }
    }
}