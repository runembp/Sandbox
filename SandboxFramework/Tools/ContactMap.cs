using System;
using System.Collections.Generic;
using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;
using Microsoft.Xrm.Sdk;

namespace SandboxFramework.Tools
{
    public sealed class ContactMap : ClassMap<ContactEntity>
    {
        public ContactMap()
        {
            Map(x => x.FfKey).Name("FF-NR");
            Map(x => x.CprNumber).Name("CPR NO");
            Map(x => x.FirstName).Name("FIRST NAME");
            Map(x => x.LastName).Name("LAST NAME");
            Map(x => x.JobTitle).Name("JOB TITLE");
            Map(x => x.StatusCode).Name("PERSON STATUS").TypeConverter<PersonStatusConverter>();
            // Map(x => x.BirthDate).Name("BIRTHDAY");
            // Map(x => x.Telephone1).Name("ARBEJDSTELEFON");
            // Map(x => x.Telephone2).Name("PRIVATTELEFON");
            // Map(x => x.MobilePhone).Name("MOBILTELEFON");
            // Map(x => x.Email).Name("E-MAIL");
            Map(x => x.AddressTypeCode).Name("ADR_TYPE").TypeConverter<AddressTypeConverter>();
            // Map(x => x.AppDate).Name("APP-DATE");
            // Map(x => x.AppSource).Name("APP-SOURCE");
            // Map(x => x.LetterDate).Name("LETTER-DATE");
            // Map(x => x.LetterSource).Name("LETTER-SOURCE");
            // Map(x => x.SmsDate).Name("SMS-DATE");
            // Map(x => x.SmsSource).Name("SMS-SOURCE");
            // Map(x => x.EmailDate).Name("EMAIL-DATE");
            // Map(x => x.EmailSource).Name("EMAIL-SOURCE");
            // Map(x => x.EboksDate).Name("EBOKS-DATE");
            // Map(x => x.EboksSource).Name("EBOKS-SOURCE");
        }

        private class AddressTypeConverter : DefaultTypeConverter
        {
            public override object ConvertFromString(string columnValue, IReaderRow row, MemberMapData memberMapData)
            {
                var map = new Dictionary<string, OptionSetValue>
                {
                    ["01"] = new OptionSetValue(200001),
                    ["02"] = new OptionSetValue(200002),
                    ["03"] = new OptionSetValue(200003),
                    ["04"] = new OptionSetValue(200004),
                };

                if (map.TryGetValue(columnValue, out var optionSetValue))
                {
                    return optionSetValue;
                }

                throw new Exception("Invalid Person Status Type");
            }
        }

        private class PersonStatusConverter : DefaultTypeConverter
        {
            public override object ConvertFromString(string columnValue, IReaderRow row, MemberMapData memberMapData)
            {
                var map = new Dictionary<string, OptionSetValue>
                {
                    ["00"] = new OptionSetValue(1),
                    ["01"] = new OptionSetValue(200001),
                    ["02"] = new OptionSetValue(200002),
                    ["03"] = new OptionSetValue(200003),
                    ["04"] = new OptionSetValue(200004),
                    ["05"] = new OptionSetValue(200005),
                    ["06"] = new OptionSetValue(200006),
                    ["07"] = new OptionSetValue(200007),
                    ["08"] = new OptionSetValue(200008)
                };

                if (map.TryGetValue(columnValue, out var optionSetValue))
                {
                    return optionSetValue;
                }

                throw new Exception("Invalid Person Status Type");
            }
        }
    }
}