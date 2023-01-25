namespace BatchApplication.Models;

public class ProductAtomDTO
{
    public string Action { get; set; }
    public string PolicyNumber { get; set; }
    public string Coverage { get; set; }
    public string CoverageVariantKey { get; set; }
    public string AccountingUnit { get; set; }
    public string UnderwritingState { get; set; }
    public string TaxCode { get; set; }
    public string CoverageType { get; set; }
    public string PolicyPart { get; set; }
    public string EstablishmentDate { get; set; }
    public string IsMandatory { get; set; }
    public string SavingsEnvironment { get; set; }
    public string ExpectedPremium { get; set; }
    public string InsuranceTerms { get; set; }
    public string SecondInsuredLife { get; set; }
    public string IsDisbursementForEmployer { get; set; }
    public string BenefitCalculationMethod { get; set; }
    public string CoverageExtent { get; set; }
    public string HasWaiverOfPremium { get; set; }
    public string WaiverOfPremiumGrossBenefitPercentageOfSalary { get; set; }
    public string WaiverOfPremiumGrossBenefitFixedAmount { get; set; }
    public string WaiverOfPremiumGrossCalculatedBenefit { get; set; }
    public string DisbursementType { get; set; }
    public string CalculationBasis { get; set; }
    public string Expiry { get; set; }
    public string ChildrensExpiry { get; set; }
    public string State { get; set; }
    public string StateDate { get; set; }
    public string PresenceInPensionScheme { get; set; }
    public string SumAtRiskUponCriticalIllness { get; set; }
    public string SumAtRiskUponDisability { get; set; }
    public string SumAtRiskUponTradeDisability { get; set; }
    public string SumAtRiskUponDeathFirstInsured { get; set; }
    public string SumAtRiskUponDeathSecondInsured { get; set; }
    public string TotalFirstOrderPrice { get; set; }
    public string FirstOrderPriceForCoverage { get; set; }
    public string FirstOrderPriceForDWop { get; set; }
    public string FirstOrderPriceForTDWop { get; set; }
    public string TotalCustomerPrice { get; set; }
    public string CustomerPriceForCoverage { get; set; }
    public string CustomerPriceForDWop { get; set; }
    public string CustomerPriceForTDWop { get; set; }
    public string CustomerPriceForCoverageDiscount { get; set; }
    public string Benefit { get; set; }
    public string BaseBenefit { get; set; }
    public string Annuity { get; set; }
    public string DisbursementPlanDisbursementStart { get; set; }
    public string GuaranteeExpiry { get; set; }
    public string InsuredId { get; set; }
}