using System;
using System.Linq;
using Microsoft.Crm.Sdk.Messages;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;

namespace SandboxFramework.Tools
{
    public class AuditCleanUpProject
    {
        private static IOrganizationService OrganizationService => Tools.OrganizationService.GetOrganizationServiceInTest();
        
        public void CleanupAudit()
        {
            var accountGuid = new Guid("{E818FA4C-6BDF-EB11-AA87-A5783EBA800F}");
            // var account = OrganizationService.Retrieve("account", accountGuid, new ColumnSet());
            var accountEntityReference = new EntityReference("account", accountGuid);

            var changeRequest = new RetrieveRecordChangeHistoryRequest
            {
                PagingInfo = new PagingInfo
                {
                    Count = 500,
                    PageNumber = 1,
                    ReturnTotalRecordCount = true
                },
                Target = accountEntityReference
            };

            var changeResponse = (RetrieveRecordChangeHistoryResponse)OrganizationService.Execute(changeRequest);

            while (changeResponse.AuditDetailCollection.MoreRecords)
            {
                var auditDetails = changeResponse.AuditDetailCollection;

                // Iterate over the audit details
                foreach (var auditDetail in auditDetails.AuditDetails)
                {
                    if (!(auditDetail is AttributeAuditDetail attributeAuditDetail))
                    {
                        Console.WriteLine("Audit detail is not an attribute audit detail.");
                        continue;
                    }

                    Console.WriteLine($"Attribute: {attributeAuditDetail.OldValue.Attributes.First().Key}");
                    var fieldsInNewValue = attributeAuditDetail.NewValue.Attributes.Where(x => x.Key == "coveragePerEmployeeGroupName").ToList();
                    var fieldsInOldValue = attributeAuditDetail.OldValue.Attributes.Where(x => x.Key == "coveragePerEmployeeGroupName").ToList();

                    if (!fieldsInNewValue.Any() || !fieldsInOldValue.Any())
                    {
                        continue;
                    }

                    var newValue = attributeAuditDetail.NewValue;
                    var oldValue = attributeAuditDetail.OldValue;

                    if (newValue.Attributes.Any() && oldValue.Attributes.Any())
                    {
                        var firstNewValueAttribute = newValue.Attributes.First();
                        var firstOldValueAttribute = oldValue.Attributes.First();

                        if (!firstNewValueAttribute.Value.Equals(firstOldValueAttribute.Value))
                        {
                            continue;
                        }

                        Console.WriteLine($"Attribute: {firstNewValueAttribute.Key}");

                        switch (firstNewValueAttribute.Value)
                        {
                            case OptionSetValue optionSetValue:
                                Console.WriteLine($"Old Value: {((OptionSetValue)firstOldValueAttribute.Value).Value} - New Value: {optionSetValue.Value}");
                                break;
                            case EntityReference entityReference:
                                Console.WriteLine($"Old Value: {((EntityReference)firstOldValueAttribute.Value).Name} - New Value: {entityReference.Name}");
                                break;
                            case Money money:
                                Console.WriteLine($"Old Value: {((Money)firstOldValueAttribute.Value).Value} - New Value: {money.Value}");
                                break;
                            case DateTime dateTime:
                                Console.WriteLine($"Old Value: {((DateTime)firstOldValueAttribute.Value).ToShortDateString()} - New Value: {dateTime.ToShortDateString()}");
                                break;
                            default:
                                Console.WriteLine($"Old Value: {firstOldValueAttribute.Value} - New Value: {firstNewValueAttribute.Value}");
                                break;
                        }
                    }
                }

                Console.WriteLine($"Retrieved {changeRequest.PagingInfo.PageNumber * changeRequest.PagingInfo.Count} audit details.");
                
                changeRequest.PagingInfo.PageNumber++;
                changeRequest.PagingInfo.PagingCookie = changeResponse.AuditDetailCollection.PagingCookie;
                changeResponse = (RetrieveRecordChangeHistoryResponse)OrganizationService.Execute(changeRequest);
                
            }
        }
    }
}