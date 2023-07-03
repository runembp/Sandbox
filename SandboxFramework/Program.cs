using System;
using System.Threading.Tasks;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using SandboxFramework.Tools;

namespace SandboxFramework
{
    internal static class Program
    {
        private static IOrganizationService OrganizationService => Tools.OrganizationService.GetOrganizationService();

        public static Task Main()
        {
            Deletion.Cleanup("008");
            
            return Task.CompletedTask;

            var accountFields = new[]
            {
                "new_ffkeyn16",
                "new_unformatedcvr",
                "new_nlpaccountsegmentid", // FormattedValue
                "new_dailyleadingaccount", // FormattedValue
                "ownerid",
                "new_servicechannel",
                "new_premiumtotal",
                "new_totalpremiumcontractlevel",
                "new_savingstotal",
                "new_totalsavingscontractlevel",
                "new_numberofensuredcontractlevel",
                "new_antalpolicern16",
                "new_antalpolicerlop",
                "new_numberofpolicies",
                "new_numberofpoliciescontractlevel",
                "new_healthinsidecontribution",
                "new_ismandatoryoptions",
                "new_externalsuppliers",
                "new_externalsupplierupdated",
                "new_remarksabouthealth",
                "new_blumesupport",
                "new_ceoid",
                "new_cfoid",
                "new_hrdirectorhrmanagerid",
                "new_pensionresponsible1id",
                "new_pensionresponsible2id",
                "new_healthcarecontact",
                "new_payrolladministrator1",
                "new_attriskreport2012"
            };

            var query = new QueryExpression("account")
            {
                // TopCount = 1, // TODO Remove this
                ColumnSet = new ColumnSet(accountFields),
                Criteria = new FilterExpression
                {
                    Conditions =
                    {
                        new ConditionExpression("new_numberofensuredcontractlevel", ConditionOperator.GreaterThan, 0m),
                        new ConditionExpression("new_ffkeyn16", ConditionOperator.NotNull),
                        new ConditionExpression("new_ismandatoryoptions", ConditionOperator.NotNull), //TODO Remove this
                    }
                },
                PageInfo = new PagingInfo
                {
                    PageNumber = 1,
                    Count = 5000
                },
            };

            var dailyContractAccount = query.AddLink("account", "new_dailycontactaccountid", "accountid");
            dailyContractAccount.EntityAlias = "DailyContractAccount";
            dailyContractAccount.Columns.AddColumns("new_unformatedcvr");

            var parentAccount = query.AddLink("account", "parentaccountid", "accountid");
            parentAccount.EntityAlias = "ParentAccount";
            parentAccount.Columns.AddColumns("new_unformatedcvr");

            var result = OrganizationService.RetrieveMultiple(query);

            if (result.MoreRecords)
            {
                var pagingCookie = result.PagingCookie;
                var page = 1;

                while (result.MoreRecords)
                {
                    page++;
                    query.PageInfo = new PagingInfo
                    {
                        PageNumber = page,
                        PagingCookie = pagingCookie
                    };

                    result = OrganizationService.RetrieveMultiple(query);
                }
            }

            foreach (var entity in result.Entities)
            {
                var ffkeyn16 = GetAttributeOrDefault<string>(entity, "new_ffkeyn16");
                var unformatedcvr = GetAttributeOrDefault<string>(entity, "new_unformatedcvr");
                var servicechannel = GetAttributeOrDefault<string>(entity, "new_servicechannel");
                var healthinsidecontribution = GetAttributeOrDefault<string>(entity, "new_healthinsidecontribution");
                var remarksabouthealth = GetAttributeOrDefault<string>(entity, "new_remarksabouthealth");
                var blumesupport = GetAttributeOrDefault<string>(entity, "new_blumesupport");
                var numberofensuredcontractlevel = GetAttributeOrDefault<decimal>(entity, "new_numberofensuredcontractlevel");
                var antalpolicern16 = GetAttributeOrDefault<int>(entity, "new_antalpolicern16");
                var antalpolicerlop = GetAttributeOrDefault<int>(entity, "new_antalpolicerlop");
                var numberofpolicies = GetAttributeOrDefault<int>(entity, "new_numberofpolicies");
                var numberofpoliciescontractlevel = GetAttributeOrDefault<int>(entity, "new_numberofpoliciescontractlevel");
                var ismandatoryoptions = GetAttributeOrDefault<OptionSetValue>(entity, "new_ismandatoryoptions");
                var externalsupplierupdated = GetAttributeOrDefault<DateTime>(entity, "new_externalsupplierupdated");
                var dailyleadingaccount = GetAttributeOrDefault<bool>(entity, "new_dailyleadingaccount");

                var premiumtotal = GetMoneyValueOrDefault(entity, "new_premiumtotal");
                var totalpremiumcontractlevel = GetMoneyValueOrDefault(entity, "new_totalpremiumcontractlevel");
                var savingstotal = GetMoneyValueOrDefault(entity, "new_savingstotal");
                var totalsavingscontractlevel = GetMoneyValueOrDefault(entity, "new_totalsavingscontractlevel");

                var nlpaccountsegmentid = GetEntityReferenceNameOrDefault(entity, "new_nlpaccountsegmentid");
                var owner = GetEntityReferenceNameOrDefault(entity, "ownerid");
                var externalsuppliers = GetEntityReferenceNameOrDefault(entity, "new_externalsuppliers");

                var ceoid = GetEntityReferenceIdOrDefault(entity, "new_ceoid");
                var cfoid = GetEntityReferenceIdOrDefault(entity, "new_cfoid");
                var hrdirectorhrmanagerid = GetEntityReferenceIdOrDefault(entity, "new_hrdirectorhrmanagerid");
                var pensionresponsible1id = GetEntityReferenceIdOrDefault(entity, "new_pensionresponsible1id");
                var pensionresponsible2id = GetEntityReferenceIdOrDefault(entity, "new_pensionresponsible2id");
                var healthcarecontact = GetEntityReferenceIdOrDefault(entity, "new_healthcarecontact");
                var payrolladministrator1 = GetEntityReferenceIdOrDefault(entity, "new_payrolladministrator1");
                var attriskreport2012 = GetEntityReferenceIdOrDefault(entity, "new_attriskreport2012");

                var parentAccountCvr = GetAliasedValueOrDefault(entity, "ParentAccount.new_unformatedcvr");
                var dailyContractAccountCvr = GetAliasedValueOrDefault(entity, "DailyContractAccount.new_unformatedcvr");
            }

            return Task.CompletedTask;
        }

        private static T GetAttributeOrDefault<T>(Entity entity, string attributeName)
        {
            return entity.Contains(attributeName) ? entity.GetAttributeValue<T>(attributeName) : default;
        }

        private static decimal GetMoneyValueOrDefault(Entity entity, string attributeName)
        {
            if (!entity.Contains(attributeName))
            {
                return default;
            }

            var money = entity.GetAttributeValue<Money>(attributeName);
            return money?.Value ?? default;
        }

        private static Guid? GetEntityReferenceIdOrDefault(Entity entity, string attributeName)
        {
            return entity.Contains(attributeName)
                ? entity.GetAttributeValue<EntityReference>(attributeName)?.Id
                : null;
        }

        private static string GetEntityReferenceNameOrDefault(Entity entity, string attributeName)
        {
            return entity.Contains(attributeName)
                ? entity.GetAttributeValue<EntityReference>(attributeName).Name
                : default;
        }

        private static string GetAliasedValueOrDefault(Entity entity, string attributeName)
        {
            return entity.Contains(attributeName)
                ? entity.GetAttributeValue<AliasedValue>(attributeName).Value.ToString()
                : default;
        }
    }
}