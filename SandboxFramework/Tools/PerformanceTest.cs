using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using DTL.Entities;
using DTL.Entities.Enums;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Messages;
using Microsoft.Xrm.Sdk.Query;
using SandboxFramework.Entities;

namespace SandboxFramework.Tools;

public static class PerformanceTest
{
    public static Tuple<double, double> CreateAndDeleteForEachExecuteMultipleRequest(int batchSize, int amountOfEntities)
    {
        Console.WriteLine($"Started 10x Performance test with ({batchSize}) actions on {amountOfEntities}");


        var list = new List<Tuple<double, double>>();

        for (var methodCounter = 0; methodCounter < 10; methodCounter++)
        {
            var organizationService = OrganizationService.GetOrganizationService();

            var coveragePolicyList = CreateListOfCoveragePolicyEntities(amountOfEntities);

            var sw = Stopwatch.StartNew();

            var executeMultipleRequest = GetExecuteMultipleRequest();

            foreach (var coveragePolicyEntity in coveragePolicyList)
            {
                executeMultipleRequest.Requests.Add(new CreateRequest { Target = coveragePolicyEntity });

                if (executeMultipleRequest.Requests.Count == batchSize)
                {
                    organizationService.Execute(executeMultipleRequest);
                    executeMultipleRequest.Requests.Clear();
                }
            }

            if (executeMultipleRequest.Requests.Count > 0)
            {
                organizationService.Execute(executeMultipleRequest);
                executeMultipleRequest.Requests.Clear();
            }

            var createAps = Math.Round(coveragePolicyList.Count / sw.Elapsed.TotalSeconds, 0);
            var apm = Math.Round(createAps * 60, 0);

            Console.WriteLine($"Done creating! After {sw.Elapsed.TotalSeconds} aps: {createAps}    apm: {apm}");

            var createdEntities = GetExistingCoveragePolicies(organizationService);

            sw.Restart();

            foreach (var coveragePolicyEntity in createdEntities)
            {
                executeMultipleRequest.Requests.Add(new DeleteRequest
                {
                    Target = new EntityReference
                    {
                        LogicalName = CoveragePolicyEntity.EntityLogicalName,
                        Id = coveragePolicyEntity.Id
                    }
                });

                if (executeMultipleRequest.Requests.Count == batchSize)
                {
                    organizationService.Execute(executeMultipleRequest);
                }
            }

            if (executeMultipleRequest.Requests.Count > 0)
            {
                organizationService.Execute(executeMultipleRequest);
                executeMultipleRequest.Requests.Clear();
            }

            var deleteAps = Math.Round(createdEntities.Count / sw.Elapsed.TotalSeconds, 0);
            apm = Math.Round(deleteAps * 60, 0);

            Console.WriteLine($"Done deleting! After {sw.Elapsed.TotalSeconds} aps: {deleteAps}    apm: {apm}");
            Console.WriteLine();

            list.Add(new Tuple<double, double>(createAps, deleteAps));
            Console.WriteLine($"Completed iteration {methodCounter}");
        }

        var item1Avg = list.Average(x => x.Item1);
        var item2Avg = list.Average(x => x.Item2);

        return new Tuple<double, double>(item1Avg, item2Avg);
    }

    private static DataCollection<Entity> GetExistingCoveragePolicies(IOrganizationService organizationService)
    {
        var queryExpression = new QueryExpression
        {
            EntityName = CoveragePolicyEntity.EntityLogicalName,
            ColumnSet = new ColumnSet(CoveragePolicyEntity.FieldId),
        };

        var createdEntities = organizationService.RetrieveMultiple(queryExpression).Entities;
        return createdEntities;
    }

    public static PerformanceDTO CreateAndDeleteParallelExecuteMultiple(int threadCount, int batchSize, int amountOfEntities)
    {
        var createList = new List<double>();
        var deleteList = new List<double>();
        
        for (var i = 0; i < 10; i++)
        {
            Console.WriteLine($"Starting iteration {i} of threadcount: {threadCount}, batchsize: {batchSize}");
            var organizationService = OrganizationService.GetOrganizationService();
            var list = CreateListOfCoveragePolicyEntities(amountOfEntities);

            var createStart = DateTime.Now;

            var parallelOptions = new ParallelOptions
            {
                MaxDegreeOfParallelism = threadCount
            };

            Parallel.ForEach(list.ChunkBy(batchSize), parallelOptions, (chunk, _) =>
            {
                var service = OrganizationService.GetOrganizationService();
                var executeMultiple = GetExecuteMultipleRequest();

                foreach (var coveragePolicyEntity in chunk)
                {
                    executeMultiple.Requests.Add(new CreateRequest { Target = coveragePolicyEntity });
                }

                service.Execute(executeMultiple);
            });

            var createsPerSecond = Math.Round(amountOfEntities / (DateTime.Now - createStart).TotalSeconds, 1);
            Console.WriteLine($"Creates per second: {createsPerSecond}");
            createList.Add(createsPerSecond);

            var createdEntities = GetExistingCoveragePolicies(organizationService);

            Console.WriteLine($"Existing Policies: {createdEntities.Count}");

            var deleteStart = DateTime.Now;

            Parallel.ForEach(createdEntities.ChunkBy(batchSize), parallelOptions, (chunk, _) =>
            {
                var service = OrganizationService.GetOrganizationService();
                var executeMultiple = GetExecuteMultipleRequest();

                foreach (var coveragePolicyEntity in chunk)
                {
                    executeMultiple.Requests.Add(new DeleteRequest()
                    {
                        Target = new EntityReference
                        {
                            LogicalName = CoveragePolicyEntity.EntityLogicalName,
                            Id = coveragePolicyEntity.Id
                        }
                    });
                }

                service.Execute(executeMultiple);
            });

            var deletesPerSecond = Math.Round(createdEntities.Count / (DateTime.Now - deleteStart).TotalSeconds, 1);
            Console.WriteLine($"Delete per second: {deletesPerSecond}");
            deleteList.Add(deletesPerSecond);
        }

        var performance = new PerformanceDTO
        {
            AverageInsert = createList.Average(),
            AverageDelete = deleteList.Average()
        };

        return performance;
    }

    private static List<CoveragePolicyEntity> CreateListOfCoveragePolicyEntities(int amountOfEntities)
    {
        var policy = new CoveragePolicyEntity
        {
            ["new_unique_key"] = "Snoop",
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

        var coveragePolicyList = new List<CoveragePolicyEntity>();

        for (var i = 0; i < amountOfEntities; i++)
        {
            coveragePolicyList.Add(policy);
        }

        return coveragePolicyList;
    }

    private static ExecuteMultipleRequest GetExecuteMultipleRequest()
    {
        var executeMultipleRequest = new ExecuteMultipleRequest
        {
            Requests = new OrganizationRequestCollection(),
            Settings = new ExecuteMultipleSettings
            {
                ContinueOnError = true,
                ReturnResponses = false
            }
        };
        return executeMultipleRequest;
    }
}