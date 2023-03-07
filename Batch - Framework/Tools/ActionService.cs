using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Batch___Framework.Service;
using DTL.Entities;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Messages;
using Microsoft.Xrm.Sdk.Query;

namespace Batch___Framework.Tools;

public abstract class ActionService
{
    public static void InsertCoveragePolices(int numberOfCoveragePolicies, int chunkSize, ParallelOptions parallelOptions)
    {
        var fullStopWatch = Stopwatch.StartNew();
        
        var coveragePolicyList = ListService.GetCoveragePolicyList(numberOfCoveragePolicies);
        
        var coveragePolicyListChunked = coveragePolicyList.ChunkBy(chunkSize);
        
        Parallel.ForEach(coveragePolicyListChunked, parallelOptions, chunk =>
        {
            var sw = Stopwatch.StartNew();
            
            var batch = new ExecuteMultipleRequest
            {
                Requests = new OrganizationRequestCollection(),
                Settings = new ExecuteMultipleSettings
                {
                    ContinueOnError = true,
                    ReturnResponses = true
                }
            };
            
            foreach (var coveragePolicyEntity in chunk)
            {
                batch.Requests.Add(new CreateRequest{Target = coveragePolicyEntity});
            }
            
            var localOrganizationService = ConnectionService.GetOrganizationService();
            localOrganizationService.Execute(batch);
            
            Console.WriteLine($"Finished inserting {chunk.Count} in {sw.Elapsed.TotalSeconds}");
        });
        
        Console.WriteLine($"Finished inserting {numberOfCoveragePolicies} CoveragePolicies in {fullStopWatch.Elapsed.TotalSeconds} -- {Math.Round(numberOfCoveragePolicies / fullStopWatch.Elapsed.TotalSeconds, 1)} per second");
    }
    
    public static void CleanUp(int chunkSize, ParallelOptions parallelOptions)
    {
        var sw = Stopwatch.StartNew();
        
        var organizationService = ConnectionService.GetOrganizationService();
        
        var coveragePolicies = organizationService.RetrieveMultiple(new QueryExpression(CoveragePolicyEntity.EntityLogicalName)
        {
            PageInfo = new PagingInfo
            {
                Count = 5000,
                PageNumber = 1
            }
        });
        
        Parallel.ForEach(coveragePolicies.Entities.ChunkBy(chunkSize), parallelOptions,chunk =>
        {
            var localOrganizationService = ConnectionService.GetOrganizationService();    
            
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
                executeMultiple.Requests.Add(new DeleteRequest{Target = coveragePolicy.ToEntityReference()});
            
                if(executeMultiple.Requests.Count > 100)
                {
                    localOrganizationService.Execute(executeMultiple);
                    executeMultiple.Requests.Clear();
                }
            }
            
            if(executeMultiple.Requests.Count > 0)
            {
                localOrganizationService.Execute(executeMultiple);
            }
        });
        
        Console.WriteLine($"Finished deleting {coveragePolicies.Entities.Count} CoveragePolicies in {sw.Elapsed.TotalSeconds} - {Math.Round(coveragePolicies.Entities.Count / sw.Elapsed.TotalSeconds, 1)} per second");
    }
}