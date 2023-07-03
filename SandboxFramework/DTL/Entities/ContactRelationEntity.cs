using System.Reflection;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Client;

namespace DTL.Entities
{
    [EntityLogicalName(FieldLogicalName)]
    public class ContactRelationEntity : BaseEntity
    {
        public ContactRelationEntity() 
        {
            LogicalName = typeof(ContactRelationEntity).GetCustomAttribute<EntityLogicalNameAttribute>().LogicalName;
        }
        
        public const string FieldLogicalName = "new_contactrelations";

        public const string FieldAccount = "new_accountnameid";
        public const string FieldAccountCeo = "new_accountceo";
        public const string FieldAccountCfo = "new_accountcfo";
        public const string FieldAccountPensionResponsible1 = "new_accountpensionresponsible1";
        public const string FieldAccountPensionResponsible2 = "new_accountpensionresponsible2";
        public const string FieldAccountVellivsundhedspartner = "new_accountvellivsundhedspartner";
        public const string FieldAccountPayrollAdministrator = "new_accountpayrolladministrator";
        public const string FieldAccountHrDirectorManager = "new_accounthrdirectorhrmanager";
        public const string FieldAccountAttRiskReport = "new_accountattriskreport";
        public const string FieldContactRelationEmail = "new_contactrelationemail";
        
        [AttributeLogicalName(FieldContactRelationEmail)]
        public EntityReference ContactRelationForEmail
        {
            get => Get<EntityReference>();
            set => Set(value);
        }
    }
}