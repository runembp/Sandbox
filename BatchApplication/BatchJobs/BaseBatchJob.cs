using BatchApplication.Services;

namespace BatchApplication.BatchJobs;

public abstract class BaseBatchJob
{
    private LocationService _locationService;

    protected BaseBatchJob(LocationService locationService)
    {
        _locationService = locationService;
    }
}