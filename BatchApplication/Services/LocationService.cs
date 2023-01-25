namespace BatchApplication.Services;

public class LocationService
{
    private const string ComFolder = @"\crm\com";
    private const string JobCompletedFolder = @"\crm\com\JobCompletedFolder";
    private readonly string? _environmentFileshare;
    
    private LocationService()
    {
        _environmentFileshare = Environment.GetEnvironmentVariable("FILESHARE");
    }
    
    public string GetBatchJobLocation(string batchJobIdentifier)
    {
        return _environmentFileshare + ComFolder + batchJobIdentifier;
    }

    public string GetJobCompletedFolder(string batchJobIdentifier)
    {
        return _environmentFileshare + JobCompletedFolder + batchJobIdentifier;
    }
}