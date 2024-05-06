using System;
using System.Threading.Tasks;
using Microsoft.Xrm.Sdk;
using SandboxFramework.Tools;

namespace SandboxFramework
{
    internal static class Program
    {
        private static IOrganizationService OrganizationService => Tools.OrganizationService.GetOrganizationServiceInTest();
        private const string coveragePerEmployeeGroupName = "new_dkningprmedarbejdergruppe";

        public static Task Main()
        {
            
            Deletion.Cleanup();
            //DeleteAllRecordsOfEntity.DeleteAllRecords("email", DateTime.Today);
                    
            return Task.CompletedTask;
        }

        private static void UnusedMethods()
        {
            // SetRolesForUsers.SetRuneAsSystemAdministratorsInDev();
            // SetRolesForUsers.RemoveRuneAsSystemAdministratorInDev();
            DeleteAllRecordsOfEntity.DeleteAllRecords("email", DateTime.Today);



            // var solutionDeleter = new SolutionDeleter();
            //
            // var solutionNames = new[]
            // {
            //     "AccountDiscountHotFix",
            //     "DailyjobFilenameandRownumber",
            //     "StayOnBonusFix",
            //     "DecemberMiniRelease"
            // };
            //
            // solutionDeleter.DeleteSolutionByName(solutionNames);

            // ScanBatch.ScanBatchJob("new_contributionallocationpolicy");
            // ScanBatch.GetColumnsWithoutEmptyValues("ContributionAllocation.csv");
            // ScanBatch.GetColumnsWithEmptyValues("ContributionAllocation.csv");
        }
    }
}