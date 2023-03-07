using System;
using System.Collections.Generic;
using DTL.Constants;
using DTL.Entities;
using Microsoft.Xrm.Sdk;

namespace Batch___Framework.Tools;

public static class ListService
{
    public static IEnumerable<CoveragePolicyEntity> GetCoveragePolicyList(int numberOfCoveragePolicies)
    {
        var list = new List<CoveragePolicyEntity>();

        for (var i = 0; i < numberOfCoveragePolicies; i++)
        {
            var policy = new CoveragePolicyEntity
            {
                ["new_unique_key"] = "UniqueKey",
                Product = new EntityReference { Id = new Guid("{D54B0115-1F1C-E711-8100-005056BA6546}") },
                Policy = new EntityReference { Id = new Guid("{D3EC2BE1-B609-DF11-9FCF-005056B155F7}") },
                AccountingUnit = "AccountingUnit",
                CoverageType = OptionSets.CoveragePolicy_CoverageType_Savings,
                Annuity = new Money(123),
                Benefit = new Money(123),
                Expiry = 123,
                CoverageVariantKey = "CoverageVariantKey",
                ProductUniqueKey = "ProductUniqueKey",
                UnderWritingState = OptionSets.CoveragePolicy_UnderwritingState_Accepted,
                TaxCode = "TaxCode",
                State = OptionSets.CoveragePolicy_State_PremiumDemanding,
                BaseBenefit = new Money(123),
                CalculationBasis = "CalculationBasis",
                ChildrensExpiry = "ChildrensExpiry",
                ExpectedPremium = new Money(123),
                CoverageExtent = OptionSets.CoveragePolicy_CoverageExtent_GeneralOffset,
                GuaranteeExpiry = 1,
                IsMandatory = false,
                DisbursementType = OptionSets.CoveragePolicy_DisbursementType_Instalments,
                EstablishmentDate = DateTime.Today,
                InsuranceTerms = "InsuranceTerms",
                StateDate = DateTime.Today,
                SecondInsuredLife = "SecondInsuredLife",
                BenefitCalculationMethod = OptionSets.CoveragePolicy_BenefitCalculationMethod_FixedAmount,
                TotalCustomerPrice = new Money(123),
                CustomerPriceForCoverage = new Money(123),
                DisbursementPlanDisbursementStart = 1,
                HasWaiverOfPremium = false,
                IsDisbursementForEmployer = false,
                PresenceInPensionScheme = OptionSets.CoveragePolicy_PresenceInPensionScheme_Present,
                TotalFirstOrderPrice = new Money(123),
                CustomerPriceForCoverageDiscount = new Money(123),
                CustomerPriceForDWop = new Money(123),
                FirstOrderPriceForCoverage = new Money(123),
                FirstOrderPriceForDWop = new Money(123),
                SumAtRiskUponDisability = new Money(123),
                CustomerPriceForTDWop = new Money(123),
                SumAtRiskUponCriticalIllness = new Money(123),
                PolicyPart = OptionSets.CoveragePolicy_PolicyPart_Mandatory,
                SavingsEnvironment = OptionSets.CoveragePolicy_SavingsEnvironment_CustomerEquity,
                SumAtRiskUponTradeDisability = new Money(123),
                WaiverOfPremiumGrossCalculatedBenefit = new Money(123),
                FirstOrderPriceForTDWop = new Money(123),
                SumAtRiskUponDeathFirstInsured = new Money(123),
                SumAtRiskUponDeathSecondInsured = new Money(123),
                WaiverOfPremiumGrossBenefitFixedAmount = new Money(123),
                WaiverOfPremiumGrossBenefitPercentageOfSalary = 123,
            };
            
            list.Add(policy);
        }

        return list;
    }
}