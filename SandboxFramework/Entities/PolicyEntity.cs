using System;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.Xrm.Sdk;

namespace SandboxFramework.Entities
{
    [Table(EntityLogicalName)]
    public class PolicyEntity : Entity
    {
        public PolicyEntity() : base(EntityLogicalName)
        {
        }

        private const string EntityLogicalName = "new_policy";
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