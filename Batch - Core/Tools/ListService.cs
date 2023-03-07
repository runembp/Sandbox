using DTL.Entities;
using DTL.Entities.Enums;

namespace Batch___Core.Tools;

public abstract class ListService
{
    public static IEnumerable<CoveragePolicyEntity> GetCoveragePolicyList(int numberOfEntities = 1000)
    {
        var coveragePolicyList = new List<CoveragePolicyEntity>();
        
        var productGuid = new Guid("e970777f-0977-e011-844a-005056b155f7");
        var policyGuid = new Guid("3c0c8a5e-2099-df11-803c-005056b155f7");
        
        for(var i = 0; i < numberOfEntities; i++)
        {
            // Add 1000 coverage policies to the list with every field populated
            coveragePolicyList.Add(new CoveragePolicyEntity
            {
                    Id = Guid.NewGuid(),
                    UniqueKey = "productAtom.UniqueKey",
                    ProductUniqueKey = "productAtom.UniqueKey",
                    Policy = new PolicyEntity { Id = policyGuid },
                    Product = new ProductEntity { Id = productGuid },
                    CoverageVariantKey = "productAtom.CoverageVariantKey",
                    AccountingUnit = "productAtom.AccountingUnit",
                    UnderWritingState = UnderwritingState.Accepted,
                    TaxCode = "productAtom.TaxCode",
                    CoverageType = CoverageType.HealthInsurance,
                    PolicyPart = PolicyPart.Optional,
                    EstablishmentDate = DateTime.Now,
                    IsMandatory = false,
                    SavingsEnvironment = SavingsEnvironment.PolicyholderInvestment,
                    ExpectedPremium = 1234,
                    InsuranceTerms = "productAtom.InsuranceTerms",
                    SecondInsuredLife = "productAtom.SecondInsuredLife",
                    IsDisbursementForEmployer = false,
                    BenefitCalculationMethod = BenefitCalculation.FixedAmount,
                    CoverageExtent = CoverageExtent.GeneralOffset,
                    HasWaiverOfPremium = false, 
                    WaiverOfPremiumGrossBenefitPercentageOfSalary = 10,
                    WaiverOfPremiumGrossBenefitFixedAmount = 123,
                    WaiverOfPremiumGrossCalculatedBenefit = 123,
                    DisbursementType = DisbursementType.Instalments,
                    CalculationBasis = "productAtom.CalculationBasis",
                    Expiry = 123,
                    ChildrensExpiry = "productAtom.ChildrensExpiry",
                    State = State.Disbursing,
                    StateDate = DateTime.Now,
                    PresenceInPensionScheme = PresenceInPensionScheme.Present,
                    SumAtRiskUponCriticalIllness = 123,
                    SumAtRiskUponDisability = 123,
                    SumAtRiskUponTradeDisability = 123,
                    SumAtRiskUponDeathFirstInsured = 123,
                    SumAtRiskUponDeathSecondInsured = 123,
                    TotalFirstOrderPrice = 123,
                    FirstOrderPriceForCoverage = 123,
                    FirstOrderPriceForDWop = 123,
                    FirstOrderPriceForTDWop = 123,
                    TotalCustomerPrice = 123,
                    CustomerPriceForCoverage = 123,
                    CustomerPriceForDWop = 123,
                    CustomerPriceForTDWop = 123,
                    CustomerPriceForCoverageDiscount = 123,
                    Benefit = 123,
                    BaseBenefit = 123,
                    Annuity = 123,
                    DisbursementPlanDisbursementStart = -1,
                    GuaranteeExpiry = 123,
            });
        }

        return coveragePolicyList;
    }
}