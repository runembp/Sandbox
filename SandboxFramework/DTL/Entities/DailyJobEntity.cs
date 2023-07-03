using System.Reflection;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Client;

namespace DTL.Entities
{
    [EntityLogicalName(EntityLogicalName)]
    public class DailyJobEntity : BaseEntity
    {
        public DailyJobEntity()
        {
            LogicalName = typeof(DailyJobEntity).GetCustomAttribute<EntityLogicalNameAttribute>().LogicalName;
        }

        public const string EntityLogicalName = "new_dailyjob";
        public const string FieldData = "new_data";
        public const string FieldBatchIdentifier = "new_identifier";
        private const string EntityId = "new_dailyjobid";
        private const string FieldErrorText = "new_errortext";

        [AttributeLogicalName(FieldBatchIdentifier)]
        public string BatchIdentifier
        {
            get => Get<string>();
            set => Set(value);
        }

        [AttributeLogicalName(FieldData)]
        public string Data
        {
            get => Get<string>();
            set => Set(value);
        }

        [AttributeLogicalName(FieldErrorText)]
        public string ErrorText
        {
            get => Get<string>();
            set => Set(value);
        }
    }
}