using System;
using System.Collections.Generic;

namespace SandboxFramework.Tools;

public class PerformanceTestingInitializer
{
    private static void PerformanceTesting()
        {
            System.Threading.ThreadPool.SetMinThreads(100, 100);

            System.Net.ServicePointManager.DefaultConnectionLimit = 65000;
            System.Net.ServicePointManager.Expect100Continue = false;
            System.Net.ServicePointManager.UseNagleAlgorithm = false;

            // var dict = new Dictionary<string, Tuple<double, double>>
            // {
            //     { "ForEach - 100 per batch", PerformanceTest.CreateAndDeleteForEachExecuteMultipleRequest(100)},
            //     { "ForEach - 200 per batch", PerformanceTest.CreateAndDeleteForEachExecuteMultipleRequest(200)},
            //     { "ForEach - 300 per batch", PerformanceTest.CreateAndDeleteForEachExecuteMultipleRequest(300)},
            //     { "ForEach - 400 per batch", PerformanceTest.CreateAndDeleteForEachExecuteMultipleRequest(400)},
            //     { "ForEach - 500 per batch", PerformanceTest.CreateAndDeleteForEachExecuteMultipleRequest(500)},
            //     { "ForEach - 600 per batch", PerformanceTest.CreateAndDeleteForEachExecuteMultipleRequest(600)},
            //     { "ForEach - 700 per batch", PerformanceTest.CreateAndDeleteForEachExecuteMultipleRequest(700)},
            //     { "ForEach - 800 per batch", PerformanceTest.CreateAndDeleteForEachExecuteMultipleRequest(800)},
            //     { "ForEach - 900 per batch", PerformanceTest.CreateAndDeleteForEachExecuteMultipleRequest(900)},
            //     { "ForEach - 1000 per batch", PerformanceTest.CreateAndDeleteForEachExecuteMultipleRequest(1000)},
            // };

            var performanceList = new Dictionary<string, PerformanceDTO>()
            {
                // {"2 Threads, Batch size: 100", PerformanceTest.CreateAndDeleteParallelExecuteMultiple(2, 100, 2000)},
                // {"2 Threads, Batch size: 200", PerformanceTest.CreateAndDeleteParallelExecuteMultiple(2, 200, 2000)},
                // {"2 Threads, Batch size: 300", PerformanceTest.CreateAndDeleteParallelExecuteMultiple(2, 300, 2000)},
                // {"2 Threads, Batch size: 400", PerformanceTest.CreateAndDeleteParallelExecuteMultiple(2, 400, 2000)},
                // {"2 Threads, Batch size: 500", PerformanceTest.CreateAndDeleteParallelExecuteMultiple(2, 500, 2000)},
                // {"2 Threads, Batch size: 600", PerformanceTest.CreateAndDeleteParallelExecuteMultiple(2, 600, 2000)},
                // {"2 Threads, Batch size: 700", PerformanceTest.CreateAndDeleteParallelExecuteMultiple(2, 700, 2000)},
                // {"2 Threads, Batch size: 800", PerformanceTest.CreateAndDeleteParallelExecuteMultiple(2, 800, 2000)},
                // {"2 Threads, Batch size: 900", PerformanceTest.CreateAndDeleteParallelExecuteMultiple(2, 900, 2000)},
                // {"2 Threads, Batch size: 1000", PerformanceTest.CreateAndDeleteParallelExecuteMultiple(2, 1000, 2000)},

                // {"3 Threads, Batch size: 100", PerformanceTest.CreateAndDeleteParallelExecuteMultiple(3, 100, 2000)},
                // {"3 Threads, Batch size: 200", PerformanceTest.CreateAndDeleteParallelExecuteMultiple(3, 200, 2000)},
                // {"3 Threads, Batch size: 300", PerformanceTest.CreateAndDeleteParallelExecuteMultiple(3, 300, 2000)},
                // {"3 Threads, Batch size: 400", PerformanceTest.CreateAndDeleteParallelExecuteMultiple(3, 400, 2000)},
                // {"3 Threads, Batch size: 500", PerformanceTest.CreateAndDeleteParallelExecuteMultiple(3, 500, 2000)},
                // {"3 Threads, Batch size: 600", PerformanceTest.CreateAndDeleteParallelExecuteMultiple(3, 600, 2000)},
                // {"3 Threads, Batch size: 700", PerformanceTest.CreateAndDeleteParallelExecuteMultiple(3, 700, 2000)},
                // {"3 Threads, Batch size: 800", PerformanceTest.CreateAndDeleteParallelExecuteMultiple(3, 800, 2000)},
                // {"3 Threads, Batch size: 900", PerformanceTest.CreateAndDeleteParallelExecuteMultiple(3, 900, 2000)},
                // {"3 Threads, Batch size: 1000", PerformanceTest.CreateAndDeleteParallelExecuteMultiple(3, 1000, 2000)},

                // {"4 Threads, Batch size: 100", PerformanceTest.CreateAndDeleteParallelExecuteMultiple(4, 100, 2000)},
                // {"4 Threads, Batch size: 200", PerformanceTest.CreateAndDeleteParallelExecuteMultiple(4, 200, 2000)},
                // {"4 Threads, Batch size: 300", PerformanceTest.CreateAndDeleteParallelExecuteMultiple(4, 300, 2000)},
                // {"4 Threads, Batch size: 400", PerformanceTest.CreateAndDeleteParallelExecuteMultiple(4, 400, 2000)},
                // {"4 Threads, Batch size: 500", PerformanceTest.CreateAndDeleteParallelExecuteMultiple(4, 500, 2000)},
                // {"4 Threads, Batch size: 600", PerformanceTest.CreateAndDeleteParallelExecuteMultiple(4, 600, 2000)},
                // {"4 Threads, Batch size: 700", PerformanceTest.CreateAndDeleteParallelExecuteMultiple(4, 700, 2000)},
                // {"4 Threads, Batch size: 800", PerformanceTest.CreateAndDeleteParallelExecuteMultiple(4, 800, 2000)},
                // {"4 Threads, Batch size: 900", PerformanceTest.CreateAndDeleteParallelExecuteMultiple(4, 900, 2000)},
                // {"4 Threads, Batch size: 1000", PerformanceTest.CreateAndDeleteParallelExecuteMultiple(4, 1000, 2000)},

                // {"5 Threads, Batch size: 100", PerformanceTest.CreateAndDeleteParallelExecuteMultiple(5, 100, 2000)},
                // {"5 Threads, Batch size: 200", PerformanceTest.CreateAndDeleteParallelExecuteMultiple(5, 200, 2000)},
                // {"5 Threads, Batch size: 300", PerformanceTest.CreateAndDeleteParallelExecuteMultiple(5, 300, 2000)},
                // {"5 Threads, Batch size: 400", PerformanceTest.CreateAndDeleteParallelExecuteMultiple(5, 400, 2000)},
                // {"5 Threads, Batch size: 500", PerformanceTest.CreateAndDeleteParallelExecuteMultiple(5, 500, 2000)},
                // {"5 Threads, Batch size: 600", PerformanceTest.CreateAndDeleteParallelExecuteMultiple(5, 600, 2000)},
                // {"5 Threads, Batch size: 700", PerformanceTest.CreateAndDeleteParallelExecuteMultiple(5, 700, 2000)},
                // {"5 Threads, Batch size: 800", PerformanceTest.CreateAndDeleteParallelExecuteMultiple(5, 800, 2000)},
                // {"5 Threads, Batch size: 900", PerformanceTest.CreateAndDeleteParallelExecuteMultiple(5, 900, 2000)},
                // {"5 Threads, Batch size: 1000", PerformanceTest.CreateAndDeleteParallelExecuteMultiple(5, 1000, 2000)},
            };

            performanceList.Add("Test", PerformanceTest.CreateAndDeleteParallelExecuteMultiple(100, 100, 2000));


            var overview = new Dictionary<string, Tuple<double, double>>();

            foreach (var keyValuePair in performanceList)
            {
                overview.Add(keyValuePair.Key, new Tuple<double, double>(keyValuePair.Value.AverageInsert, keyValuePair.Value.AverageDelete));
            }


            Console.WriteLine("Breakpoint!!!");
            Console.WriteLine("Breakpoint!!!");
            Console.WriteLine("Breakpoint!!!");
        }
}