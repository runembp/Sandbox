using BatchApplication.Models;
using BatchApplication.Services;

namespace BatchApplication.BatchJobs;

public class ProductAtomBatchJob
{
    private const string BatchJobIdentifier = "PRODUCTATOM.CSV";
    private string _csvFileLocation;

    public ProductAtomBatchJob(LocationService locationService)
    {
        _csvFileLocation = locationService.GetBatchJobLocation(BatchJobIdentifier);
    }

    public void Setup(List<ProductAtomDTO> productAtoms)
    {
        
        var policyNumbers = productAtoms.Select(x => x.PolicyNumber);
    }

}