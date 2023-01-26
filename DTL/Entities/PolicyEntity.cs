using System.ComponentModel.DataAnnotations.Schema;

namespace DTL.Entities
{
    [Table(LogicalName)]
    public class PolicyEntity
    {
        public const string LogicalName = "new_policy";

        public const string FieldPolicyNumber = "new_policynumber";
        
        [Column(FieldPolicyNumber)] 
        public string PolicyNumber { get; set; }
    }
}