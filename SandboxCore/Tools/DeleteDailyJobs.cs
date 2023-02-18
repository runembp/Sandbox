using System.Diagnostics;
using DTL.Entities;
using Simple.OData.Client;

namespace SandboxCore.Tools;

public static class DeleteDailyJobs
{
    public static async Task DeleteDailyJobsByIdentifier(string batchId)
    {
        var sw = Stopwatch.StartNew();
        
        var client = WebApiClient.GetClient();

        var annotations = new ODataFeedAnnotations();
        
        var dailyJobs = client.For<DailyJobEntity>()
            .Filter(x => x.BatchIdentifier == batchId)
            .Select(x => x.Id)
            .FindEntriesAsync(annotations)
            .Result
            .ToList();

        while (annotations.NextPageLink != null)
        {
            dailyJobs.AddRange(await client.For<DailyJobEntity>()
                .FindEntriesAsync(annotations.NextPageLink, annotations));
        }
        
        Console.WriteLine($"Retrieved {dailyJobs.Count} dailyjobs after {sw.Elapsed.TotalSeconds}");

        await Parallel.ForEachAsync(dailyJobs.Chunk(100), new ParallelOptions { MaxDegreeOfParallelism = 4 }, async (chunk, _) =>
        {
            var threadStopwatch = Stopwatch.StartNew();
            var batch = new ODataBatch(client);

            foreach (var dailyJob in chunk)
            {
                batch += oDataClient => oDataClient.For<DailyJobEntity>().Key(dailyJob.Id).DeleteEntryAsync(_);
            }
            
            await batch.ExecuteAsync(_);
            Console.WriteLine($"Deleted {chunk.Length} in {threadStopwatch.Elapsed.TotalSeconds}");
        });

        Console.WriteLine($"Finished deleting {dailyJobs.Count} after {sw.Elapsed.TotalSeconds}");
    }
}