namespace DTL.ApplicationConstants;

public static class BatchJobs
{
    public static readonly Dictionary<int, string> BatchJobCatalog = new()
    {
        {666, "ProductAtomBatchJob"}
    };
}
public static class Actions
{
    public const string Insert = "INSERT";
    public const string Update = "UPDATE";
    public const string Delete = "DELETE";
}

public static class Delimiters
{
    public const string SemiColon = ";";
    public const string Comma = ",";
}

public static class MultiThreadingSettings
{
    public const int ThreadCount = 5;
    public const int FilterMaxSize = 100;
    public const int BatchChunkSize = 500;
}