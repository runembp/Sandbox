using System.Reflection;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Client;

namespace DTL.Entities
{
    [EntityLogicalName(EntityLogicalName)]
    public class RegistrationEntity : BaseEntity
    {
        public RegistrationEntity()
        {
            LogicalName = typeof(RegistrationEntity).GetCustomAttribute<EntityLogicalNameAttribute>().LogicalName;
        }
        
        public const string EntityLogicalName = "new_registration";
        public const string EntityId = "new_registrationid";
        public const string FieldName = "new_name";
        
        [AttributeLogicalName(FieldName)]
        public string Name
        {
            get => Get<string>();
            set => Set(value);
        }
    }
}