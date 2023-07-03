using System.Reflection;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Client;

namespace DTL.Entities
{
    [EntityLogicalName(EntityLogicalName)]
    public class StaffMemberEntity : BaseEntity
    {
        public StaffMemberEntity()
        {
            LogicalName = typeof(StaffMemberEntity).GetCustomAttribute<EntityLogicalNameAttribute>().LogicalName;
        }

        public const string EntityLogicalName = "new_staffmember";
        public const string FieldEmployeeNumber = "new_employeenumber";
        
        [AttributeLogicalName(FieldEmployeeNumber)]
        public string EmployeeNumber
        {
            get => Get<string>();
            set => Set(value);
        }
    }
}