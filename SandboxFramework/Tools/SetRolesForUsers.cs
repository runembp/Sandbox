using System;
using System.Linq;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;

namespace SandboxFramework.Tools
{
    public static class SetRolesForUsers
    {
        private static IOrganizationService OrganizationServiceTest => Tools.OrganizationService.GetOrganizationServiceInTest();
        private static IOrganizationService OrganizationServiceDev => Tools.OrganizationService.GetOrganizationServiceInDev();

        public static void SetRuneAsSystemAdministratorsInTest()
        {
            var runeGuid = new Guid("{F8410C7C-1D9E-ED11-AABC-B3FDB943D338}");
            var runeGuidTest = new Guid("{DE6F4F1E-F41E-EE11-AAAF-0234DA940640}");
            var runeSystemUser = OrganizationServiceTest.Retrieve("systemuser", runeGuidTest, new ColumnSet(true));
            
            var query = new QueryExpression
            {
                EntityName = "role",
                // ColumnSet = new ColumnSet(),
                Criteria = new FilterExpression
                {
                    Conditions =
                    {
                        new ConditionExpression("name", ConditionOperator.Equal, "System Administrator")
                    }
                }
            };

            var roles = OrganizationServiceTest.RetrieveMultiple(query).Entities;
            
            OrganizationServiceTest.Associate(runeSystemUser.LogicalName, runeGuidTest, new Relationship("systemuserroles_association"), new EntityReferenceCollection { roles.First().ToEntityReference() });
        }
        
        public static void SetRuneAsSystemAdministratorsInDev()
        {
            var runeGuid = new Guid("{F8410C7C-1D9E-ED11-AABC-B3FDB943D338}");
            var runeSystemUser = OrganizationServiceDev.Retrieve("systemuser", runeGuid, new ColumnSet(true));
            
            var query = new QueryExpression
            {
                EntityName = "role",
                // ColumnSet = new ColumnSet(),
                Criteria = new FilterExpression
                {
                    Conditions =
                    {
                        new ConditionExpression("name", ConditionOperator.Equal, "System Administrator")
                    }
                }
            };

            var roles = OrganizationServiceDev.RetrieveMultiple(query).Entities;
            
            OrganizationServiceDev.Associate(runeSystemUser.LogicalName, runeGuid, new Relationship("systemuserroles_association"), new EntityReferenceCollection { roles.First().ToEntityReference() });
        }

        public static void RemoveRuneAsSystemAdministratorInTest()
        {
            var runeGuidTest = new Guid("{DE6F4F1E-F41E-EE11-AAAF-0234DA940640}");

            var runeSystemUser = OrganizationServiceTest.Retrieve("systemuser", runeGuidTest, new ColumnSet(true));
            
            var query = new QueryExpression
            {
                EntityName = "role",
                Criteria = new FilterExpression
                {
                    Conditions =
                    {
                        new ConditionExpression("name", ConditionOperator.Equal, "System Administrator")
                    }
                }
            };
            
            var roles = OrganizationServiceTest.RetrieveMultiple(query).Entities;
            
            OrganizationServiceTest.Disassociate(runeSystemUser.LogicalName, runeGuidTest, new Relationship("systemuserroles_association"), new EntityReferenceCollection { roles.First().ToEntityReference() });
        }
        
        public static void RemoveRuneAsSystemAdministratorInDev()
        {
            var runeGuid = new Guid("{F8410C7C-1D9E-ED11-AABC-B3FDB943D338}");

            var runeSystemUser = OrganizationServiceDev.Retrieve("systemuser", runeGuid, new ColumnSet(true));
            
            var query = new QueryExpression
            {
                EntityName = "role",
                Criteria = new FilterExpression
                {
                    Conditions =
                    {
                        new ConditionExpression("name", ConditionOperator.Equal, "System Administrator")
                    }
                }
            };
            
            var roles = OrganizationServiceDev.RetrieveMultiple(query).Entities;
            
            OrganizationServiceDev.Disassociate(runeSystemUser.LogicalName, runeGuid, new Relationship("systemuserroles_association"), new EntityReferenceCollection { roles.First().ToEntityReference() });
        }
    }
}