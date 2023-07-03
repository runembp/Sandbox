using System.Globalization;
using CsvHelper.Configuration;

namespace DTL.Utilities
{
    public static class CsvConfigurationUtility
    {
        public static CsvConfiguration GetCsvConfiguration(string delimiter) => new CsvConfiguration(CultureInfo.InvariantCulture)
        {
            Delimiter = delimiter
        };
    }
}