namespace DTL.ApplicationConstants
{
    public static class Actions
    {
        public const string Insert = "INSERT";
        public const string Update = "UPDATE";
        public const string Delete = "DELETE";
    }

    public enum ReturnCodes
    {
        JobSuccessful = 0,
        JobFailed = 1
    }

    public static class SourcesForFolders
    {
        public const string N16 = "N16";
        public const string Mainframe = "Mainframe";
    }
    
    public static class Names
    {
        public const string BatchApplication = "BatchApplication";
    }
}