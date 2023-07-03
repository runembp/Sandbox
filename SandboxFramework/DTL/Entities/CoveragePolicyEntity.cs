using System;
using System.Reflection;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Client;

namespace DTL.Entities
{
    [EntityLogicalName(EntityLogicalName)]
    public class CoveragePolicyEntity : BaseEntity
    {
        public CoveragePolicyEntity()
        {
            LogicalName = typeof(CoveragePolicyEntity).GetCustomAttribute<EntityLogicalNameAttribute>().LogicalName;
        }
        
        public const string EntityLogicalName = "new_coverage_policy";
        private const string EntityId = "new_coverage_policyid";
        public const string FieldUniqueKey = "new_unique_key";
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

        [AttributeLogicalName(EntityId)]
        public Guid? Guid
        {
            get => Get<Guid?>();
            set => Set(value);
        }
        
        [AttributeLogicalName(FieldUniqueKey)]
        public string UniqueKey
        {
            get => Get<string>();
            set => Set(value);
        }

        [AttributeLogicalName(FieldProductUniqueKey)]
        public string ProductUniqueKey
        {
            get => Get<string>();
            set => Set(value);
        }

        [AttributeLogicalName(FieldProductName)]
        public EntityReference Product
        {
            get => Get<EntityReference>();
            set => Set(value);
        }

        [AttributeLogicalName(FieldPolicy)]
        public EntityReference Policy
        {
            get => Get<EntityReference>();
            set => Set(value);
        }

        [AttributeLogicalName(FieldCoverageVariantKey)]
        public string CoverageVariantKey
        {
            get => Get<string>();
            set => Set(value);
        }

        [AttributeLogicalName(FieldAccountingUnit)]
        public string AccountingUnit
        {
            get => Get<string>();
            set => Set(value);
        }

        [AttributeLogicalName(FieldUnderwritingState)]
        public OptionSetValue UnderWritingState
        {
            get => Get<OptionSetValue>();
            set => Set(value);
        }

        [AttributeLogicalName(FieldTaxCode)]
        public string TaxCode
        {
            get => Get<string>();
            set => Set(value);
        }


        [AttributeLogicalName(FieldCoverageType)]
        public OptionSetValue CoverageType
        {
            get => Get<OptionSetValue>();
            set => Set(value);
        }


        [AttributeLogicalName(FieldPolicyPart)]
        public OptionSetValue PolicyPart
        {
            get => Get<OptionSetValue>();
            set => Set(value);
        }


        [AttributeLogicalName(FieldEstablishmentDate)]
        public DateTime? EstablishmentDate
        {
            get => Get<DateTime?>();
            set => Set(value);
        }


        [AttributeLogicalName(FieldIsMandatory)]
        public bool? IsMandatory
        {
            get => Get<bool?>();
            set => Set(value);
        }


        [AttributeLogicalName(FieldSavingsEnvironment)]
        public OptionSetValue SavingsEnvironment
        {
            get => Get<OptionSetValue>();
            set => Set(value);
        }


        [AttributeLogicalName(FieldExpectedPremium)]
        public Money ExpectedPremium
        {
            get => Get<Money>();
            set => Set(value);
        }

        [AttributeLogicalName(FieldInsuranceTerms)]
        public string InsuranceTerms
        {
            get => Get<string>();
            set => Set(value);
        }


        [AttributeLogicalName(FieldSecondInsuredLife)]
        public string SecondInsuredLife
        {
            get => Get<string>();
            set => Set(value);
        }


        [AttributeLogicalName(FieldIsDisbursementForEmployer)]
        public bool? IsDisbursementForEmployer
        {
            get => Get<bool?>();
            set => Set(value);
        }


        [AttributeLogicalName(FieldBenefitCalculationMethod)]
        public OptionSetValue BenefitCalculationMethod
        {
            get => Get<OptionSetValue>();
            set => Set(value);
        }


        [AttributeLogicalName(FieldCoverageExtent)]
        public OptionSetValue CoverageExtent
        {
            get => Get<OptionSetValue>();
            set => Set(value);
        }


        [AttributeLogicalName(FieldHasWaiverOfPremium)]
        public bool? HasWaiverOfPremium
        {
            get => Get<bool?>();
            set => Set(value);
        }


        [AttributeLogicalName(FieldWaiverOfPremiumGrossBenefitPercentageOfSalary)]
        public double? WaiverOfPremiumGrossBenefitPercentageOfSalary
        {
            get => Get<double?>();
            set => Set(value);
        }


        [AttributeLogicalName(FieldWaiverOfPremiumGrossBenefitFixedAmount)]
        public Money WaiverOfPremiumGrossBenefitFixedAmount
        {
            get => Get<Money>();
            set => Set(value);
        }


        [AttributeLogicalName(FieldWaiverOfPremiumGrossCalculatedBenefit)]
        public Money WaiverOfPremiumGrossCalculatedBenefit
        {
            get => Get<Money>();
            set => Set(value);
        }


        [AttributeLogicalName(FieldDisbursementType)]
        public OptionSetValue DisbursementType
        {
            get => Get<OptionSetValue>();
            set => Set(value);
        }


        [AttributeLogicalName(FieldCalculationBasis)]
        public string CalculationBasis
        {
            get => Get<string>();
            set => Set(value);
        }


        [AttributeLogicalName(FieldExpiry)]
        public decimal? Expiry
        {
            get => Get<decimal?>();
            set => Set(value);
        }


        [AttributeLogicalName(FieldChildrensExpiry)]
        public string ChildrensExpiry
        {
            get => Get<string>();
            set => Set(value);
        }


        [AttributeLogicalName(FieldState)]
        public OptionSetValue State
        {
            get => Get<OptionSetValue>();
            set => Set(value);
        }


        [AttributeLogicalName(FieldStateDate)]
        public DateTime? StateDate
        {
            get => Get<DateTime?>();
            set => Set(value);
        }


        [AttributeLogicalName(FieldPresenceInPensionScheme)]
        public OptionSetValue PresenceInPensionScheme
        {
            get => Get<OptionSetValue>();
            set => Set(value);
        }


        [AttributeLogicalName(FieldSumAtRiskUponCriticalIllness)]
        public Money SumAtRiskUponCriticalIllness
        {
            get => Get<Money>();
            set => Set(value);
        }


        [AttributeLogicalName(FieldSumAtRiskUponDisability)]
        public Money SumAtRiskUponDisability
        {
            get => Get<Money>();
            set => Set(value);
        }


        [AttributeLogicalName(FieldSumAtRiskUponTradeDisability)]
        public Money SumAtRiskUponTradeDisability
        {
            get => Get<Money>();
            set => Set(value);
        }


        [AttributeLogicalName(FieldSumAtRiskUponDeathFirstInsured)]
        public Money SumAtRiskUponDeathFirstInsured
        {
            get => Get<Money>();
            set => Set(value);
        }


        [AttributeLogicalName(FieldSumAtRiskUponDeathSecondInsured)]
        public Money SumAtRiskUponDeathSecondInsured
        {
            get => Get<Money>();
            set => Set(value);
        }

        [AttributeLogicalName(FieldTotalFirstOrderPrice)]
        public Money TotalFirstOrderPrice
        {
            get => Get<Money>();
            set => Set(value);
        }


        [AttributeLogicalName(FieldFirstOrderPriceForCoverage)]
        public Money FirstOrderPriceForCoverage
        {
            get => Get<Money>();
            set => Set(value);
        }


        [AttributeLogicalName(FieldFirstOrderPriceForDWop)]
        public Money FirstOrderPriceForDWop
        {
            get => Get<Money>();
            set => Set(value);
        }


        [AttributeLogicalName(FieldFirstOrderPriceForTDWop)]
        public Money FirstOrderPriceForTDWop
        {
            get => Get<Money>();
            set => Set(value);
        }


        [AttributeLogicalName(FieldTotalCustomerPrice)]
        public Money TotalCustomerPrice
        {
            get => Get<Money>();
            set => Set(value);
        }


        [AttributeLogicalName(FieldCustomerPriceForCoverage)]
        public Money CustomerPriceForCoverage
        {
            get => Get<Money>();
            set => Set(value);
        }


        [AttributeLogicalName(FieldCustomerPriceForDWop)]
        public Money CustomerPriceForDWop
        {
            get => Get<Money>();
            set => Set(value);
        }


        [AttributeLogicalName(FieldCustomerPriceForTDWop)]
        public Money CustomerPriceForTDWop
        {
            get => Get<Money>();
            set => Set(value);
        }


        [AttributeLogicalName(FieldCustomerPriceForCoverageDiscount)]
        public Money CustomerPriceForCoverageDiscount
        {
            get => Get<Money>();
            set => Set(value);
        }


        [AttributeLogicalName(FieldBenefit)]
        public Money Benefit
        {
            get => Get<Money>();
            set => Set(value);
        }


        [AttributeLogicalName(FieldBaseBenefit)]
        public Money BaseBenefit
        {
            get => Get<Money>();
            set => Set(value);
        }

        [AttributeLogicalName(FieldAnnuity)]
        public Money Annuity
        {
            get => Get<Money>();
            set => Set(value);
        }


        [AttributeLogicalName(FieldDisbursementPlanDisbursementStart)]
        public int? DisbursementPlanDisbursementStart
        {
            get => Get<int?>();
            set => Set(value);
        }


        [AttributeLogicalName(FieldGuaranteeExpiry)]
        public int? GuaranteeExpiry
        {
            get => Get<int?>();
            set => Set(value);
        }
    }
}