using System.Diagnostics;
using System.Net;
using DTL.Entities;
using Simple.OData.Client;

namespace SandboxCore.Tools;

public static class DeleteCoveragePolicies
{
    private static List<double> _doubleList = new();

    public static async Task<double> DeleteAll(int chunkSize)
    {
        var sw = Stopwatch.StartNew();

        var client = WebApiClient.GetClient();

        var annotations = new ODataFeedAnnotations();

        var coveragePolicyEntities = client.For<CoveragePolicyEntity>()
            .Select(x => x.Id)
            .FindEntriesAsync(annotations)
            .Result
            .ToList();

        if (!coveragePolicyEntities.Any())
        {
            Console.WriteLine("No coverage policies found to delete");
            return -1;
        }
        
        Console.WriteLine($"Retrieved {coveragePolicyEntities.Count} coverage policies after {sw.Elapsed.TotalSeconds}");

        await Parallel.ForEachAsync(coveragePolicyEntities.Chunk(chunkSize), async (chunk, _) =>
        {
            var threadStopwatch = Stopwatch.StartNew();
            var batch = new ODataBatch(WebApiClient.GetClient());
            
            foreach (var coveragePolicy in chunk)
            {
                batch += oDataClient => oDataClient.For<CoveragePolicyEntity>().Key(coveragePolicy.Id).DeleteEntryAsync(_);
            }

            await batch.ExecuteAsync(_);
        
            var rps = Math.Round(chunk.Length / threadStopwatch.Elapsed.TotalSeconds,1);
            Console.WriteLine($"rps: {rps}");
            _doubleList.Add(rps);
        });

        Console.WriteLine($"Estimation:  {coveragePolicyEntities.Count / (sw.Elapsed.TotalSeconds / 60)}");

        return _doubleList.Average();
    }
}