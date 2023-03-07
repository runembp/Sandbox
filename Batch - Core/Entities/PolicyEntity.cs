using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace DTL.Entities
{
    [Table(LogicalName)]
    public class PolicyEntity
    {
        private const string LogicalName = "new_policy";

        private const string FieldPolicyNumber = "new_policynumber";
        private const string FieldPolicyId = "new_policyid";
        
        [Column(FieldPolicyId)]
        public Guid Id { get; set; }
        
        [Column(FieldPolicyNumber)] 
        public string PolicyNumber { get; set; }
        
    }
}