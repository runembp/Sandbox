using System.Reflection;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Client;

namespace DTL.Entities
{
    [EntityLogicalName(EntityLogicalName)]
    public class OrganizationalUnitEntity : BaseEntity
    {
        public OrganizationalUnitEntity()
        {
            LogicalName = typeof(OrganizationalUnitEntity).GetCustomAttribute<EntityLogicalNameAttribute>().LogicalName;
        }

        public const string EntityLogicalName = "new_organizationalunit";
        public const string FieldUnitNo = "new_unitno";

        [AttributeLogicalName(FieldUnitNo)]
        public int? UnitNo
        {
            get => Get<int>();
            set => Set(value);
        }
    }
}