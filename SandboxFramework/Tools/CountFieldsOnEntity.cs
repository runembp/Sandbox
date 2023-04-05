using System;
using System.Collections.Generic;
using Microsoft.Xrm.Sdk.Messages;
using Microsoft.Xrm.Sdk.Metadata;

namespace SandboxFramework.Tools;

public class CountFieldsOnEntity
{
    public static void CountFields(string entityName)
    {
        var organizationService = OrganizationService.GetOrganizationService();

        EntityMetadata entityMetadata = ((RetrieveEntityResponse)organizationService.Execute(new RetrieveEntityRequest
        {
            LogicalName = entityName,
            EntityFilters = EntityFilters.Attributes
        })).EntityMetadata;

        int existingFieldCount = 0;
        int optionSetCount = 0;
        int lookupCount = 0;
        int customerCount = 0;
        int ownerCount = 0;
        int multiSelectPicklistCount = 0;

        foreach (AttributeMetadata attributeMetadata in entityMetadata.Attributes)
        {
            switch (attributeMetadata.AttributeType)
            {
                case AttributeTypeCode.Picklist:
                case AttributeTypeCode.State:
                case AttributeTypeCode.Status:
                    optionSetCount++;
                    break;
                case AttributeTypeCode.Lookup:
                case AttributeTypeCode.Customer:
                    lookupCount++;
                    break;
                case AttributeTypeCode.Owner:
                    ownerCount++;
                    break;
                // case AttributeTypeCode.MultiSelectPicklistAttributeMetadata:
                //     multiSelectPicklistCount++;
                //     break;
            }

            Console.WriteLine($"{attributeMetadata.LogicalName} ({attributeMetadata.AttributeType}): 1");
        }

        var remainingFieldCount = 1024 - existingFieldCount - optionSetCount - (2 * lookupCount) - customerCount - ownerCount - multiSelectPicklistCount;

        Console.WriteLine($"Existing fields: {existingFieldCount}");
        Console.WriteLine($"Option sets: {optionSetCount}");
        Console.WriteLine($"Lookups and Customers: {lookupCount + customerCount}");
        Console.WriteLine($"Owners: {ownerCount}");
        Console.WriteLine($"Multi-select picklists: {multiSelectPicklistCount}");
        Console.WriteLine($"Remaining fields: {remainingFieldCount}");

        Console.ReadLine();
    }
}