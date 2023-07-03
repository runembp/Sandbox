using System.Reflection;
using Microsoft.Xrm.Sdk.Client;

namespace DTL.Entities
{
    [EntityLogicalName(EntityLogicalName)]
    public class StatusEntity : BaseEntity
    {
        public StatusEntity()
        {
            LogicalName = typeof(StatusEntity).GetCustomAttribute<EntityLogicalNameAttribute>().LogicalName;
        }

        public const string EntityLogicalName = "new_status";
        public const string EntityId = "new_statusid";
        public const string UniqueIdentifier = "new_text";
    }
}