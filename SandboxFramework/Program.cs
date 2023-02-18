using System;
using System.Linq;
using DTL.Entities;
using Microsoft.Xrm.Sdk.Query;
using SandboxFramework.Entities;
using SandboxFramework.Tools;

namespace SandboxFramework
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
            var foodFolkGuid = new Guid("{C762E3E9-98DD-DE11-940D-005056B155F7}");
            
            GetAccountsWithDailyContactToPoolingAccount(foodFolkGuid);
        }

        private static void GetAccountsWithDailyContactToPoolingAccount(Guid foodFolkGuid)
        {
            var service = OrganizationService.GetOrganizationService();
            var accountGuid = new Guid("c762e3e9-98dd-de11-940d-005056b155f7");

            var policeIkraftGuid = new Guid("76171472-6ad0-de11-9119-005056b155f7");
            var policePraemiebaerende = new Guid("3ca54805-13da-e611-80fd-005056ba6546");
            const string companyWildcardQuery = "%firma%";
            const int levelRammeAftale = 100000001;
            
            var query = new QueryExpression("account");
            query.Distinct = true;

            query.ColumnSet.AddColumns("name", "telephone1", "new_cvrnumber", "address1_postalcode", "address1_city", "new_pensionscheme", "new_opportunities", "new_leads", "new_concernaccount", "accountnumber", "new_unformatedcvr", "new_nlpaccountsegmentid", "new_dailycontactaccountid", "ownerid", "accountid");
            query.AddOrder("name", OrderType.Ascending);
            query.Criteria.AddCondition("new_contractaccountnameid", ConditionOperator.Equal, accountGuid);
            query.Criteria.AddCondition("new_poolingnetwork", ConditionOperator.Null);

            var policyLink = query.AddLink("new_policy", "accountid", "new_employerid");
            policyLink.LinkCriteria.AddCondition("new_statusid", ConditionOperator.In, policeIkraftGuid, policePraemiebaerende);
            policyLink.LinkCriteria.AddCondition("new_incassocodeidname", ConditionOperator.Like, companyWildcardQuery);

            var accountLink = query.AddLink("account", "new_contractaccountnameid", "accountid");
            var poolingLink = accountLink.AddLink("new_pooling", "accountid", "new_account");
            poolingLink.LinkCriteria.AddCondition("new_level", ConditionOperator.Equal, levelRammeAftale);
            poolingLink.LinkCriteria.AddCondition("new_enddate", ConditionOperator.Null);

            var daughterAccounts = service.RetrieveMultiple(query).Entities;
        }
    }
}