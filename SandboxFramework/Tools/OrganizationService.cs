using System;
using System.ServiceModel.Description;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Client;

namespace SandboxFramework.Tools
{
    public static class OrganizationService
    {
        public static IOrganizationService GetOrganizationServiceInTest()
        {
            var crmOrganizationUrl = Environment.GetEnvironmentVariable("CRM_ORGANIZATIONSERVICE_URL");
            var crmDomain = Environment.GetEnvironmentVariable("DOMAIN");
            var crmUsername = Environment.GetEnvironmentVariable("CRM_USERNAME");
            var crmPassword = Environment.GetEnvironmentVariable("CRM_PASSWORD");
    
            var clientCredentials = new ClientCredentials();
            clientCredentials.UserName.UserName = $"{crmDomain}\\{crmUsername}";
            clientCredentials.UserName.Password = crmPassword;

            var organizationUri = new Uri(crmOrganizationUrl);
            var serviceProxy = new OrganizationServiceProxy(organizationUri, null, clientCredentials, null);

            serviceProxy.EnableProxyTypes();
            serviceProxy.Timeout = new TimeSpan(0, 10, 0);

            return serviceProxy;
        }
        
        public static IOrganizationService GetOrganizationServiceInDev()
        {
            const string crmOrganizationUrl = "http://crm.dev1.vlpadr.net/vellivcrm/XRMServices/2011/Organization.svc";
            var crmDomain = Environment.GetEnvironmentVariable("DOMAIN");
            var crmUsername = Environment.GetEnvironmentVariable("CRM_USERNAME");
            var crmPassword = Environment.GetEnvironmentVariable("CRM_PASSWORD");
    
            var clientCredentials = new ClientCredentials();
            clientCredentials.UserName.UserName = $"{crmDomain}\\{crmUsername}";
            clientCredentials.UserName.Password = crmPassword;

            var organizationUri = new Uri(crmOrganizationUrl);
            var serviceProxy = new OrganizationServiceProxy(organizationUri, null, clientCredentials, null);

            serviceProxy.EnableProxyTypes();
            serviceProxy.Timeout = new TimeSpan(0, 5, 0);

            return serviceProxy;
        }
    }
}