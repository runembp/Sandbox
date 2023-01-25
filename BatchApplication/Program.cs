using System.Reflection;
using BatchApplication.ApplicationConstants;

var batchName = ApplicationConstants.BatchJobs[int.Parse(args[0])];
var assembly = Assembly.GetExecutingAssembly();
var type = assembly.GetTypes().First(x => x.Name == batchName);
Activator.CreateInstance(type);

// Get guids from policynumbers using otdataclinet (dictionary)
//
// await Parallel.ForEachAsync(records, async (record, cancellationToken) =>
// {
//     await ProcessRecord(record);
// });
//
// async Task ProcessRecord(ProductAtomDTO productAtomDto)
// {
//     var _ = productAtomDto.Action switch
//     {
//         "DELETE" => ProcessDeleteAction(productAtomDto),
//         "UPDATE" => ProcessUpdateAction(productAtomDto),
//         "INSERT" => ProcessInsertAction(productAtomDto),
//         _ => throw new NotImplementedException()
//     };
// }
//
// Task ProcessInsertAction(ProductAtomDTO productAtomDto1)
// {
//     throw new NotImplementedException();
// }
//
// Task ProcessUpdateAction(ProductAtomDTO productAtomDto)
// {
//     // Is this a create ? 
//     // Call ODataClient with policynumber to get guid. 
//     // if guid is null then its a Create action
//
//     throw new NotImplementedException();
// }
//
// Task ProcessDeleteAction(ProductAtomDTO productAtomDto)
// {
//     // find guid in collection of guids
//
//
//     throw new NotImplementedException();
// }
//
