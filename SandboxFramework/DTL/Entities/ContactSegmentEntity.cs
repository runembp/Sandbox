using System.Reflection;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Client;

namespace DTL.Entities
{
    [EntityLogicalName(EntityLogicalName)]
    public class ContactSegmentEntity : BaseEntity
    {
        public ContactSegmentEntity()
        {
            LogicalName = typeof(ContactSegmentEntity).GetCustomAttribute<EntityLogicalNameAttribute>().LogicalName;
        }

        public const string EntityLogicalName = "new_nlpsegment";
        public const string FieldHostKey = "new_hostkey";
        
        [AttributeLogicalName(FieldHostKey)]
        public string HostKey
        {
            get => Get<string>();
            set => Set(value);
        }
    }
}