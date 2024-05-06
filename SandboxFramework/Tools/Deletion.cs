using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Messages;
using Microsoft.Xrm.Sdk.Query;

namespace SandboxFramework.Tools
{
    public static class Deletion
    {
        private const int FieldThreads = 4;
        private const int FieldChunkSize = 500;

        public static void Cleanup(string batchIdentifier = null)
        {
            ServicePointManager.DefaultConnectionLimit = 65000;
            ServicePointManager.Expect100Continue = false;
            ServicePointManager.UseNagleAlgorithm = false;
            System.Threading.ThreadPool.SetMinThreads(100, 100);

            var organizationService = GetOrganizationService();

            GetDailyJobs(batchIdentifier, organizationService);
        }

        private static void GetDailyJobs(string batchIdentifier, IOrganizationService organizationService)
        {
            var dailyJobs = new List<Entity>();
            var dailyJobQuery = new QueryExpression("new_dailyjob")
            {
                ColumnSet = new ColumnSet(false)
            };

            if (!string.IsNullOrWhiteSpace(batchIdentifier))
            {
                dailyJobQuery.Criteria.AddCondition("new_identifier", ConditionOperator.Equal, batchIdentifier);
            }

            var dailyJobsResult = organizationService.RetrieveMultiple(dailyJobQuery);
            dailyJobs.AddRange(dailyJobsResult.Entities);

            while (dailyJobsResult.MoreRecords)
            {
                dailyJobQuery.PageInfo.PageNumber++;
                dailyJobQuery.PageInfo.PagingCookie = dailyJobsResult.PagingCookie;
                dailyJobsResult = organizationService.RetrieveMultiple(dailyJobQuery);
                dailyJobs.AddRange(dailyJobsResult.Entities);

                if (dailyJobs.Count <= 25_000)
                {
                    continue;
                }

                var deleteMessage = batchIdentifier == null 
                    ? string.Format("Deleting {0} daily jobs.", dailyJobs.Count)
                    : string.Format("Deleting {0} daily jobs for batch identifier {1}.", dailyJobs.Count, batchIdentifier);
                
                Console.WriteLine(deleteMessage);
                
                DeleteDailyJobs(dailyJobs);
                dailyJobs.Clear();
            }

            DeleteDailyJobs(dailyJobs);
        }

        private static void DeleteDailyJobs(IEnumerable<Entity> dailyJobs)
        {
            var parallelOptions = new ParallelOptions
            {
                MaxDegreeOfParallelism = FieldThreads
            };

            Parallel.ForEach(dailyJobs.ChunkBy(FieldChunkSize), parallelOptions, chunk =>
            {
                var localOrganizationService = GetOrganizationService();

                var executeMultiple = new ExecuteMultipleRequest
                {
                    Settings = new ExecuteMultipleSettings
                    {
                        ContinueOnError = true,
                        ReturnResponses = false
                    },
                    Requests = new OrganizationRequestCollection()
                };

                foreach (var dailyJob in chunk)
                {
                    executeMultiple.Requests.Add(new DeleteRequest { Target = dailyJob.ToEntityReference() });
                }

                localOrganizationService.Execute(executeMultiple);
                executeMultiple.Requests.Clear();
            });
        }

        private static IOrganizationService GetOrganizationService()
        {
            return OrganizationService.GetOrganizationServiceInTest();
        }
    }
}