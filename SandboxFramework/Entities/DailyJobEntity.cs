using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace SandboxFramework.Entities
{
    [Table(EntityLogicalName)]
    public class DailyJobEntity 
    {
        public const string EntityLogicalName = "new_dailyjob";
        private const string FieldId = "new_dailyjobid";

        private const string FieldErrorText = "new_errortext";
        private const string FieldData = "new_data";
        public const string FieldBatchIdentifier = "new_identifier";

        [Column(FieldId)]
        public Guid Id { get; set; } = Guid.NewGuid();
    
        [Column(FieldBatchIdentifier)]
        public string BatchIdentifier { get; set; }
    
        [Column(FieldData)]
        public string Data { get; set; }
    
        [Column(FieldErrorText)]
        public string ErrorText { get; set; }
    
    }
}