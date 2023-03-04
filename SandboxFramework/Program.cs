using SandboxFramework.Entities;
using SandboxFramework.Tools;

namespace SandboxFramework
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
            // PerformanceTest.CreateAndDeleteParallelExecuteMultiple(2, 200, 1000);
            // Deletion.Cleanup();
            
            var organizationService = OrganizationService.GetOrganizationService();

            var policy = new PolicyEntity
            {
                PolicyNumber = "SomePolicyNumber"
            };

            var result = organizationService.Create(policy);
        }
    }
}