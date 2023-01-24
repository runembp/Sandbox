using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Tooling.Connector;

namespace SandboxFramework
{
    internal static class Program
    {
        public static async Task Main(string[] args)
        {
            var httpClient = WebApiLogin();
            var apiUrl = "api/data/v8.2/accounts";

            var request = await httpClient.GetStringAsync(apiUrl);
            
        }

        private static HttpClient WebApiLogin()
        {
            var crmOrganizationUrl = Environment.GetEnvironmentVariable("CRM_ORGANIZATIONSERVICE_URL");
            var crmDomain = Environment.GetEnvironmentVariable("DOMAIN");
            var crmUsername = Environment.GetEnvironmentVariable("CRM_USERNAME");
            var crmPassword = Environment.GetEnvironmentVariable("CRM_PASSWORD");

            var httpHandler = new HttpClientHandler
            {
                Credentials = new NetworkCredential(crmUsername, crmPassword, crmDomain),
            };

            var httpClient = new HttpClient(httpHandler);
            httpClient.BaseAddress = new Uri("http://crm.dev1.vlpadr.net/vellivcrm/");

            return httpClient;
        }
        
        private static IOrganizationService ConnectToCrm()
        {
            var crmOrganizationUrl = Environment.GetEnvironmentVariable("CRM_ORGANIZATIONSERVICE_URL");
            var crmDomain = Environment.GetEnvironmentVariable("DOMAIN");
            var crmUsername = Environment.GetEnvironmentVariable("CRM_USERNAME");
            var crmPassword = Environment.GetEnvironmentVariable("CRM_PASSWORD");
            crmOrganizationUrl = "http://crm.dev1.vlpadr.net/Vellivcrm/XRMServices/2011/Organization.svc";

            var connectionString = $"AuthType=AD;Domain={crmDomain};Url={crmOrganizationUrl};Username={crmUsername};Password={crmPassword}";
            return new CrmServiceClient(connectionString);
        }
    }
}