using SandboxFramework.Entities;
using SandboxFramework.Tools;

namespace SandboxFramework
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
            // PerformanceTest.CreateAndDeleteParallelExecuteMultiple(2, 200, 1000);
            // Deletion.Cleanup();
            
            var organizationService = OrganizationService.GetOrganizationService();

            var notesQuery = new QueryExpression("annotation")
            {
                ColumnSet = new ColumnSet("subject", "mimetype", "filename", "documentbody"),
                Criteria = new FilterExpression
                    {
                    FilterOperator = LogicalOperator.And,
                    Conditions = { new ConditionExpression("objectid", ConditionOperator.Equal, sourceEntityId) }
                   }
            };
            
            var notesList = organizationService.RetrieveMultiple(notesQuery);
        }
    }
}