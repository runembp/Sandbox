using System.Diagnostics;
using System.Net;
using DTL.Entities;
using DTL.Entities.Enums;
using Simple.OData.Client;

ThreadPool.SetMinThreads(100, 100);
ServicePointManager.DefaultConnectionLimit = 65000;
ServicePointManager.Expect100Continue = false;
ServicePointManager.UseNagleAlgorithm = false;

const int insertThreads = 4;
const int insertChunkSize = 100;

const int deleteThreads = 4;
const int deleteChunkSize = 100;

var client = WebApiLogin();

var insertParallelOptions = new ParallelOptions
{
    MaxDegreeOfParallelism = insertThreads
};

var existingCoverages = await client.For<CoveragePolicyEntity>().Filter(x => x.UniqueKey == "Snoop").Select(x => x.Id).FindEntriesAsync();
Console.WriteLine($"Existing policies: {existingCoverages.Count()}");

var sw = new Stopwatch();
sw.Start();


var coveragePolicyList = new List<CoveragePolicyEntity>();

for (var i = 0; i < 2000; i++)
{
    var policy = new CoveragePolicyEntity
    {
        Id = Guid.NewGuid(),
        UniqueKey = "Snoop",
        AccountingUnit = "Snoop",
        CoverageType = CoverageType.Death,
        Annuity = 123,
        Benefit = 123,
        Expiry = 123,
        CoverageVariantKey = "Snoop",
        ProductUniqueKey = "Snoop",
        UnderWritingState = UnderwritingState.Accepted,
        TaxCode = "snoop",
        State = State.Inactive,
        BaseBenefit = 123,
        CalculationBasis = "Snoop",
        ChildrensExpiry = "Snoop",
        ExpectedPremium = 123,
        CoverageExtent = CoverageExtent.FlexjobOffset,
        GuaranteeExpiry = 1,
        IsMandatory = false,
        DisbursementType = DisbursementType.Instalments,
        EstablishmentDate = DateTime.Today,
        InsuranceTerms = "Snoop",
        StateDate = DateTime.Today,
        SecondInsuredLife = "Snoop",
        BenefitCalculationMethod = BenefitCalculation.FixedAmount,
        TotalCustomerPrice = 123,
        CustomerPriceForCoverage = 123,
        DisbursementPlanDisbursementStart = 1,
        HasWaiverOfPremium = false,
        IsDisbursementForEmployer = false,
        PresenceInPensionScheme = PresenceInPensionScheme.Present,
        TotalFirstOrderPrice = 123,
        CustomerPriceForCoverageDiscount = 123,
        CustomerPriceForDWop = 123,
        FirstOrderPriceForCoverage = 123,
        FirstOrderPriceForDWop = 123,
        SumAtRiskUponDisability = 123,
        CustomerPriceForTDWop = 123,
        SumAtRiskUponCriticalIllness = 123,
        PolicyPart = PolicyPart.Mandatory,
        SavingsEnvironment = SavingsEnvironment.CompanyInvestment,
        SumAtRiskUponTradeDisability = 123,
        WaiverOfPremiumGrossCalculatedBenefit = 123,
        FirstOrderPriceForTDWop = 123,
        SumAtRiskUponDeathFirstInsured = 123,
        SumAtRiskUponDeathSecondInsured = 123,
        WaiverOfPremiumGrossBenefitFixedAmount = 123,
        WaiverOfPremiumGrossBenefitPercentageOfSalary = 123,
        Product = new ProductEntity { Id = new Guid("{D54B0115-1F1C-E711-8100-005056BA6546}") },
        Policy = new PolicyEntity { Id = new Guid("{D3EC2BE1-B609-DF11-9FCF-005056B155F7}") }
    };

    coveragePolicyList.Add(policy);
}

Console.Write("#");

var deleteParallelOptions = new ParallelOptions
{
    MaxDegreeOfParallelism = deleteThreads
};

// await Parallel.ForEachAsync(coveragePolicyList.Chunk(deleteChunkSize), deleteParallelOptions, async (chunk, _) =>
// {
//     var elapsedSoFar = sw.Elapsed.TotalSeconds;
//     var insertBatch = new ODataBatch(client);
//
//     foreach (var policy in chunk)
//     {
//         insertBatch += oDataClient => oDataClient.For<CoveragePolicyEntity>().Set(policy).InsertEntryAsync();
//     }
//
//     await insertBatch.ExecuteAsync(_);
//
//     var chunkTime = (sw.Elapsed.TotalSeconds - elapsedSoFar) / 60;
//
//     // Console.WriteLine($"Inserted: {Math.Round(chunk.Length / (chunkTime / 60), 0)}");
//
//
//     Console.Write("-");
// });
//
// Console.WriteLine();
// Console.WriteLine($"Estimation: {Math.Round(coveragePolicyList.Count / (sw.Elapsed.TotalSeconds / 60), 0)} records inserted per minute");


var annotations = new ODataFeedAnnotations();

var existing = client.For<CoveragePolicyEntity>()
    .Filter(x => x.UniqueKey == "Snoop")
    .Select(x => x.Id)
    .FindEntriesAsync(annotations)
    .Result
    .ToList();

while (annotations.NextPageLink != null)
{
    existing.AddRange(await client
        .For<CoveragePolicyEntity>()
        .FindEntriesAsync(annotations.NextPageLink, annotations));
}

sw.Restart();

Console.Write("#");
await Parallel.ForEachAsync(existing.Chunk(insertChunkSize), insertParallelOptions, async (chunk, _) =>
{
    var elapsedSoFar = sw.Elapsed.TotalSeconds;

    var deleteBatch = new ODataBatch(client);

    foreach (var coveragePolicy in chunk)
    {
        deleteBatch += odataClient => odataClient.For<CoveragePolicyEntity>().Key(coveragePolicy.Id).DeleteEntryAsync();
    }

    await deleteBatch.ExecuteAsync(_);
    // Console.WriteLine($"Deleted: {Math.Round(chunk.Length / (sw.Elapsed.TotalSeconds - elapsedSoFar / 60), 0)} rpm");
    Console.Write("-");
});
Console.WriteLine();

Console.WriteLine($"Estimation: {Math.Round(existing.Count / (sw.Elapsed.TotalSeconds / 60), 0)} records deleted per minute ");

Console.WriteLine("----------------------------------------------------------");

static IODataClient WebApiLogin()
{
    const string baseAddress = "http://crm.dev1.vlpadr.net/vellivcrm/";
    const string apiUrl = "api/data/v8.2";

    var crmDomain = Environment.GetEnvironmentVariable("DOMAIN");
    var crmUsername = Environment.GetEnvironmentVariable("CRM_USERNAME");
    var crmPassword = Environment.GetEnvironmentVariable("CRM_PASSWORD");

    var httpHandler = new HttpClientHandler
    {
        Credentials = new NetworkCredential(crmUsername, crmPassword, crmDomain),
        UseCookies = false
    };

    var httpClient = new HttpClient(httpHandler)
    {
        BaseAddress = new Uri(baseAddress),
    };

    var odataSettings = new ODataClientSettings(httpClient, new Uri(apiUrl, UriKind.Relative));
    var directoryInfo = new DirectoryInfo("../../../");
    odataSettings.MetadataDocument = File.ReadAllText(directoryInfo + "metadata.xml");
    odataSettings.IgnoreResourceNotFoundException = true;

    return new ODataClient(odataSettings);
}