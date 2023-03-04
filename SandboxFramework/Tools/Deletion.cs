using System;
using System.Diagnostics;
using System.Net;
using System.Threading.Tasks;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Messages;
using Microsoft.Xrm.Sdk.Query;
using SandboxFramework.Entities;

namespace SandboxFramework.Tools;

public static class Deletion
{
    public static void Cleanup()
    {
        ServicePointManager.DefaultConnectionLimit = 65000;
        ServicePointManager.Expect100Continue = false;
        ServicePointManager.UseNagleAlgorithm = false;
        System.Threading.ThreadPool.SetMinThreads(100, 100);

        var organizationService = OrganizationService.GetOrganizationService();

        const int threads = 4;
        const int chunkSize = 200;

        var parallelOptions = new ParallelOptions
        {
            MaxDegreeOfParallelism = threads
        };

        var dailyJobQuery = new QueryExpression(DailyJobEntity.EntityLogicalName);
        dailyJobQuery.Criteria.AddCondition(DailyJobEntity.FieldBatchIdentifier, ConditionOperator.Equal, "666");
        var dailyJobs = organizationService.RetrieveMultiple(dailyJobQuery);

        Console.WriteLine($"Deleting {dailyJobs.Entities.Count} daily jobs");

        var coveragePoliciesQuery = new QueryExpression(CoveragePolicyEntity.EntityLogicalName);
        var coveragePolicies = organizationService.RetrieveMultiple(coveragePoliciesQuery);

        Console.WriteLine($"Deleting {coveragePolicies.Entities.Count} coverage policies");

        var sw = Stopwatch.StartNew();

        Parallel.ForEach(dailyJobs.Entities.ChunkBy(chunkSize), parallelOptions, chunk =>
        {
            var localOrganizationService = OrganizationService.GetOrganizationService();

            var executeMultiple = new ExecuteMultipleRequest
            {
                Settings = new ExecuteMultipleSettings
                {
                    ContinueOnError = true,
                    ReturnResponses = true
                },
                Requests = new OrganizationRequestCollection()
            };

            foreach (var dailyJob in chunk)
            {
                executeMultiple.Requests.Add(new DeleteRequest { Target = dailyJob.ToEntityReference() });

                if (executeMultiple.Requests.Count > 100)
                {
                    localOrganizationService.Execute(executeMultiple);
                    executeMultiple.Requests.Clear();
                }
            }

            if (executeMultiple.Requests.Count > 0)
            {
                localOrganizationService.Execute(executeMultiple);
            }
        });


        Parallel.ForEach(coveragePolicies.Entities.ChunkBy(chunkSize), parallelOptions, chunk =>
        {
            var localOrganizationService = OrganizationService.GetOrganizationService();

            var executeMultiple = new ExecuteMultipleRequest
            {
                Settings = new ExecuteMultipleSettings
                {
                    ContinueOnError = true,
                    ReturnResponses = true
                },
                Requests = new OrganizationRequestCollection()
            };

            foreach (var coveragePolicy in chunk)
            {
                executeMultiple.Requests.Add(new DeleteRequest { Target = coveragePolicy.ToEntityReference() });

                if (executeMultiple.Requests.Count > 100)
                {
                    localOrganizationService.Execute(executeMultiple);
                    executeMultiple.Requests.Clear();
                }
            }

            if (executeMultiple.Requests.Count > 0)
            {
                localOrganizationService.Execute(executeMultiple);
            }
        });

        Console.WriteLine($"Done in Elapsed: {sw.Elapsed.TotalSeconds}");
    }
}