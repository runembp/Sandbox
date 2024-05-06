using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Messages;
using Microsoft.Xrm.Sdk.Query;

namespace SandboxFramework.Tools
{
    public class ProcessDeletion
    {
        public static void Cleanup()
        {
            var query = new QueryExpression("workflow")
            {
                ColumnSet = new ColumnSet("name", "statecode", "statuscode"),
                Criteria = new FilterExpression
                {
                    // FilterOperator = LogicalOperator.Or,
                    Conditions =
                    {
                        new ConditionExpression("primaryentity", ConditionOperator.Equal, "contact"),
                        new ConditionExpression("statecode", ConditionOperator.Equal, 0),
                    }
                }
            };

            var result = Tools.OrganizationService.GetOrganizationServiceInTest().RetrieveMultiple(query);
            
            var executeMultipleRequest = new ExecuteMultipleRequest
            {
                Settings = new ExecuteMultipleSettings
                {
                    ContinueOnError = true,
                    ReturnResponses = true
                },
                Requests = new OrganizationRequestCollection()
            };

            foreach (var workflow in result.Entities)
            {
                executeMultipleRequest.Requests.Add(new DeleteRequest{Target = workflow.ToEntityReference()});

                if (executeMultipleRequest.Requests.Count != 50)
                {
                    continue;
                }
                
                var response = (ExecuteMultipleResponse) OrganizationService.GetOrganizationServiceInTest().Execute(executeMultipleRequest);
                executeMultipleRequest.Requests.Clear();
            }
            
            if (executeMultipleRequest.Requests.Count > 0)
            {
                OrganizationService.GetOrganizationServiceInTest().Execute(executeMultipleRequest);
            }
        }
    }
}