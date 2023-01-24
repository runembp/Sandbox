using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;
using ProductAtom.Models;

const string csvFile = "PRODUCTATOM.CSV";

using var reader = new StreamReader(csvFile);
var a = new CsvConfiguration(CultureInfo.InvariantCulture)
{
    Delimiter = ";"
};

using var csv = new CsvReader(reader, a);

var records = new List<ProductAtomDTO>();
var records2 = csv.GetRecords<ProductAtomDTO>().ToList();

for (int i = 0; i < 10000; i++)
{
    records.AddRange(records2);
}

var ploicyNumbers = records.Select(x => x.PolicyNumber);

// Get guids from policynumbers using otdataclinet (dictionary)

await Parallel.ForEachAsync(records, async (record, cancellationToken) =>
{
    await ProcessRecord(record);
});

async Task ProcessRecord(ProductAtomDTO productAtomDto)
{
    var _ = productAtomDto.Action switch
    {
        "DELETE" => ProcessDeleteAction(productAtomDto),
        "UPDATE" => ProcessUpdateAction(productAtomDto),
        "INSERT" => ProcessInsertAction(productAtomDto),
        _ => throw new NotImplementedException()
    };
}

Task ProcessInsertAction(ProductAtomDTO productAtomDto1)
{
    throw new NotImplementedException();
}

Task ProcessUpdateAction(ProductAtomDTO productAtomDto)
{
    // Is this a create ? 
    // Call ODataClient with policynumber to get guid. 
    // if guid is null then its a Create action

    throw new NotImplementedException();
}

Task ProcessDeleteAction(ProductAtomDTO productAtomDto)
{
    // find guid in collection of guids


    throw new NotImplementedException();
}

