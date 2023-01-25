namespace BatchApplication.Services;

public static class LocationService
{
    private const string EnvironmentFileshare = @"\\smb-app.dev1.vlpadr.net\crm\com\";
    private const string JobCompletedFolder = @"JobCompletedFolder\";
    
    public static string GetBatchJobLocation(string batchJobIdentifier)
    {
        return EnvironmentFileshare + batchJobIdentifier;
    }

    public static string GetJobCompletedFolder(string batchJobIdentifier)
    {
        return EnvironmentFileshare + JobCompletedFolder + batchJobIdentifier;
    }
}