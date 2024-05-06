using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Messages;
using Microsoft.Xrm.Sdk.Query;

namespace SandboxFramework.Tools
{
    public class DeleteAllRecordsOfEntity
    {
        private static IOrganizationService OrganizationService => Tools.OrganizationService.GetOrganizationServiceInTest();

        public static void DeleteAllRecords(string entityLogicalName, DateTime deleteFrom)
        {
            var entityQuery = new QueryExpression(entityLogicalName)
            {
                ColumnSet = new ColumnSet(false),
                PageInfo =
                {
                    PageNumber = 1,
                    Count = 5000
                },
                Criteria = new FilterExpression
                {
                    Conditions =
                    {
                        new ConditionExpression("createdon", ConditionOperator.OnOrAfter, deleteFrom)
                    }
                }
            };
            
            var entityResults = OrganizationService.RetrieveMultiple(entityQuery);
            
            if(!entityResults.Entities.Any())
            {
                return;
            }

            var entitiesToDelete = new List<Entity>();
            entitiesToDelete.AddRange(entityResults.Entities);

            while (entityResults.MoreRecords)
            {
                entityQuery.PageInfo.PageNumber++;
                entityQuery.PageInfo.PagingCookie = entityResults.PagingCookie;
                entitiesToDelete.AddRange(entityResults.Entities);
                entityResults = OrganizationService.RetrieveMultiple(entityQuery);
            }
            
            Console.WriteLine($"Deleting {entityResults.Entities.Count} records of {entityLogicalName}.");

            var executeMultipleRequest = new ExecuteMultipleRequest
            {
                Settings = new ExecuteMultipleSettings
                {
                    ContinueOnError = true,
                    ReturnResponses = false
                },
                Requests = new OrganizationRequestCollection()
            };
            
            foreach (var entity in entitiesToDelete)
            {
                var deleteRequest = new DeleteRequest
                {
                    Target = entity.ToEntityReference()
                };
                
                executeMultipleRequest.Requests.Add(deleteRequest);

                if (executeMultipleRequest.Requests.Count != 500)
                {
                    continue;
                }
                
                OrganizationService.Execute(executeMultipleRequest);
                executeMultipleRequest.Requests.Clear();
            }
            
            OrganizationService.Execute(executeMultipleRequest);
        }
    }
}