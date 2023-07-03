using System.Reflection;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Client;

namespace DTL.Entities
{
    [EntityLogicalName(EntityLogicalName)]
    public class AmpEntity : BaseEntity
    {
        public AmpEntity()
        {
            LogicalName = typeof(AmpEntity).GetCustomAttribute<EntityLogicalNameAttribute>().LogicalName;
        }
        
        public const string EntityLogicalName = "new_amp";
        public const string FieldId = "new_id";
        
        [AttributeLogicalName(FieldId)]
        public string AmpId
        {
            get => Get<string>();
            set => Set(value);
        }
    }
}