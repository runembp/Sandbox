using Microsoft.Crm.Sdk.Messages;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Tooling.Connector;

var organizationService = ConnectToCrm();

var whoAmI = (WhoAmIResponse)organizationService.Execute(new WhoAmIRequest());

Console.ReadKey();

static IOrganizationService ConnectToCrm()
{
    var crmOrganizationUrl = Environment.GetEnvironmentVariable("CRM_ORGANIZATIONSERVICE_URL");
    var crmDomain = Environment.GetEnvironmentVariable("DOMAIN");
    var crmUsername = Environment.GetEnvironmentVariable("CRM_USERNAME");
    var crmPassword = Environment.GetEnvironmentVariable("CRM_PASSWORD");
    // crmOrganizationUrl = "http://crm.test1.vlpadr.net/Velliv/XRMServices/2011/Organization.svc";

    var connectionString = $"AuthType=AD;Domain={crmDomain};Url={crmOrganizationUrl};Username={crmUsername};Password={crmPassword}";
    return new CrmServiceClient(connectionString);
}