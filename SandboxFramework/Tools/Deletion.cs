using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Threading.Tasks;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Messages;
using Microsoft.Xrm.Sdk.Query;

namespace SandboxFramework.Tools
{
    public static class Deletion
    {
        public static void Cleanup(string batchIdentifier)
        {
            ServicePointManager.DefaultConnectionLimit = 65000;
            ServicePointManager.Expect100Continue = false;
            ServicePointManager.UseNagleAlgorithm = false;
            System.Threading.ThreadPool.SetMinThreads(100, 100);

            var organizationService = OrganizationService.GetOrganizationService();

            const int threads = 4;
            const int chunkSize = 500;

            var parallelOptions = new ParallelOptions
            {
                MaxDegreeOfParallelism = threads
            };

            var dailyJobs = new List<Entity>();
            var dailyJobQuery = new QueryExpression("new_dailyjob");
            // dailyJobQuery.Criteria.AddCondition("new_identifier", ConditionOperator.Equal, batchIdentifier);

            var dailyJobsResult = organizationService.RetrieveMultiple(dailyJobQuery);
            dailyJobs.AddRange(dailyJobsResult.Entities);

            while (dailyJobsResult.MoreRecords)
            {
                dailyJobQuery.PageInfo.PageNumber++;
                dailyJobQuery.PageInfo.PagingCookie = dailyJobsResult.PagingCookie;
                dailyJobsResult = organizationService.RetrieveMultiple(dailyJobQuery);
                dailyJobs.AddRange(dailyJobsResult.Entities);
            }

            var totalDailyJobs = dailyJobs.Count;
            
            Console.WriteLine($"Deleting {totalDailyJobs} daily jobs from batch job: {batchIdentifier}");

            var sw = Stopwatch.StartNew();

            do
            {
                Parallel.ForEach(dailyJobs.ChunkBy(chunkSize), parallelOptions, chunk =>
                {
                    var localOrganizationService = OrganizationService.GetOrganizationService();

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


                Console.WriteLine($"Deleted {totalDailyJobs} daily jobs after {sw.Elapsed.TotalSeconds} seconds");
            } while (dailyJobsResult.MoreRecords);
        }
    }
}