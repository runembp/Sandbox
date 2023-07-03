using System;
using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.Configuration.Attributes;
using CsvHelper.TypeConversion;

namespace DTL.DTO
{
    public class CollectiveAgreementsWithLaterTerminationDatesDTO
    {
        public sealed class CollectiveAgreementsWithLaterTerminationDatesDTOMap : ClassMap<CollectiveAgreementsWithLaterTerminationDatesDTO>
        {
            public CollectiveAgreementsWithLaterTerminationDatesDTOMap()
            {
                Map(x => x.Action).Index(0);
                Map(x => x.Account).Index(1);
                Map(x => x.Registration).Index(2).TypeConverter<RegistrationConverter>();
                Map(x => x.CollectiveAgreement).Index(3);
                Map(x => x.TerminationDate).Index(4).TypeConverter<DateTimeConverter>();
            }
        }
        
        public string Action { get; set; }
        public string Account { get; set; }
        public string Registration { get; set; }
        public string CollectiveAgreement { get; set; }
        public DateTime TerminationDate { get; set; }

        [Ignore] public string Name => $"{Registration}-{CollectiveAgreement}-{TerminationDate.ToShortDateString()}";
        [Ignore] public string DataRow { get; set; }
        [Ignore] public Guid? Guid { get; set; }
        [Ignore] public Guid AccountGuid { get; set; }
        [Ignore] public Guid RegistrationGuid { get; set; }
        [Ignore] public Guid CollectiveAgreementGuid { get; set; }
        [Ignore] public Guid DailyJobGuid { get; set; }
    }

    public class RegistrationConverter : DefaultTypeConverter
    {
        public override object ConvertFromString(string text, IReaderRow row, MemberMapData memberMapData)
        {
            const int accountIndex = 1;
            const int registrationIndex = 2;

            var rowArray = row.Parser.RawRecord.Split(';');
            var account = rowArray[accountIndex];
            var registrationId = rowArray[registrationIndex];

            return account + registrationId;
        }        
    }
    
    public class DateTimeConverter : DefaultTypeConverter
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
}