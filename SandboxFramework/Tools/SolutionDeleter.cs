using System;
using System.Linq;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;

namespace SandboxFramework.Tools
{
    public class SolutionDeleter
    {
        private readonly IOrganizationService _service = OrganizationService.GetOrganizationServiceInDev();

        public void DeleteSolutionByName(params string[] solutionNames)
        {
            foreach (var solutionName in solutionNames)
            {
                DeleteSolutionByName(solutionName);
            }
        }

        private void DeleteSolutionByName(string solutionName)
        {
            // Query to find the solution ID
            var query = new QueryExpression("solution")
            {
                ColumnSet = new ColumnSet("solutionid"),
                Criteria = new FilterExpression
                {
                    Conditions =
                    {
                        new ConditionExpression("uniquename", ConditionOperator.Equal, solutionName),
                        new ConditionExpression("ismanaged", ConditionOperator.Equal, false)
                    }
                }
            };

            var solution = _service.RetrieveMultiple(query).Entities.FirstOrDefault();

            if (solution != null)
            {
                // Delete the solution
                _service.Delete("solution", (Guid)solution["solutionid"]);
            }
            else
            {
                // Handle the case where the solution is not found
                // This could be logging or throwing an exception
                Console.WriteLine($"Solution '{solutionName}' not found or it is a managed solution.");
            }
        }
    }
}