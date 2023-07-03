using System.Reflection;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Client;

namespace DTL.Entities
{
    [EntityLogicalName(EntityLogicalName)]
    public class PolicyEntity : BaseEntity
    {
        public PolicyEntity() 
        {
            LogicalName = typeof(PolicyEntity).GetCustomAttribute<EntityLogicalNameAttribute>().LogicalName;
        }

        public const string EntityLogicalName = "new_policy";
        public const string FieldEmployer = "new_employerid";
        public const string FieldStatus = "new_statusid";
        public const string FieldIncassoCode = "new_incassocodeidname";
        public const string FieldAccount = "new_accountid";
        public const string FieldPolicyNumber = "new_policynumber";
        public const string FieldPolicyId = "new_policyid";

        [AttributeLogicalName(FieldPolicyNumber)]
        public string PolicyNumber
        {
            get => Get<string>();
            set => Set(value);
        }
    }
}