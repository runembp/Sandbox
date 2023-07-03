using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using DTL.Entities;
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

            var dailyJobs = new List<DailyJobEntity>();
            var dailyJobQuery = new QueryExpression(DailyJobEntity.EntityLogicalName);
            dailyJobQuery.Criteria.AddCondition(DailyJobEntity.FieldBatchIdentifier, ConditionOperator.Equal, batchIdentifier);

            var dailyJobsResult = organizationService.RetrieveMultiple(dailyJobQuery);
            dailyJobs.AddRange(dailyJobsResult.Entities.Select(entity => entity.ToEntity<DailyJobEntity>()));

            while (dailyJobsResult.MoreRecords)
            {
                dailyJobQuery.PageInfo.PageNumber++;
                dailyJobQuery.PageInfo.PagingCookie = dailyJobsResult.PagingCookie;
                dailyJobsResult = organizationService.RetrieveMultiple(dailyJobQuery);
                dailyJobs.AddRange(dailyJobsResult.Entities.Select(entity => entity.ToEntity<DailyJobEntity>()));
            }

            Console.WriteLine($"Deleting {dailyJobs.Count} daily jobs from batch job: {batchIdentifier}");

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


                Console.WriteLine($"Deleted {dailyJobsResult.Entities.Count} daily jobs after {sw.Elapsed.TotalSeconds} seconds");
            } while (dailyJobsResult.MoreRecords);

            Console.WriteLine($"Done in Elapsed: {sw.Elapsed.TotalSeconds}");
        }
    }
}