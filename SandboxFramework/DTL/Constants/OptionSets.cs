using Microsoft.Xrm.Sdk;

namespace DTL.Constants
{
    //TODO Find a better solution for this - this'll be hard to maintain and keep up to date
    public static class OptionSets
    {
        // Pooling
        public static readonly OptionSetValue Pooling_Level_FrameAgreement = new OptionSetValue(100000001);
        public static readonly OptionSetValue Pooling_Status_CopyToFrameAgreement = new OptionSetValue(100000004);

        // Pooling Log
        public static readonly OptionSetValue PoolingLog_Status_Subscribed = new OptionSetValue(100000000);
        public static readonly OptionSetValue PoolingLog_Status_Unsubscribed = new OptionSetValue(100000001);

        // Coverage Policy
        public static readonly OptionSetValue CoveragePolicy_BenefitCalculationMethod_FixedAmount = new OptionSetValue(100000000);
        public static readonly OptionSetValue CoveragePolicy_BenefitCalculationMethod_PercentageOfSalary = new OptionSetValue(100000001);
        public static readonly OptionSetValue CoveragePolicy_BenefitCalculationMethod_WopFixedAmount = new OptionSetValue(100000002);
        public static readonly OptionSetValue CoveragePolicy_BenefitCalculationMethod_WopPercentageOfSalary = new OptionSetValue(100000003);

        public static readonly OptionSetValue CoveragePolicy_UnderwritingState_Accepted = new OptionSetValue(100000000);
        public static readonly OptionSetValue CoveragePolicy_UnderwritingState_AwaitingAssessment = new OptionSetValue(100000001);

        public static readonly OptionSetValue CoveragePolicy_CoverageExtent_NoDisbursementHalfDisability = new OptionSetValue(100000000);
        public static readonly OptionSetValue CoveragePolicy_CoverageExtent_HalfDisbursementHalfDisability = new OptionSetValue(100000001);
        public static readonly OptionSetValue CoveragePolicy_CoverageExtent_FullDisbursementHalfDisability = new OptionSetValue(100000002);
        public static readonly OptionSetValue CoveragePolicy_CoverageExtent_FlexjobOffset = new OptionSetValue(100000003);
        public static readonly OptionSetValue CoveragePolicy_CoverageExtent_GeneralOffset = new OptionSetValue(100000004);
        public static readonly OptionSetValue CoveragePolicy_CoverageExtent_FullDisbursementTwoThirdsDisability = new OptionSetValue(100000005);

        public static readonly OptionSetValue CoveragePolicy_CoverageType_Death = new OptionSetValue(100000000);
        public static readonly OptionSetValue CoveragePolicy_CoverageType_Disability = new OptionSetValue(100000001);
        public static readonly OptionSetValue CoveragePolicy_CoverageType_CriticalIllness = new OptionSetValue(100000002);
        public static readonly OptionSetValue CoveragePolicy_CoverageType_TradeDisability = new OptionSetValue(100000003);
        public static readonly OptionSetValue CoveragePolicy_CoverageType_WaiverOfPremiumForDisability = new OptionSetValue(100000004);
        public static readonly OptionSetValue CoveragePolicy_CoverageType_WaiverOfPremiumForTradeDisability = new OptionSetValue(100000005);
        public static readonly OptionSetValue CoveragePolicy_CoverageType_Savings = new OptionSetValue(100000006);
        public static readonly OptionSetValue CoveragePolicy_CoverageType_HealthInsurance = new OptionSetValue(100000007);
        public static readonly OptionSetValue CoveragePolicy_CoverageType_DisabilitySupplementary = new OptionSetValue(100000008);

        public static readonly OptionSetValue CoveragePolicy_DisbursementType_Sum = new OptionSetValue(100000000);
        public static readonly OptionSetValue CoveragePolicy_DisbursementType_Instalments = new OptionSetValue(100000001);
        public static readonly OptionSetValue CoveragePolicy_DisbursementType_ExpiringAnnuity = new OptionSetValue(100000002);
        public static readonly OptionSetValue CoveragePolicy_DisbursementType_LifetimeAnnuity = new OptionSetValue(100000003);
        public static readonly OptionSetValue CoveragePolicy_DisbursementType_Transfer = new OptionSetValue(100000004);

        public static readonly OptionSetValue CoveragePolicy_PolicyPart_AMP = new OptionSetValue(100000000);
        public static readonly OptionSetValue CoveragePolicy_PolicyPart_Mandatory = new OptionSetValue(100000001);
        public static readonly OptionSetValue CoveragePolicy_PolicyPart_Optional = new OptionSetValue(100000002);
        public static readonly OptionSetValue CoveragePolicy_PolicyPart_Private = new OptionSetValue(100000003);

        public static readonly OptionSetValue CoveragePolicy_PresenceInPensionScheme_Present = new OptionSetValue(100000000);
        public static readonly OptionSetValue CoveragePolicy_PresenceInPensionScheme_Replaced = new OptionSetValue(100000001);
        public static readonly OptionSetValue CoveragePolicy_PresenceInPensionScheme_Removed = new OptionSetValue(100000002);

        public static readonly OptionSetValue CoveragePolicy_SavingsEnvironment_ContingentMeanInterest = new OptionSetValue(100000000);
        public static readonly OptionSetValue CoveragePolicy_SavingsEnvironment_CompanyInvestment = new OptionSetValue(100000001);
        public static readonly OptionSetValue CoveragePolicy_SavingsEnvironment_PolicyholderInvestment = new OptionSetValue(100000002);
        public static readonly OptionSetValue CoveragePolicy_SavingsEnvironment_CustomerEquity = new OptionSetValue(100000003);
        public static readonly OptionSetValue CoveragePolicy_SavingsEnvironment_MeanInterestNoRightOfDisposal = new OptionSetValue(100000004);

        public static readonly OptionSetValue CoveragePolicy_State_PremiumDemanding = new OptionSetValue(100000000);
        public static readonly OptionSetValue CoveragePolicy_State_Inactive = new OptionSetValue(100000001);
        public static readonly OptionSetValue CoveragePolicy_State_PendingDelete = new OptionSetValue(100000002);
        public static readonly OptionSetValue CoveragePolicy_State_Disbursing = new OptionSetValue(100000003);
        public static readonly OptionSetValue CoveragePolicy_State_PremiumWaived = new OptionSetValue(100000004);
        public static readonly OptionSetValue CoveragePolicy_State_DisbursingWaiverOfPremium = new OptionSetValue(100000005);
        public static readonly OptionSetValue CoveragePolicy_State_IndividualWaiverOfPremium = new OptionSetValue(100000006);
    }
}