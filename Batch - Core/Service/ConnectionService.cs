using System.Net;
using Simple.OData.Client;

namespace Batch___Core.Service;

public class ConnectionService
{
    public static IODataClient GetODataClient()
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

        var odataSettings = new ODataClientSettings(httpClient, new Uri(apiUrl, UriKind.Relative))
        {
            IgnoreResourceNotFoundException = true,
            IgnoreUnmappedProperties = true
        };
        
        var directoryInfo = new DirectoryInfo("../../../");
        odataSettings.MetadataDocument = File.ReadAllText(directoryInfo + "$metadata.xml");
        
        // odataSettings.OnTrace = (x, y) => Console.WriteLine(string.Format(x, y));
    
        return new ODataClient(odataSettings);
    } 
}