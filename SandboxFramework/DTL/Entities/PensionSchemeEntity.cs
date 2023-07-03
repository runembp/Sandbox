using System.Reflection;
using Microsoft.Xrm.Sdk.Client;

namespace DTL.Entities
{
    public class PensionSchemeEntity : BaseEntity
    {
        public PensionSchemeEntity() 
        {
            LogicalName = typeof(PensionSchemeEntity).GetCustomAttribute<EntityLogicalNameAttribute>().LogicalName;
        }

        public const string EntityLogicalName = "new_pensionschemes";
        public const string EntityId = "new_pensionschemesid";
        public const string FieldAccount = "new_accountid";
        public const string FieldSubScheme = "new_subschemeid";
    }
}