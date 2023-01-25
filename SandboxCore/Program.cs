using System.Net;
using DTL.Entities;
using Simple.OData.Client;

var client = WebApiLogin();
var annotations = new ODataFeedAnnotations();

var contactRelations = await client
    .For<ContactRelationEntity>()
    .Count()
    .FindEntriesAsync(annotations);

Console.ReadLine();

static IODataClient WebApiLogin()
{
    const string baseAddress = "http://crm.dev1.vlpadr.net/vellivcrm/";
    const string apiUrl = "api/data/v8.2";
    
    var crmDomain = Environment.GetEnvironmentVariable("DOMAIN");
    var crmUsername = Environment.GetEnvironmentVariable("CRM_USERNAME");
    var crmPassword = Environment.GetEnvironmentVariable("CRM_PASSWORD");

    var httpHandler = new HttpClientHandler
    {
        Credentials = new NetworkCredential(crmUsername, crmPassword, crmDomain),
    };

    var httpClient = new HttpClient(httpHandler)
    {
        BaseAddress = new Uri(baseAddress)
    };

    var odataSettings = new ODataClientSettings(httpClient, new Uri(apiUrl, UriKind.Relative));
    var directoryInfo = new DirectoryInfo("../../../");
    odataSettings.MetadataDocument = File.ReadAllText(directoryInfo + "metadata.xml");
    
    return new ODataClient(odataSettings);
}