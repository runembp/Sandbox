using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.Configuration.Attributes;
using CsvHelper.TypeConversion;
using DTL.Entities.Enums;

namespace DTL.Models;

public class ProductAtomDTO
{
    public sealed class ProductAtomDTOMap : ClassMap<ProductAtomDTO>
    {
        public ProductAtomDTOMap()
        {
            AutoMap(CultureInfo.InvariantCulture);
            Map(x => x.Action).Index(0);
            Map(x => x.PolicyNumber).Index(1).TypeConverter<PolicyNumberConverter<string>>();
            Map(x => x.Coverage).Index(2);
            Map(x => x.CoverageVariantKey).Index(3);
            Map(x => x.AccountingUnit).Index(4);
            Map(x => x.UnderwritingState).Index(5).TypeConverter<EnumConverter<UnderwritingState>>();
            Map(x => x.TaxCode).Index(6);
            Map(x => x.CoverageType).Index(7).TypeConverter<EnumConverter<CoverageType>>();
            Map(x => x.PolicyPart).Index(8).TypeConverter<EnumConverter<PolicyPart>>();
            Map(x => x.EstablishmentDate).Index(9).TypeConverter<DateTimeConverter<string>>();
            Map(x => x.IsMandatory).Index(10).TypeConverter<BooleanConverter<string>>();
            Map(x => x.SavingsEnvironment).Index(11).TypeConverter<EnumConverter<SavingsEnvironment>>();
            Map(x => x.ExpectedPremium).Index(12);
            Map(x => x.InsuranceTerms).Index(13);
            Map(x => x.SecondInsuredLife).Index(14);
            Map(x => x.IsDisbursementForEmployer).Index(15).TypeConverter<BooleanConverter<string>>();
            Map(x => x.BenefitCalculationMethod).Index(16).TypeConverter<EnumConverter<BenefitCalculation>>();
            Map(x => x.CoverageExtent).Index(17).TypeConverter<EnumConverter<CoverageExtent>>();
            Map(x => x.HasWaiverOfPremium).Index(18).TypeConverter<BooleanConverter<string>>();
            Map(x => x.WaiverOfPremiumGrossBenefitPercentageOfSalary).Index(19);
            Map(x => x.WaiverOfPremiumGrossBenefitFixedAmount).Index(20);
            Map(x => x.WaiverOfPremiumGrossCalculatedBenefit).Index(21);
            Map(x => x.DisbursementType).Index(22).TypeConverter<EnumConverter<DisbursementType>>();
            Map(x => x.CalculationBasis).Index(23);
            Map(x => x.Expiry).Index(24);
            Map(x => x.ChildrensExpiry).Index(25);
            Map(x => x.State).Index(26).TypeConverter<EnumConverter<State>>();
            Map(x => x.StateDate).Index(27).TypeConverter<DateTimeConverter<string>>();
            Map(x => x.PresenceInPensionScheme).Index(28).TypeConverter<EnumConverter<PresenceInPensionScheme>>();
            Map(x => x.SumAtRiskUponCriticalIllness).Index(29);
            Map(x => x.SumAtRiskUponDisability).Index(30);
            Map(x => x.SumAtRiskUponTradeDisability).Index(31);
            Map(x => x.SumAtRiskUponDeathFirstInsured).Index(32);
            Map(x => x.SumAtRiskUponDeathSecondInsured).Index(33);
            Map(x => x.TotalFirstOrderPrice).Index(34);
            Map(x => x.FirstOrderPriceForCoverage).Index(35);
            Map(x => x.FirstOrderPriceForDWop).Index(36);
            Map(x => x.FirstOrderPriceForTDWop).Index(37);
            Map(x => x.TotalCustomerPrice).Index(38);
            Map(x => x.CustomerPriceForCoverage).Index(39);
            Map(x => x.CustomerPriceForDWop).Index(40);
            Map(x => x.CustomerPriceForTDWop).Index(41);
            Map(x => x.CustomerPriceForCoverageDiscount).Index(42);
            Map(x => x.Benefit).Index(43);
            Map(x => x.BaseBenefit).Index(44);
            Map(x => x.Annuity).Index(45);
            Map(x => x.DisbursementPlanDisbursementStart).Index(46);
            Map(x => x.GuaranteeExpiry).Index(47);
            Map(x => x.InsuredId).Index(48);
        }
    }

    public string? Action { get; set; }
    public string? PolicyNumber { get; set; }
    public string? Coverage { get; set; }
    public string? CoverageVariantKey { get; set; }
    public string? AccountingUnit { get; set; }
    public UnderwritingState? UnderwritingState { get; set; }
    public string? TaxCode { get; set; }
    public CoverageType? CoverageType { get; set; }
    public PolicyPart? PolicyPart { get; set; }
    public DateTime? EstablishmentDate { get; set; }
    public bool? IsMandatory { get; set; }
    public SavingsEnvironment? SavingsEnvironment { get; set; }
    public decimal? ExpectedPremium { get; set; }
    public string? InsuranceTerms { get; set; }
    public string? SecondInsuredLife { get; set; }
    public bool? IsDisbursementForEmployer { get; set; }
    public BenefitCalculation? BenefitCalculationMethod { get; set; }
    public CoverageExtent? CoverageExtent { get; set; }
    public bool HasWaiverOfPremium { get; set; }
    public double? WaiverOfPremiumGrossBenefitPercentageOfSalary { get; set; }
    public double? WaiverOfPremiumGrossBenefitFixedAmount { get; set; }
    public double? WaiverOfPremiumGrossCalculatedBenefit { get; set; }
    public DisbursementType? DisbursementType { get; set; }
    public string? CalculationBasis { get; set; }
    public decimal? Expiry { get; set; }
    public string? ChildrensExpiry { get; set; }
    public State? State { get; set; }
    public DateTime? StateDate { get; set; }
    public PresenceInPensionScheme? PresenceInPensionScheme { get; set; }
    public decimal? SumAtRiskUponCriticalIllness { get; set; }
    public decimal? SumAtRiskUponDisability { get; set; }
    public decimal? SumAtRiskUponTradeDisability { get; set; }
    public decimal? SumAtRiskUponDeathFirstInsured { get; set; }
    public decimal? SumAtRiskUponDeathSecondInsured { get; set; }
    public decimal? TotalFirstOrderPrice { get; set; }
    public decimal? FirstOrderPriceForCoverage { get; set; }
    public decimal? FirstOrderPriceForDWop { get; set; }
    public decimal? FirstOrderPriceForTDWop { get; set; }
    public decimal? TotalCustomerPrice { get; set; }
    public decimal? CustomerPriceForCoverage { get; set; }
    public decimal? CustomerPriceForDWop { get; set; }
    public decimal? CustomerPriceForTDWop { get; set; }
    public decimal? CustomerPriceForCoverageDiscount { get; set; }
    public decimal? Benefit { get; set; }
    public decimal? BaseBenefit { get; set; }
    public decimal? Annuity { get; set; }
    public int? DisbursementPlanDisbursementStart { get; set; }
    public int? GuaranteeExpiry { get; set; }
    public string? InsuredId { get; set; }
    
    [Ignore]
    public string DataRow { get; set; } 

    [Ignore] public string UniqueKey => PolicyNumber + Coverage + CoverageVariantKey + AccountingUnit + DisbursementPlanDisbursementStart + GuaranteeExpiry;

    [Ignore] public Guid Guid { get; set; } = Guid.Empty;

    [Ignore] public Guid PolicyGuid { get; set; }

    [Ignore] public Guid ProductGuid { get; set; }

    private class PolicyNumberConverter<T> : DefaultTypeConverter
    {
        public override object ConvertFromString(string policyNumber, IReaderRow row, MemberMapData memberMapData)
        {
            return policyNumber.Length == 10
                ? $"{policyNumber[..3]}-{policyNumber[3..]}"
                : $"{policyNumber[..6]}-{policyNumber[6..10]}-{policyNumber[10..]}";
        }
    }

    private class EnumConverter<T> : DefaultTypeConverter where T : struct
    {
        public override object? ConvertFromString(string? enumValue, IReaderRow row, MemberMapData memberMapData)
        {
            if (enumValue == null || enumValue.Equals(string.Empty))
            {
                return null;
            }

            return Enum.Parse<T>(enumValue);
        }
    }

    private class DateTimeConverter<T> : DefaultTypeConverter
    {
        public override object? ConvertFromString(string? datetimeValue, IReaderRow row, MemberMapData memberMapData)
        {
            if (datetimeValue == null || datetimeValue.Equals(string.Empty))
            {
                return null;
            }

            return DateTime.ParseExact(datetimeValue, "dd/MM/yyyy ss:mm:hh", null);
        }
    }

    private class BooleanConverter<T> : DefaultTypeConverter
    {
        public override object? ConvertFromString(string? booleanValue, IReaderRow row, MemberMapData memberMapData)
        {
            if (booleanValue is null || booleanValue.Equals(string.Empty))
            {
                return null;
            }

            return bool.Parse(booleanValue);
        }
    }
}