using System;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Messages;
using Microsoft.Xrm.Sdk.Query;

namespace SandboxFramework
{
    internal static class Program
    {
        private static readonly IOrganizationService OrganizationService = Tools.OrganizationService.GetOrganizationService();
        private static ExecuteMultipleRequest _executeMultipleRequest;

        private const string AccountOpportunityLogicalName = "opportunity";
        private const string AccountOpportunityStartingDateExpectedField = "new_startingdateexpected";
        private const string AccountOpportunityDaysBeforeStartingDateField = "new_daysbeforestartingdate";
        private const string AccountOpportunityStatusField = "statuscode";

        public static void Main()
        {
            const int openStatus = 1;

            var accountOpportunitiesQuery = new QueryExpression(AccountOpportunityLogicalName)
            {
                ColumnSet = new ColumnSet(AccountOpportunityStartingDateExpectedField, AccountOpportunityStartingDateExpectedField),
                PageInfo = new PagingInfo
                {
                    PageNumber = 1,
                    // Count = recordsPerPage,
                    PagingCookie = null
                },
                Criteria = new FilterExpression
                {
                    Conditions =
                    {
                        new ConditionExpression(AccountOpportunityStartingDateExpectedField, ConditionOperator.NotNull),
                        new ConditionExpression(AccountOpportunityStatusField, ConditionOperator.Equal, openStatus)
                    }
                }
            };

            var accountOpportunities = OrganizationService.RetrieveMultiple(accountOpportunitiesQuery);

            if (accountOpportunities.Entities.Count == 0)
            {
                return;
            }

            _executeMultipleRequest = new ExecuteMultipleRequest
            {
                Requests = new OrganizationRequestCollection(),
                Settings = new ExecuteMultipleSettings
                {
                    ContinueOnError = true,
                    ReturnResponses = true
                }
            };

            while (true)
            {
                UpdateDaysBeforeExpectedStartingDateField(accountOpportunities.Entities);

                if (!accountOpportunities.MoreRecords)
                {
                    break;
                }

                accountOpportunitiesQuery.PageInfo.PageNumber++;
                accountOpportunitiesQuery.PageInfo.PagingCookie = accountOpportunities.PagingCookie;
                accountOpportunities = OrganizationService.RetrieveMultiple(accountOpportunitiesQuery);
            }
        }

        private static void UpdateDaysBeforeExpectedStartingDateField(DataCollection<Entity> accountOpportunities)
        {
            foreach (var accountOpportunity in accountOpportunities)
            {
                var daysBeforeExpectedStartingDate = (DateTime.Now - accountOpportunity.GetAttributeValue<DateTime>(AccountOpportunityStartingDateExpectedField)).Days;
                var isStartingDateWithin90Days = daysBeforeExpectedStartingDate is <= 90 and >= 0;

                if (!isStartingDateWithin90Days)
                {
                    continue;
                }
                
                var accountOpportunityDaysBeforeStartingDateFieldValue = accountOpportunity.GetAttributeValue<int>(AccountOpportunityDaysBeforeStartingDateField);

                if (daysBeforeExpectedStartingDate <= 45 && accountOpportunityDaysBeforeStartingDateFieldValue != 45)
                {
                    accountOpportunity[AccountOpportunityDaysBeforeStartingDateField] = 45;
                }
                else if(accountOpportunityDaysBeforeStartingDateFieldValue != 90)
                {
                    accountOpportunity[AccountOpportunityDaysBeforeStartingDateField] = 90;
                }
                else
                {
                    continue;
                }
                
                _executeMultipleRequest.Requests.Add(new UpdateRequest
                {
                    Target = accountOpportunity
                });

                var thing = (int) accountOpportunity[AccountOpportunityDaysBeforeStartingDateField];
            }

            // OrganizationService.Execute(_executeMultipleRequest);
        }
    }
}