using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Microsoft.Xrm.Sdk.Messages;
using Microsoft.Xrm.Sdk.Metadata;

namespace SandboxFramework.Tools
{
    public static class FieldCounter
    {
        public static void FieldCounterMethod()
        {
            var organizationService = OrganizationService.GetOrganizationServiceInTest();

            var booleanCount = 0;
            var dateTimeCount = 0;
            var moneyCount = 0;
            var stringCount = 0;
            var doubleCount = 0;
            var integerCount = 0;
            var optionSetCount = 0;
            var entityReferenceCount = 0;
            var decimalCount = 0;
            var entityCount = 0;
            
            var request = new RetrieveAllEntitiesRequest
            {
                EntityFilters = EntityFilters.Attributes
            };

            var response = (RetrieveAllEntitiesResponse)organizationService.Execute(request);
            var batchFieldList = new List<ScanBatch.BatchContainer>();

            foreach (var entity in response.EntityMetadata)
            {
                entityCount++;
                
                var entityLogicalName = entity.LogicalName;
                var requestEntity = new RetrieveEntityRequest
                {
                    EntityFilters = EntityFilters.Attributes,
                    LogicalName = entityLogicalName
                };

                var responseEntity = (RetrieveEntityResponse)organizationService.Execute(requestEntity);

                foreach (var attr in responseEntity.EntityMetadata.Attributes)
                {
                    var customAttributesFromBatchFile = attr.IsCustomAttribute.GetValueOrDefault();

                    if (!customAttributesFromBatchFile)
                    {
                        continue;
                    }

                    var label = attr.DisplayName;

                    if (label.UserLocalizedLabel == null)
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
                        DataType = Utility.DataTypeConverter(attributeType)
                    };
                    
                    switch (attributeType)
                    {
                        case "Boolean":
                            booleanCount++;
                            break;
                        case "DateTime":
                            dateTimeCount++;
                            break;
                        case "Money":
                            moneyCount++;
                            break;
                        case "String":
                            stringCount++;
                            break;
                        case "Double":
                            doubleCount++;
                            break;
                        case "Integer":
                            integerCount++;
                            break;
                        case "Picklist":
                            optionSetCount++;
                            break;
                        case "Lookup":
                            entityReferenceCount++;
                            break;
                        case "EntityReference":
                            entityReferenceCount++;
                            break;
                        case "Memo":
                            stringCount++;
                            break;
                        case "Decimal":
                            decimalCount++;
                            break;
                        case "Customer":
                            entityReferenceCount++;
                            break;
                        default:
                            Console.WriteLine("Unknown attribute type: " + attributeType);
                            break;
                    }

                    batchFieldList.Add(batchContainer);
                }
                
            }
            
            Console.WriteLine("Entity count: " + entityCount);
            Console.WriteLine("Boolean: " + booleanCount);
            Console.WriteLine("DateTime: " + dateTimeCount);
            Console.WriteLine("Money: " + moneyCount);
            Console.WriteLine("String: " + stringCount);
            Console.WriteLine("Double: " + doubleCount);
            Console.WriteLine("Integer: " + integerCount);
            Console.WriteLine("OptionSet: " + optionSetCount);
            Console.WriteLine("EntityReference: " + entityReferenceCount);
            Console.WriteLine("Decimal: " + decimalCount);
            Console.WriteLine("\nTotal fields: " + (booleanCount + dateTimeCount + moneyCount + stringCount + doubleCount + integerCount + optionSetCount + entityReferenceCount + decimalCount));


        }
    }
}