using System;
using Microsoft.PowerPlatform.Dataverse.Client;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Tooling.Connector;

namespace SandboxFramework.Tools;

public static class OrganizationService
{
    public static IOrganizationService GetOrganizationService()
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