using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Messages;
using Microsoft.Xrm.Sdk.Query;

namespace SandboxFramework.Tools
{
    public class DeletePluginTraceLogs
    {
        public static void Cleanup()
        {
            var query = new QueryExpression("plugintracelog")
            {
                ColumnSet = new ColumnSet(true)
            };

            var pluginTraceLogs = OrganizationService.GetOrganizationServiceInTest().RetrieveMultiple(query);
            
            var executeMultipleRequest = new ExecuteMultipleRequest
            {
                Settings = new ExecuteMultipleSettings
                {
                    ContinueOnError = true,
                    ReturnResponses = true
                },
                Requests = new OrganizationRequestCollection()
            };

            foreach (var pluginTraceLog in pluginTraceLogs.Entities)
            {
                executeMultipleRequest.Requests.Add(new DeleteRequest{Target = pluginTraceLog.ToEntityReference()});

                if (executeMultipleRequest.Requests.Count != 50)
                {
                    continue;
                }
                
                var response = (ExecuteMultipleResponse) OrganizationService.GetOrganizationServiceInTest().Execute(executeMultipleRequest);
                executeMultipleRequest.Requests.Clear();
            }
        }
    }
}