using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using Microsoft.Xrm.Tooling.Connector;

namespace SandboxFramework
{
    internal static class Program
    {
        public static async Task Main(string[] args)
        {
            var service = ConnectToCrm();

            var thing = service.Retrieve("new_waitinginfo", new Guid("e96d60a7-236b-ed11-aa9f-83c91b559ced"), new ColumnSet());

            
            
            service.Update(thing);
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