using System;
using System.ComponentModel.DataAnnotations.Schema;
using DTL.Entities.Enums;

namespace DTL.Entities
{
    [Table(LogicalName)]
    public class CoveragePolicyEntity : BaseEntity
    {
        private const string LogicalName = "new_coverage_policy";

        private const string FieldId = "new_coverage_policyid";
        private const string FieldUniqueKey = "new_unique_key";
        private const string FieldProductUniqueKey = "new_product";
        private const string FieldProductName = "new_productnameid";
        private const string FieldPolicy = "new_policyid";
        private const string FieldCoverageVariantKey = "new_productvariationn16";
        private const string FieldAccountingUnit = "new_accountingunit";
        private const string FieldUnderwritingState = "new_underwritingstate";
        private const string FieldTaxCode = "new_taxcode";
        private const string FieldCoverageType = "new_coveragetype";
        private const string FieldPolicyPart = "new_policypart";
        private const string FieldEstablishmentDate = "new_establishmentdate";
        private const string FieldIsMandatory = "new_mandatory";
        private const string FieldSavingsEnvironment = "new_savingsenvironment";
        private const string FieldExpectedPremium = "new_expectedpremium";
        private const string FieldInsuranceTerms = "new_insuranceterms";
        private const string FieldSecondInsuredLife = "new_secondinsuredlife";
        private const string FieldIsDisbursementForEmployer = "new_isdisbursementforemployer";
        private const string FieldBenefitCalculationMethod = "new_benefitcalculationmethod";
        private const string FieldCoverageExtent = "new_coverageextent";
        private const string FieldHasWaiverOfPremium = "new_haswaiverofpremium";
        private const string FieldWaiverOfPremiumGrossBenefitPercentageOfSalary = "new_waiverofpremiumgrossbenefitpercentageos";
        private const string FieldWaiverOfPremiumGrossBenefitFixedAmount = "new_waiverofpremiumgrossbenefitfixedamount";
        private const string FieldWaiverOfPremiumGrossCalculatedBenefit = "new_waiverofpremiumgrosscalculatedbenefit";
        private const string FieldDisbursementType = "new_disbursementtype";
        private const string FieldCalculationBasis = "new_calculationbasis";
        private const string FieldExpiry = "new_expire";
        private const string FieldChildrensExpiry = "new_childrensexpiry";
        private const string FieldState = "new_state";
        private const string FieldStateDate = "new_statedate";
        private const string FieldPresenceInPensionScheme = "new_presenceinpensionscheme";
        private const string FieldSumAtRiskUponCriticalIllness = "new_sumatriskuponcriticalillness";
        private const string FieldSumAtRiskUponDisability = "new_sumatriskupondisability";
        private const string FieldSumAtRiskUponTradeDisability = "new_sumatriskupontradedisability";
        private const string FieldSumAtRiskUponDeathFirstInsured = "new_sumatriskupondeathfirstinsured";
        private const string FieldSumAtRiskUponDeathSecondInsured = "new_sumatriskupondeathsecondinsured";
        private const string FieldTotalFirstOrderPrice = "new_totalfirstorderprice";
        private const string FieldFirstOrderPriceForCoverage = "new_firstorderpriceforcoverage";
        private const string FieldFirstOrderPriceForDWop = "new_firstorderpricefordwop";
        private const string FieldFirstOrderPriceForTDWop = "new_firstorderpricefortdwop";
        private const string FieldTotalCustomerPrice = "new_totalcustomerprice";
        private const string FieldCustomerPriceForCoverage = "new_customerpriceforcoverage";
        private const string FieldCustomerPriceForDWop = "new_customerpricefordwop";
        private const string FieldCustomerPriceForTDWop = "new_customerpricefortdwop";
        private const string FieldCustomerPriceForCoverageDiscount = "new_customerpriceforcoveragediscount";
        private const string FieldBenefit = "new_benefit";
        private const string FieldBaseBenefit = "new_basebenefit";
        private const string FieldAnnuity = "new_annuity";
        private const string FieldDisbursementPlanDisbursementStart = "new_disbursementplandisbursementstart";
        private const string FieldGuaranteeExpiry = "new_guaranteeexpiry";
        
        [Column(FieldId)]
        public Guid Id { get; set; }
        
        [Column(FieldUniqueKey)]
        public string? UniqueKey { get; set; }
        
        [Column(FieldProductUniqueKey)]
        public string? ProductUniqueKey { get; set; }

        [Column(FieldProductName)]
        public ProductEntity? Product { get; set; }
        
        [Column(FieldPolicy)]
        public PolicyEntity? Policy { get; set; }

        [Column(FieldCoverageVariantKey)]
        public string? CoverageVariantKey { get; set; }

        [Column(FieldAccountingUnit)]
        public string? AccountingUnit { get; set; }

        [Column(FieldUnderwritingState)]
        public UnderwritingState? UnderWritingState { get; set; }

        [Column(FieldTaxCode)]
        public string? TaxCode { get; set; }

        [Column(FieldCoverageType)]
        public CoverageType? CoverageType { get; set; }

        [Column(FieldPolicyPart)]
        public PolicyPart? PolicyPart { get; set; }

        [Column(FieldEstablishmentDate)]
        public DateTime? EstablishmentDate { get; set; }

        [Column(FieldIsMandatory)]
        public bool? IsMandatory { get; set; }
        
        [Column(FieldSavingsEnvironment)]
        public SavingsEnvironment? SavingsEnvironment { get; set; }
        
        [Column(FieldExpectedPremium)]
        public decimal? ExpectedPremium { get; set; }
        
        [Column(FieldInsuranceTerms)]
        public string? InsuranceTerms { get; set; }
        
        [Column(FieldSecondInsuredLife)]
        public string? SecondInsuredLife { get; set; }
        
        [Column(FieldIsDisbursementForEmployer)]
        public bool? IsDisbursementForEmployer { get; set; }
        
        [Column(FieldBenefitCalculationMethod)]
        public BenefitCalculation? BenefitCalculationMethod { get; set; }
        
        [Column(FieldCoverageExtent)]
        public CoverageExtent? CoverageExtent { get; set; }
        
        [Column(FieldHasWaiverOfPremium)]
        public bool? HasWaiverOfPremium { get; set; }
        
        [Column(FieldWaiverOfPremiumGrossBenefitPercentageOfSalary)]
        public double? WaiverOfPremiumGrossBenefitPercentageOfSalary { get; set; }
        
        [Column(FieldWaiverOfPremiumGrossBenefitFixedAmount)]
        public double? WaiverOfPremiumGrossBenefitFixedAmount { get; set; }
        
        [Column(FieldWaiverOfPremiumGrossCalculatedBenefit)]
        public double? WaiverOfPremiumGrossCalculatedBenefit { get; set; }
        
        [Column(FieldDisbursementType)]
        public DisbursementType? DisbursementType { get; set; }
        
        [Column(FieldCalculationBasis)]
        public string? CalculationBasis { get; set; }
        
        [Column(FieldExpiry)]
        public decimal? Expiry { get; set; }
        
        [Column(FieldChildrensExpiry)]
        public string? ChildrensExpiry { get; set; }
        
        [Column(FieldState)]
        public State? State { get; set; }
        
        [Column(FieldStateDate)]
        public DateTime? StateDate { get; set; }
        
        [Column(FieldPresenceInPensionScheme)]
        public PresenceInPensionScheme? PresenceInPensionScheme { get; set; }
        
        [Column(FieldSumAtRiskUponCriticalIllness)]
        public decimal? SumAtRiskUponCriticalIllness { get; set; }
        
        [Column(FieldSumAtRiskUponDisability)]
        public decimal? SumAtRiskUponDisability { get; set; }
        
        [Column(FieldSumAtRiskUponTradeDisability)]
        public decimal? SumAtRiskUponTradeDisability { get; set; }
        
        [Column(FieldSumAtRiskUponDeathFirstInsured)]
        public decimal? SumAtRiskUponDeathFirstInsured { get; set; }
        
        [Column(FieldSumAtRiskUponDeathSecondInsured)]
        public decimal? SumAtRiskUponDeathSecondInsured { get; set; }
        
        [Column(FieldTotalFirstOrderPrice)]
        public decimal? TotalFirstOrderPrice { get; set; }
        
        [Column(FieldFirstOrderPriceForCoverage)]
        public decimal? FirstOrderPriceForCoverage { get; set; }
        
        [Column(FieldFirstOrderPriceForDWop)]
        public decimal? FirstOrderPriceForDWop { get; set; }
        
        [Column(FieldFirstOrderPriceForTDWop)]
        public decimal? FirstOrderPriceForTDWop { get; set; }
        
        [Column(FieldTotalCustomerPrice)]
        public decimal? TotalCustomerPrice { get; set; }
        
        [Column(FieldCustomerPriceForCoverage)]
        public decimal? CustomerPriceForCoverage { get; set; }
        
        [Column(FieldCustomerPriceForDWop)]
        public decimal? CustomerPriceForDWop { get; set; }
        
        [Column(FieldCustomerPriceForTDWop)]
        public decimal? CustomerPriceForTDWop { get; set; }
        
        [Column(FieldCustomerPriceForCoverageDiscount)]
        public decimal? CustomerPriceForCoverageDiscount { get; set; }
        
        [Column(FieldBenefit)]
        public decimal? Benefit { get; set; }
        
        [Column(FieldBaseBenefit)]
        public decimal? BaseBenefit { get; set; }
        
        [Column(FieldAnnuity)]
        public decimal? Annuity { get; set; }
        
        [Column(FieldDisbursementPlanDisbursementStart)]
        public int? DisbursementPlanDisbursementStart { get; set; }
        
        [Column(FieldGuaranteeExpiry)]
        public int? GuaranteeExpiry { get; set; }
    }
}