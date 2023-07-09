using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Messages;
using Microsoft.Xrm.Sdk.Metadata;
using Microsoft.Xrm.Sdk.Query;
using SandboxFramework.Tools;

namespace SandboxFramework
{
    internal static class Program
    {
        private static IOrganizationService OrganizationService => Tools.OrganizationService.GetOrganizationService();

        public static Task Main()
        {
            var request = new RetrieveEntityRequest
            {
                EntityFilters = EntityFilters.Attributes,
                LogicalName = "new_policy"
            };

            var response = (RetrieveEntityResponse)OrganizationService.Execute(request);
            var fieldsFromFile = ScanBatch.ScanBatchText();

            var batchFieldList = new List<BatchContainer>();

            var count = 0;

            foreach (var attr in response.EntityMetadata.Attributes)
            {
                var customAttributesFromBatchFile = attr.IsCustomAttribute.GetValueOrDefault()
                                                    && fieldsFromFile.Contains(attr.LogicalName);

                if (!customAttributesFromBatchFile)
                {
                    continue;
                }

                var label = attr.DisplayName;
                var attributeType = attr.AttributeType.ToString();

                var displayName = label.UserLocalizedLabel.Label;
                var displayNameSplit = displayName.Split(' ');

                for(var i = 0; i < displayNameSplit.Length; i++)
                {
                    var letters = displayNameSplit[i].ToCharArray();
                    letters[0] = char.ToUpper(letters[0]);
                    displayNameSplit[i] = new string(letters);
                }
                
                var displayNameJoined = string.Join("", displayNameSplit).Replace(" ", "").Trim();

                var batchContainer = new BatchContainer
                {
                    DisplayName = displayNameJoined,
                    FieldName = attr.LogicalName,
                    DataType = attributeType
                };

                batchFieldList.Add(batchContainer);

                count++;
            }

            Console.WriteLine($"Total number of custom attributes: {count}");

            foreach (var field in batchFieldList)
            {
                Console.WriteLine($"public const string Field{field.DisplayName} = \"{field.FieldName}\";");
            }

            Console.WriteLine();

            // foreach (var field in batchFieldList)
            // {
            //     Console.WriteLine(field.DataType);
            // }

            return Task.CompletedTask;
        }

        private class BatchContainer
        {
            public string DisplayName { get; set; }
            public string FieldName { get; set; }
            public string DataType { get; set; }
        }
    }
}