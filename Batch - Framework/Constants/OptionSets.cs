using Microsoft.Xrm.Sdk;

namespace DTL.Constants
{
    public static class OptionSets
    {
        // Pooling
        public static readonly OptionSetValue Pooling_Level_FrameAgreement = new(100000001);
        public static readonly OptionSetValue Pooling_Status_CopyToFrameAgreement = new(100000004);

        // Pooling Log
        public static readonly OptionSetValue PoolingLog_Status_Subscribed = new(100000000);
        public static readonly OptionSetValue PoolingLog_Status_Unsubscribed = new(100000001);

        // Coverage Policy
        public static readonly OptionSetValue CoveragePolicy_BenefitCalculationMethod_FixedAmount = new(100000000);
        public static readonly OptionSetValue CoveragePolicy_BenefitCalculationMethod_PercentageOfSalary = new(100000001);
        public static readonly OptionSetValue CoveragePolicy_BenefitCalculationMethod_WopFixedAmount = new(100000002);
        public static readonly OptionSetValue CoveragePolicy_BenefitCalculationMethod_WopPercentageOfSalary = new(100000003);
        
        public static readonly OptionSetValue CoveragePolicy_UnderwritingState_Accepted = new(100000000);
        public static readonly OptionSetValue CoveragePolicy_UnderwritingState_AwaitingAssessment = new(100000001);
        
        public static readonly OptionSetValue CoveragePolicy_CoverageExtent_NoDisbursementHalfDisability = new(100000000);
        public static readonly OptionSetValue CoveragePolicy_CoverageExtent_HalfDisbursementHalfDisability = new(100000001);
        public static readonly OptionSetValue CoveragePolicy_CoverageExtent_FullDisbursementHalfDisability = new(100000002);
        public static readonly OptionSetValue CoveragePolicy_CoverageExtent_FlexjobOffset = new(100000003);
        public static readonly OptionSetValue CoveragePolicy_CoverageExtent_GeneralOffset = new(100000004);
        public static readonly OptionSetValue CoveragePolicy_CoverageExtent_FullDisbursementTwoThirdsDisability = new(100000005);
        
        public static readonly OptionSetValue CoveragePolicy_CoverageType_Death = new(100000000);
        public static readonly OptionSetValue CoveragePolicy_CoverageType_Disability = new(100000001);
        public static readonly OptionSetValue CoveragePolicy_CoverageType_CriticalIllness = new(100000002);
        public static readonly OptionSetValue CoveragePolicy_CoverageType_TradeDisability = new(100000003);
        public static readonly OptionSetValue CoveragePolicy_CoverageType_WaiverOfPremiumForDisability = new(100000004);
        public static readonly OptionSetValue CoveragePolicy_CoverageType_WaiverOfPremiumForTradeDisability = new(100000005);
        public static readonly OptionSetValue CoveragePolicy_CoverageType_Savings = new(100000006);
        public static readonly OptionSetValue CoveragePolicy_CoverageType_HealthInsurance = new(100000007);
        
        public static readonly OptionSetValue CoveragePolicy_DisbursementType_Sum = new(100000000);
        public static readonly OptionSetValue CoveragePolicy_DisbursementType_Instalments = new(100000001);
        public static readonly OptionSetValue CoveragePolicy_DisbursementType_ExpiringAnnuity = new(100000002);
        public static readonly OptionSetValue CoveragePolicy_DisbursementType_LifetimeAnnuity = new(100000003);
        public static readonly OptionSetValue CoveragePolicy_DisbursementType_Transfer = new(100000004);
        
        public static readonly OptionSetValue CoveragePolicy_PolicyPart_AMP = new(100000000);
        public static readonly OptionSetValue CoveragePolicy_PolicyPart_Mandatory = new(100000001);
        public static readonly OptionSetValue CoveragePolicy_PolicyPart_Optional = new(100000002);
        public static readonly OptionSetValue CoveragePolicy_PolicyPart_Private = new(100000003);
        
        public static readonly OptionSetValue CoveragePolicy_PresenceInPensionScheme_Present = new(100000000);
        public static readonly OptionSetValue CoveragePolicy_PresenceInPensionScheme_Replaced = new(100000001);
        public static readonly OptionSetValue CoveragePolicy_PresenceInPensionScheme_Removed = new(100000002);
        
        public static readonly OptionSetValue CoveragePolicy_SavingsEnvironment_ContingentMeanInterest = new(100000000);
        public static readonly OptionSetValue CoveragePolicy_SavingsEnvironment_CompanyInvestment = new(100000001);
        public static readonly OptionSetValue CoveragePolicy_SavingsEnvironment_PolicyholderInvestment = new(100000002);
        public static readonly OptionSetValue CoveragePolicy_SavingsEnvironment_CustomerEquity = new(100000003);
        public static readonly OptionSetValue CoveragePolicy_SavingsEnvironment_MeanInterestNoRightOfDisposal = new(100000004);
        
        public static readonly OptionSetValue CoveragePolicy_State_PremiumDemanding = new(100000000);
        public static readonly OptionSetValue CoveragePolicy_State_Inactive = new(100000001);
        public static readonly OptionSetValue CoveragePolicy_State_PendingDelete = new(100000002);
        public static readonly OptionSetValue CoveragePolicy_State_Disbursing = new(100000003);
        public static readonly OptionSetValue CoveragePolicy_State_PremiumWaived = new(100000004);
        public static readonly OptionSetValue CoveragePolicy_State_DisbursingWaiverOfPremium = new(100000005);
        public static readonly OptionSetValue CoveragePolicy_State_IndividualWaiverOfPremium = new(100000006);
        
        

    }
}