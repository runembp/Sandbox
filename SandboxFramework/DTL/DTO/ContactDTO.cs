using System;
using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.Configuration.Attributes;
using CsvHelper.TypeConversion;
using DTL.Constants;

// ReSharper disable IdentifierTypo

namespace DTL.DTO
{
    public class ContactDTO : BaseDTO
    {
        public sealed class ContactDTOMap : ClassMap<ContactDTO>
        {
            public ContactDTOMap()
            {
                Map(x => x.Action).Index(0);
                Map(x => x.UniqueKey).Index(1);
                Map(x => x.FfNr).Index(2);
                Map(x => x.EelektroniskMf).Index(3).TypeConverter<YesNoConverter>();
                Map(x => x.Markedsfoering).Index(4).TypeConverter<MarkedsFoeringsConverter>();
                Map(x => x.CprNo).Index(5).TypeConverter<CprNumberConverter>();
                Map(x => x.FirstName).Index(6);
                Map(x => x.LastName).Index(7);
                Map(x => x.JobTitle).Index(8);
                Map(x => x.PersonStatus).Index(9).TypeConverter<OptionSetConverter>();
                Map(x => x.Gender).Index(10);
                Map(x => x.Birthday).Index(11).TypeConverter<DateTimeConverter>();
                Map(x => x.Arbejdstelefon).Index(12);
                Map(x => x.Privattelefon).Index(13);
                Map(x => x.Mobiltelefon).Index(14);
                Map(x => x.Fax).Index(15);
                Map(x => x.Email).Index(16);
                Map(x => x.Tegnende).Index(17);
                Map(x => x.Role).Index(18);
                Map(x => x.Bemaerk).Index(19);
                Map(x => x.MeNr).Index(20);
                Map(x => x.OrganisationNr).Index(21);
                Map(x => x.AdrType).Index(22);
                Map(x => x.CoNavn).Index(23);
                Map(x => x.UdvalgtKunde).Index(24);
                Map(x => x.FullAddress).Index(25);
                Map(x => x.AdresseBesk).Index(26);
                Map(x => x.Stednavn).Index(27);
                Map(x => x.Postnr).Index(28);
                Map(x => x.Bynavn).Index(29);
                Map(x => x.Landekode).Index(30);
                Map(x => x.Np).Index(31);
                Map(x => x.Pal).Index(32);
                Map(x => x.Civilstand).Index(33);
                Map(x => x.EmailDato).Index(34).TypeConverter<DateTimeConverter>();
                Map(x => x.AppValue).Index(35);
                Map(x => x.AppDate).Index(36).TypeConverter<DateTimeConverter>();
                Map(x => x.AppSource).Index(37);
                Map(x => x.LetterValue).Index(38);
                Map(x => x.LetterDate).Index(39).TypeConverter<DateTimeConverter>();
                Map(x => x.LetterSource).Index(40);
                Map(x => x.SmsValue).Index(41);
                Map(x => x.SmsDate).Index(42).TypeConverter<DateTimeConverter>();
                Map(x => x.SmsSource).Index(43);
                Map(x => x.EmailValue).Index(44);
                Map(x => x.EmailDate).Index(45).TypeConverter<DateTimeConverter>();
                Map(x => x.EmailSource).Index(46);
                Map(x => x.EboksValue).Index(47);
                Map(x => x.EboksDate).Index(48).TypeConverter<DateTimeConverter>();
                Map(x => x.EboksSource).Index(49);
                Map(x => x.TelephoneValue).Index(50);
                Map(x => x.TelephoneDate).Index(51).TypeConverter<DateTimeConverter>();
                Map(x => x.TelephoneSource).Index(52);
                Map(x => x.NetpensionValue).Index(53);
                Map(x => x.NetpensionDate).Index(54).TypeConverter<DateTimeConverter>();
                Map(x => x.NetpensionSource).Index(55);
                Map(x => x.LanguageChoice).Index(56);
                Map(x => x.Etage).Index(57);
                Map(x => x.SideDør).Index(58);
                Map(x => x.SegmentNr).Index(59);
                Map(x => x.DokumentEmail).Index(60);
                Map(x => x.GodkendtDato).Index(61).TypeConverter<DateTimeConverter>();
            }
        }

        public string Action { get; set; }
        public string UniqueKey { get; set; }
        public string FfNr { get; set; }
        public bool EelektroniskMf { get; set; }
        public bool Markedsfoering { get; set; }
        public string CprNo { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string JobTitle { get; set; }
        public int PersonStatus { get; set; }
        public string Gender { get; set; }
        public DateTime? Birthday { get; set; }
        public string Arbejdstelefon { get; set; }
        public string Privattelefon { get; set; }
        public string Mobiltelefon { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public string Tegnende { get; set; }
        public string Role { get; set; }
        public string Bemaerk { get; set; }
        public string MeNr { get; set; }
        public int? OrganisationNr { get; set; }
        public string AdrType { get; set; }
        public string CoNavn { get; set; }
        public string UdvalgtKunde { get; set; }
        public string FullAddress { get; set; }
        public string AdresseBesk { get; set; }
        public string Stednavn { get; set; }
        public string Postnr { get; set; }
        public string Bynavn { get; set; }
        public string Landekode { get; set; }
        public string Np { get; set; }
        public string Pal { get; set; }
        public string Civilstand { get; set; }
        public DateTime? EmailDato { get; set; }
        public string AppValue { get; set; }
        public DateTime? AppDate { get; set; }
        public string AppSource { get; set; }
        public string LetterValue { get; set; }
        public DateTime? LetterDate { get; set; }
        public string LetterSource { get; set; }
        public string SmsValue { get; set; }
        public DateTime? SmsDate { get; set; }
        public string SmsSource { get; set; }
        public string EmailValue { get; set; }
        public DateTime? EmailDate { get; set; }
        public string EmailSource { get; set; }
        public string EboksValue { get; set; }
        public DateTime? EboksDate { get; set; }
        public string EboksSource { get; set; }
        public string TelephoneValue { get; set; }
        public DateTime? TelephoneDate { get; set; }
        public string TelephoneSource { get; set; }
        public string NetpensionValue { get; set; }
        public DateTime? NetpensionDate { get; set; }
        public string NetpensionSource { get; set; }
        public string LanguageChoice { get; set; }
        public string Etage { get; set; }
        public string SideDør { get; set; }
        public string SegmentNr { get; set; }
        public string DokumentEmail { get; set; }
        public DateTime? GodkendtDato { get; set; }

        [Ignore] public string UnformattedCpr => CprNo.Replace("-", string.Empty);
        [Ignore] public string FirstAndLastName => $"{FirstName} {LastName}";
        [Ignore] public bool EmailReflectionValidationOk => IsEmailValid(Email);
        [Ignore] public bool ActivateAccount => PersonStatus > 0;
        [Ignore] public Guid? Guid { get; set; }
        [Ignore] public Guid StaffMemberGuid { get; set; }
        [Ignore] public Guid OrganizationalUnitGuid { get; set; }
        [Ignore] public Guid ContactSegmentGuid { get; set; }

        private class CprNumberConverter : DefaultTypeConverter
        {
            public override object ConvertFromString(string text, IReaderRow row, MemberMapData memberMapData)
            {
                return string.IsNullOrEmpty(text)
                    ? string.Empty
                    : $"{text.Substring(0, 6)}-{text.Substring(6, 4)}";
            }
        }

        private class DateTimeConverter : DefaultTypeConverter
        {
            private const string format = "yyyy-MM-dd";

            public override object ConvertFromString(string text, IReaderRow row, MemberMapData memberMapData)
            {
                if (string.IsNullOrEmpty(text))
                {
                    return null;
                }

                return DateTime.ParseExact(text, format, null);
            }
        }

        private class YesNoConverter : DefaultTypeConverter
        {
            public override object ConvertFromString(string text, IReaderRow row, MemberMapData memberMapData)
            {
                if (string.IsNullOrEmpty(text))
                {
                    return null;
                }

                switch (text)
                {
                    case "J":
                        return true;
                    case "N":
                        return false;
                    default:
                        throw new Exception($"Unknown value in column EELEKTRONISKMF: {text}");
                }
            }
        }

        private class MarkedsFoeringsConverter : DefaultTypeConverter
        {
            public override object ConvertFromString(string text, IReaderRow row, MemberMapData memberMapData)
            {
                if (string.IsNullOrEmpty(text) || !int.TryParse(text, out var numberValue))
                {
                    return null;
                }

                switch (numberValue)
                {
                    case 1:
                        return false;
                    case 2:
                        return false;
                    case 3:
                        return true;
                    default:
                        throw new Exception($"Unknown value in column EELEKTRONISKMF: {text}");
                }
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

                switch (optionSetStringValue)
                {
                    case "00":
                        return ContactOptionSets.StatusCode_PersonStatus_Normal.Value;
                    case "01":
                        return ContactOptionSets.StatusCode_PersonStatus_Disappeared.Value;
                    case "02":
                        return ContactOptionSets.StatusCode_PersonStatus_Disappearance_Cancelled.Value;
                    case "03":
                        return ContactOptionSets.StatusCode_PersonStatus_Dead.Value;
                    case "04":
                        return ContactOptionSets.StatusCode_PersonStatus_Dead_Cancelled.Value;
                    case "05":
                        return ContactOptionSets.StatusCode_PersonStatus_Incapacitated.Value;
                    case "06":
                        return ContactOptionSets.StatusCode_PersonStatus_Incapacitated_Cancelled.Value;
                    case "07":
                        return ContactOptionSets.StatusCode_PersonStatus_Emigrated.Value;
                    case "08":
                        return ContactOptionSets.StatusCode_PersonStatus_Entered.Value;
                    default:
                        throw new Exception($"Bad data found while trying to convert string to OptionSetValue value. Data found in Column {row.CurrentIndex}: {row.Parser.Record[row.CurrentIndex]}");
                }
            }
        }
        
        private static bool IsEmailValid(string email)
        {
            try
            {
                var emailAddress = new System.Net.Mail.MailAddress(email);
                return emailAddress.Address == email;
            }
            catch
            {
                return false;
            }
        }
    }
}