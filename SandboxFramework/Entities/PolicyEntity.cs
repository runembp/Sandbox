using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace SandboxFramework.Entities
{
    [Table(EntityLogicalName)]
    public class PolicyEntity
    {
        public const string EntityLogicalName = "new_policy";

        private const string FieldPolicyNumber = "new_policynumber";
        private const string FieldPolicyId = "new_policyid";
        public const string FieldEmployerId = "new_employerid";
        public const string FieldAccount = "new_account";

        [Column(FieldPolicyId)]
        public Guid Id { get; set; }
        
        [Column(FieldPolicyNumber)] 
        public string PolicyNumber { get; set; }
        
    }
}