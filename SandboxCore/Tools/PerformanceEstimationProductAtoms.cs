using System.Diagnostics;
using DTL.Entities;
using DTL.Entities.Enums;
using Simple.OData.Client;

namespace SandboxCore.Tools;

public class PerformanceEstimationProductAtoms
{
    private const int ThreadCount = 4;
    private const int ChunkSize = 1000;
    
    public static async Task PerformanceTesting()
    {
        var client = WebApiClient.GetClient();
        

        var list = await client.For<CoveragePolicyEntity>().Select(x => x.Id).FindEntriesAsync();
        
        // var parallelOptions = new ParallelOptions
        // {
        //     MaxDegreeOfParallelism = ThreadCount
        // };

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

        var sw = new Stopwatch();
        sw.Start();
        
        foreach (var chunk in coveragePolicyList.Chunk(1000))
        {
            var threadStopWatch = Stopwatch.StartNew();
            var insertBatch = new ODataBatch(client);

            foreach (var policy in chunk)
            {
                insertBatch += oDataClient => oDataClient.For<CoveragePolicyEntity>().Set(policy).InsertEntryAsync();
            }

            insertBatch.ExecuteAsync();
            var after = threadStopWatch.Elapsed.TotalSeconds;

            Console.WriteLine($"Inserted {chunk.Length} in {after} seconds");
        }
        

        // await Parallel.ForEachAsync(coveragePolicyList.Chunk(ChunkSize), async (chunk, _) =>
        // {
        //     var insertBatch = new ODataBatch(client);
        //
        //     foreach (var policy in chunk)
        //     {
        //         insertBatch += oDataClient => oDataClient.For<CoveragePolicyEntity>().Set(policy).InsertEntryAsync();
        //     }
        //
        //     var before = new ThreadLocal<double>(() => sw.Elapsed.TotalSeconds);
        //     await insertBatch.ExecuteAsync(_);
        //     var after = new ThreadLocal<double>(() => sw.Elapsed.TotalSeconds);
        //
        //     Console.WriteLine($"Deleted {ChunkSize} in {after.Value - before.Value} seconds");
        // });

        Console.WriteLine($"Estimation: {Math.Round(coveragePolicyList.Count / (sw.Elapsed.TotalSeconds / 60), 0)} records inserted per minute");

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

        await Parallel.ForEachAsync(existing.Chunk(ChunkSize), async (chunk, _) =>
        {
            var deleteBatch = new ODataBatch(client);

            foreach (var coveragePolicy in chunk)
            {
                deleteBatch += odataClient => odataClient.For<CoveragePolicyEntity>().Key(coveragePolicy.Id).DeleteEntryAsync();
            }

            var before = sw.Elapsed.TotalSeconds;
            await deleteBatch.ExecuteAsync(_);
            var after = sw.Elapsed.TotalSeconds;

            Console.WriteLine($"Deleted {ChunkSize} in {after - before} seconds");
        });

        Console.WriteLine();

        Console.WriteLine($"Estimation: {Math.Round(existing.Count / (sw.Elapsed.TotalSeconds / 60), 0)} records deleted per minute ");
    }
}