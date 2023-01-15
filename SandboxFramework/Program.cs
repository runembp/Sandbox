using System;
using System.Linq;
using DTL.Entities;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using Microsoft.Xrm.Tooling.Connector;

namespace SandboxFramework
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
            var organizationService = ConnectToCrm();
            var contactRelationGuid = new Guid("{DA029880-9386-ED11-AABB-9BB85E851AD8}");
            // {DA029880-9386-ED11-AABB-9BB85E851AD8}
            
            var contactRelationEntity = organizationService.Retrieve(ContactRelationEntity.LogicalName, contactRelationGuid, new ColumnSet());

            contactRelationEntity[ContactRelationEntity.FieldAccountAttRiskReport] = false;
            organizationService.Update(contactRelationEntity);

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