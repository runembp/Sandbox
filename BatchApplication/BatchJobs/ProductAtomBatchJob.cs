using System.Globalization;
using BatchApplication.Models;
using BatchApplication.Services;
using CsvHelper;
using CsvHelper.Configuration;
using DTL.Entities;
using Simple.OData.Client;

namespace BatchApplication.BatchJobs;

public class ProductAtomBatchJob
{
    private const string BatchJobIdentifier = "666_ProductAtom";

    public ProductAtomBatchJob()
    {
        ReadCsvFiles();
    }

    private static void ReadCsvFiles()
    {
        var productAtomCsvFiles = Directory.GetFiles(LocationService.GetBatchJobLocation(BatchJobIdentifier)).Where(x => x.Contains(BatchJobIdentifier));

        foreach (var csvFile in productAtomCsvFiles)
        {
            var csvConfiguration = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                Delimiter = ";"
            };

            using var streamReader = new StreamReader(csvFile);
            using var csvReader = new CsvReader(streamReader, csvConfiguration);

            var productAtoms = csvReader.GetRecords<ProductAtomDTO>().ToList();

            ProcessProductAtoms(productAtoms);
            //TODO MoveToCompletedFolder();
        }
    }

    private static async void ProcessProductAtoms(IEnumerable<ProductAtomDTO> productAtoms)
    {
        var policyNumbers = productAtoms.Select(x => x.PolicyNumber);
        var policyNumberGuids = new Dictionary<string, Guid>();

        var client = ConnectionService.GetODataClient();

        var filter = new ODataExpression<PolicyEntity>(x => x.PolicyNumber == policyNumbers.First());

        foreach (var policyNumber in policyNumbers)
        {
            filter = filter || new ODataExpression<PolicyEntity>(x => x.PolicyNumber == policyNumber);
        }

        var query = client.For<PolicyEntity>();
        foreach (var policyNumber in policyNumbers)
        {
            query.Filter(x => x.PolicyNumber == policyNumber);
        }
        var contactRelations = await query.FindEntriesAsync();
    }
}