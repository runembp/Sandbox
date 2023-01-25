using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;

namespace BatchApplication.Services;

public static class CsvFileService 
{
    public static CsvReader GetCsvReader(StreamReader streamReader) 
    {
        var csvConfiguration = new CsvConfiguration(CultureInfo.InvariantCulture)
        {
            Delimiter = ";"
        };

        return new CsvReader(streamReader, csvConfiguration);
    }
}