using System;
using System.Globalization;
using System.Linq;
using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.Configuration.Attributes;
using CsvHelper.TypeConversion;
using DTL.Constants;
using Microsoft.Xrm.Sdk;

namespace DTL.DTO
{
    public class ProductAtomDTO
    {
        public sealed class ProductAtomDTOMap : ClassMap<ProductAtomDTO>
        {
            public ProductAtomDTOMap()
            {
                AutoMap(CultureInfo.InvariantCulture);
                Map(x => x.Action).Index(0);
                Map(x => x.PolicyNumber).Index(1).TypeConverter<PolicyNumberConverter>();
                Map(x => x.Coverage).Index(2);
                Map(x => x.CoverageVariantKey).Index(3);
                Map(x => x.AccountingUnit).Index(4);
                Map(x => x.UnderwritingState).Index(5).TypeConverter<OptionSetConverter>();
                Map(x => x.TaxCode).Index(6);
                Map(x => x.CoverageType).Index(7).TypeConverter<OptionSetConverter>();
                Map(x => x.PolicyPart).Index(8).TypeConverter<OptionSetConverter>();
                Map(x => x.EstablishmentDate).Index(9).TypeConverter<DateTimeConverter>();
                Map(x => x.IsMandatory).Index(10).TypeConverter<BooleanConverter>();
                Map(x => x.SavingsEnvironment).Index(11).TypeConverter<OptionSetConverter>();
                Map(x => x.ExpectedPremium).Index(12).TypeConverter<DecimalConverter>();
                Map(x => x.InsuranceTerms).Index(13);
                Map(x => x.SecondInsuredLife).Index(14);
                Map(x => x.IsDisbursementForEmployer).Index(15).TypeConverter<BooleanConverter>();
                Map(x => x.BenefitCalculationMethod).Index(16).TypeConverter<OptionSetConverter>();
                Map(x => x.CoverageExtent).Index(17).TypeConverter<OptionSetConverter>();
                Map(x => x.HasWaiverOfPremium).Index(18).TypeConverter<BooleanConverter>();
                Map(x => x.WaiverOfPremiumGrossBenefitPercentageOfSalary).Index(19);
                Map(x => x.WaiverOfPremiumGrossBenefitFixedAmount).Index(20);
                Map(x => x.WaiverOfPremiumGrossCalculatedBenefit).Index(21);
                Map(x => x.DisbursementType).Index(22).TypeConverter<OptionSetConverter>();
                Map(x => x.CalculationBasis).Index(23);
                Map(x => x.Expiry).Index(24);
                Map(x => x.ChildrensExpiry).Index(25);
                Map(x => x.State).Index(26).TypeConverter<OptionSetConverter>();
                Map(x => x.StateDate).Index(27).TypeConverter<DateTimeConverter>();
                Map(x => x.PresenceInPensionScheme).Index(28).TypeConverter<OptionSetConverter>();
                Map(x => x.SumAtRiskUponCriticalIllness).Index(29).TypeConverter<DecimalConverter>();
                Map(x => x.SumAtRiskUponDisability).Index(30).TypeConverter<DecimalConverter>();
                Map(x => x.SumAtRiskUponTradeDisability).Index(31).TypeConverter<DecimalConverter>();
                Map(x => x.SumAtRiskUponDeathFirstInsured).Index(32).TypeConverter<DecimalConverter>();
                Map(x => x.SumAtRiskUponDeathSecondInsured).Index(33).TypeConverter<DecimalConverter>();
                Map(x => x.TotalFirstOrderPrice).Index(34).TypeConverter<DecimalConverter>();
                Map(x => x.FirstOrderPriceForCoverage).Index(35).TypeConverter<DecimalConverter>();
                Map(x => x.FirstOrderPriceForDWop).Index(36).TypeConverter<DecimalConverter>();
                Map(x => x.FirstOrderPriceForTDWop).Index(37).TypeConverter<DecimalConverter>();
                Map(x => x.TotalCustomerPrice).Index(38).TypeConverter<DecimalConverter>();
                Map(x => x.CustomerPriceForCoverage).Index(39).TypeConverter<DecimalConverter>();
                Map(x => x.CustomerPriceForDWop).Index(40).TypeConverter<DecimalConverter>();
                Map(x => x.CustomerPriceForTDWop).Index(41).TypeConverter<DecimalConverter>();
                Map(x => x.CustomerPriceForCoverageDiscount).Index(42).TypeConverter<DecimalConverter>();
                Map(x => x.Benefit).Index(43).TypeConverter<DecimalConverter>();
                Map(x => x.BaseBenefit).Index(44).TypeConverter<DecimalConverter>();
                Map(x => x.Annuity).Index(45).TypeConverter<DecimalConverter>();
                Map(x => x.DisbursementPlanDisbursementStart).Index(46);
                Map(x => x.GuaranteeExpiry).Index(47);
                Map(x => x.InsuredId).Index(48);
            }
        }

        public string Action { get; set; }
        public string PolicyNumber { get; set; }
        public string Coverage { get; set; }
        public string CoverageVariantKey { get; set; }
        public string AccountingUnit { get; set; }
        public int? UnderwritingState { get; set; }
        public string TaxCode { get; set; }
        public int? CoverageType { get; set; }
        public int? PolicyPart { get; set; }
        public DateTime? EstablishmentDate { get; set; }
        public bool? IsMandatory { get; set; }
        public int? SavingsEnvironment { get; set; }
        public decimal? ExpectedPremium { get; set; }
        public string InsuranceTerms { get; set; }
        public string SecondInsuredLife { get; set; }
        public bool? IsDisbursementForEmployer { get; set; }
        public int? BenefitCalculationMethod { get; set; }
        public int? CoverageExtent { get; set; }
        public bool? HasWaiverOfPremium { get; set; }
        public double? WaiverOfPremiumGrossBenefitPercentageOfSalary { get; set; }
        public decimal? WaiverOfPremiumGrossBenefitFixedAmount { get; set; }
        public decimal? WaiverOfPremiumGrossCalculatedBenefit { get; set; }
        public int? DisbursementType { get; set; }
        public string CalculationBasis { get; set; }
        public decimal? Expiry { get; set; }
        public string ChildrensExpiry { get; set; }
        public int? State { get; set; }
        public DateTime? StateDate { get; set; }
        public int? PresenceInPensionScheme { get; set; }
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
        public string InsuredId { get; set; }

        [Ignore] public string DataRow { get; set; }

        [Ignore] public string UniqueKey => PolicyNumber + Coverage + CoverageVariantKey + AccountingUnit + DisbursementPlanDisbursementStart + GuaranteeExpiry;

        [Ignore] public Guid? Guid { get; set; }

        [Ignore] public Guid PolicyGuid { get; set; }

        [Ignore] public Guid ProductGuid { get; set; }

        [Ignore] public Guid DailyJobGuid { get; set; }

        private class PolicyNumberConverter : DefaultTypeConverter
        {
            public override object ConvertFromString(string policyNumber, IReaderRow row, MemberMapData memberMapData)
            {
                return policyNumber.Length == 10
                    ? $"{policyNumber.Substring(0, 3)}-{policyNumber.Substring(3)}"
                    : $"{policyNumber.Substring(0, 6)}-{policyNumber.Substring(6, 4)}-{policyNumber.Substring(10)}";
            }
        }

        private class OptionSetConverter : DefaultTypeConverter
        {
            public override object ConvertFromString(string optionSetStringValue, IReaderRow row, MemberMapData memberMapData)
            {
                if (optionSetStringValue == null || optionSetStringValue.Equals(string.Empty))
                {
                    return -1;
                }
                
                try
                {
                    var headerRow = row.HeaderRecord is null
                        ? row.Parser.RawRecord.Split(';')[row.CurrentIndex]
                        : row.HeaderRecord[row.CurrentIndex];

                    var optionSetType = typeof(OptionSets)
                        .GetFields()
                        .Where(x => x.Name.StartsWith("CoveragePolicy"))
                        .Where(x => x.Name.Contains(headerRow))
                        .First(x => x.Name.Contains(optionSetStringValue));

                    return ((OptionSetValue)optionSetType.GetValue(null)).Value;
                }
                catch (Exception)
                {
                    throw new Exception($"Bad data found while trying to convert string to OptionSetValue value. Data found in Column {row.CurrentIndex}: {row.Parser.Record[row.CurrentIndex]}");
                }
            }
        }

        private class DateTimeConverter : DefaultTypeConverter
        {
            public override object ConvertFromString(string datetimeValue, IReaderRow row, MemberMapData memberMapData)
            {
                if (datetimeValue == null || datetimeValue.Equals(string.Empty))
                {
                    return null;
                }

                try
                {
                    return DateTime.ParseExact(datetimeValue, "dd/MM/yyyy ss:mm:hh", null);
                }
                catch (Exception)
                {
                    throw new Exception($"Bad data found while trying to convert DateTime value. Data found in Column {row.CurrentIndex}: {row.Parser.Record[row.CurrentIndex]}");
                }
            }
        }

        private class BooleanConverter : DefaultTypeConverter
        {
            public override object ConvertFromString(string booleanValue, IReaderRow row, MemberMapData memberMapData)
            {
                if (booleanValue is null || booleanValue.Equals(string.Empty))
                {
                    return null;
                }

                return bool.Parse(booleanValue);
            }
        }

        private class DecimalConverter : DefaultTypeConverter
        {
            public override object ConvertFromString(string decimalValue, IReaderRow row, MemberMapData memberMapData)
            {
                if (decimalValue is null || decimalValue.Equals(string.Empty))
                {
                    return null;
                }
                
                try
                {
                    return decimal.Parse(decimalValue, CultureInfo.GetCultureInfo("da-DK"));
                }
                catch (Exception)
                {
                    throw new Exception($"Bad data found while trying to convert decimal value. Data found in Column {row.CurrentIndex}: {row.Parser.Record[row.CurrentIndex]}");
                }
            }
        }
    }
}