using System;
using System.Linq;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Client;
using Microsoft.Xrm.Sdk.Query;
using Microsoft.Xrm.Tooling.Connector;

namespace SandboxFramework
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
            using (var organizationContext = ConnectToCrm())
            {
                var query =
                    from acc in organizationContext.CreateQuery("account")
                    join cr in organizationContext.CreateQuery("new_contactrelations")
                        on acc["accountid"] equals cr["new_accountnameid"]
                    select new
                    {

                    };
            }            
            
            Console.ReadKey();
            
            // var query = new QueryExpression
            // {
            //     EntityName = "account",
            //     ColumnSet = new ColumnSet(false),
            // };
            //
            // query.Criteria.FilterOperator = LogicalOperator.Or;
            // query.Criteria.Conditions.Add(new ConditionExpression("new_pensionresponsible1id", ConditionOperator.Equal, contactRelationToDelete.Id));
            // query.Criteria.Conditions.Add(new ConditionExpression("new_pensionresponsible2id", ConditionOperator.Equal, contactRelationToDelete.Id));
            // query.Criteria.Conditions.Add(new ConditionExpression("new_ceoid", ConditionOperator.Equal, contactRelationToDelete.Id));
            // query.Criteria.Conditions.Add(new ConditionExpression("new_cfoid", ConditionOperator.Equal, contactRelationToDelete.Id));
            // query.Criteria.Conditions.Add(new ConditionExpression("new_hrdirectorhrmanagerid", ConditionOperator.Equal, contactRelationToDelete.Id));
            // query.Criteria.Conditions.Add(new ConditionExpression("new_payrolladministrator1", ConditionOperator.Equal, contactRelationToDelete.Id));
            // query.Criteria.Conditions.Add(new ConditionExpression("new_attriskreport2012", ConditionOperator.Equal, contactRelationToDelete.Id));
            // query.Criteria.Conditions.Add(new ConditionExpression("new_remarkstokeypersons", ConditionOperator.Equal, contactRelationToDelete.Id));
            //
            // var result = organizationService.RetrieveMultiple(query);
        }

        private static OrganizationServiceContext ConnectToCrm()
        {
            var crmOrganizationUrl = Environment.GetEnvironmentVariable("CRM_ORGANIZATIONSERVICE_URL");
            var crmDomain = Environment.GetEnvironmentVariable("DOMAIN");
            var crmUsername = Environment.GetEnvironmentVariable("CRM_USERNAME");
            var crmPassword = Environment.GetEnvironmentVariable("CRM_PASSWORD");
            // crmOrganizationUrl = "http://crm.test1.vlpadr.net/Velliv/XRMServices/2011/Organization.svc";

            var connectionString = $"AuthType=AD;Domain={crmDomain};Url={crmOrganizationUrl};Username={crmUsername};Password={crmPassword}";
            return new OrganizationServiceContext(connectionString);
        }
    }
}