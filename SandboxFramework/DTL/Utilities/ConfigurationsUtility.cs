using System.Threading.Tasks;

namespace DTL.Utilities
{
    public static class ConfigurationsUtility
    {
        public const int ThreadCount = 4;
        public const int BatchChunkSize = 500;
        public const int FileChunkSize = 100000;
        
        public static ParallelOptions ParallelOptions => new ParallelOptions
        {
            MaxDegreeOfParallelism = ThreadCount
        };
    }
}