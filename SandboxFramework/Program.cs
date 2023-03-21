using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Messages;
using Microsoft.Xrm.Sdk.Query;

namespace SandboxFramework
{
    internal static class Program
    {
        private static readonly IOrganizationService OrganizationService = Tools.OrganizationService.GetOrganizationService();
        private static ExecuteMultipleRequest _executeMultipleRequest;

        public static void Main()
        {
            const string accountOpportunityLogicalName = "opportunity";
            const string accountOpportunityStartingDateExpectedField = "new_startingdateexpected";

            var accountOpportunitiesQuery = new QueryExpression(accountOpportunityLogicalName)
            {
                ColumnSet = new ColumnSet(accountOpportunityStartingDateExpectedField),
                Criteria = new FilterExpression()
                {
                    Conditions = { new ConditionExpression(accountOpportunityStartingDateExpectedField, ConditionOperator.NotNull) }
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

            
            
        }
    }
}