using System;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using SandboxFramework.Entities;

namespace SandboxFramework
{
    internal static class Program
    {
        private static IOrganizationService OrganizationService;

        public static void Main()
		{
            OrganizationService = Tools.OrganizationService.GetOrganizationService();

            var accountEntity = OrganizationService.Retrieve(AccountEntity.EntityLogicalName, new Guid("{D6D9E6A3-75CB-E011-B687-E41F13451D90}"), new ColumnSet());
            
            // var accountPath = accountEntity.GetAttributeValue<string>("new_path");

            accountEntity["emailaddress1"] = @"\\smb-app.dev1.vlpadr.net\CRM\FolderTest\";
            OrganizationService.Update(accountEntity);

        }
    }
}