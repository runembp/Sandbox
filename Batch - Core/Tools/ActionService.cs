using System.Diagnostics;
using Batch___Core.Service;
using DTL.Entities;
using Simple.OData.Client;

namespace Batch___Core.Tools;

public abstract class ActionService
{
    public static async Task InsertCoveragePolicy(int numberOfCoveragePolicies, int chunkSize, ParallelOptions parallelOptions)
    {
        var fullStopWatch = Stopwatch.StartNew();

        var coveragePolicyList = ListService.GetCoveragePolicyList(numberOfCoveragePolicies);
        var coveragePolicyListChunked = coveragePolicyList.Chunk(chunkSize);

        await Parallel.ForEachAsync(coveragePolicyListChunked, parallelOptions, async (chunk, _) =>
        {
            var sw = Stopwatch.StartNew();

            var batch = new ODataBatch(ConnectionService.GetODataClient());

            foreach (var coveragePolicyEntity in chunk)
            {
                batch += async oDataClient => await oDataClient.For<CoveragePolicyEntity>().Set(coveragePolicyEntity).InsertEntryAsync(false, _);
            }

            await batch.ExecuteAsync(_);
            Console.WriteLine($"Finished inserting {chunk.Length} in {sw.Elapsed.TotalSeconds}");
        });

        Console.WriteLine($"Finished inserting {numberOfCoveragePolicies} CoveragePolicies in {fullStopWatch.Elapsed.TotalSeconds} -- {Math.Round(numberOfCoveragePolicies / fullStopWatch.Elapsed.TotalSeconds, 1)} per second");
    }

    public static async Task CleanUp(int chunkSize, ParallelOptions parallelOptions)
    {
        var sw = Stopwatch.StartNew();
        
        var client = ConnectionService.GetODataClient();

        var coveragePolicies = client
            .For<CoveragePolicyEntity>()
            .Select(x => new
            {
                x.Id
            })
            .FindEntriesAsync()
            .Result
            .ToList();

        await Parallel.ForEachAsync(coveragePolicies.Chunk(chunkSize), parallelOptions, async (chunk, _) =>
        {
            var threadClient = ConnectionService.GetODataClient();
            var batch = new ODataBatch(threadClient);
        
            foreach (var coveragePolicyEntity in chunk)
            {
                batch += oDataClient => oDataClient.For<CoveragePolicyEntity>().Key(coveragePolicyEntity.Id).DeleteEntryAsync(_);
            }
        
            await batch.ExecuteAsync(_);
        });

        Console.WriteLine($"Finished deleting {coveragePolicies.Count} coverage policies in {sw.Elapsed.TotalSeconds} - {Math.Round(coveragePolicies.Count / sw.Elapsed.TotalSeconds, 1)} per second");
    }
}