using System.Reflection;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Client;

namespace DTL.Entities
{
    [EntityLogicalName(EntityLogicalName)]
    public class AccountEntity : BaseEntity
    {
        public AccountEntity()
        {
            LogicalName = typeof(AccountEntity).GetCustomAttribute<EntityLogicalNameAttribute>().LogicalName;
        }
        
        public const string EntityLogicalName = "account";
        public const string EntityId = "accountid";

        public const string FieldName = "name";
        public const string FieldHealthcareContact = "new_healthcarecontact";
        public const string FieldHrDirectorManager = "new_hrdirectorhrmanagerid";
        public const string FieldPensionResponsible1 = "new_pensionresponsible1id";
        public const string FieldPensionResponsible2 = "new_pensionresponsible2id";
        public const string FieldCfo = "new_cfoid";
        public const string FieldCeo = "new_ceoid";
        public const string FieldAttRiskReport2012 = "new_attriskreport2012";
        public const string FieldPayrollAdministrator = "new_payrolladministrator1";
        public const string FieldAccountSegment = "new_nlpaccountsegmentid";
        public const string FieldEUUdbudskrav = "new_euudbudskrav";
        public const string FieldContractAccount = "new_contractaccountnameid";
        public const string FieldPoolingNetwork = "new_poolingnetwork";
        public const string FieldPoolingStatus = "new_poolingstatus";
        public const string FieldLevel = "new_level";
        public const string FieldContractNoN16 = "new_contractnon16";
        public const string FieldFrameAgreement = "new_frameagreement";
        public const string FieldDailyContactAccount = "new_dailycontactaccountid";
        public const string FieldUniqueKey = "new_uniquekey";
        public const string DailyContactAccount = "new_dailycontactaccountid";
        public const string FieldFolderCreated = "new_foldercreated";
        public const string FieldFolderForZCreated = "new_folderforzcreated";
        public const string FieldPath = "new_path";
        public const string FieldPathForZ = "new_pathforz";
        public const string FieldFfKeyN16 = "new_ffkeyn16";
        public const string FieldCvrNumber = "new_cvrnumber";
        public const string FieldLegalName = "new_legalname";
        public const string FieldAccountFolder = "new_accountfolder";
        

        [AttributeLogicalName(FieldAccountSegment)]
        public EntityReference AccountSegment
        {
            get => Get<EntityReference>();
            set => Set(value);
        }

        [AttributeLogicalName(FieldEUUdbudskrav)]
        public bool? EuUdbudskrav
        {
            get => Get<bool?>(); 
            set => Set(value);
        }

        [AttributeLogicalName(FieldPoolingStatus)]
        public OptionSetValue PoolingStatus 
        { 
            get => Get<OptionSetValue>(); 
            set => Set(value); 
        }

        [AttributeLogicalName(FieldPoolingNetwork)]
        public OptionSetValue PoolingNetwork 
        { 
            get => Get<OptionSetValue>(); 
            set => Set(value); 
        }

        [AttributeLogicalName(FieldLevel)]
        public OptionSetValue Level 
        { 
            get => Get<OptionSetValue>(); 
            set => Set(value); 
        }

        [AttributeLogicalName(FieldName)]
        public string Name
        { 
            get => Get<string>(); 
            set => Set(value); 
        }
        
        [AttributeLogicalName(FieldContractAccount)]
        public EntityReference ContractAccount
        { 
            get => Get<EntityReference>(); 
            set => Set(value); 
        }
        
        [AttributeLogicalName(FieldUniqueKey)]
        public string UniqueKey
        { 
            get => Get<string>(); 
            set => Set(value); 
        }
        
        [AttributeLogicalName(FieldFolderCreated)]
        public bool? FolderCreated
        { 
            get => Get<bool>(); 
            set => Set(value); 
        }
        
        [AttributeLogicalName(FieldFolderForZCreated)]
        public bool? FolderForZCreated
        { 
            get => Get<bool>(); 
            set => Set(value); 
        }
        
        [AttributeLogicalName(FieldPath)]
        public string Path
        { 
            get => Get<string>(); 
            set => Set(value); 
        }

        [AttributeLogicalName(FieldPathForZ)]
        public string PathForZ
        {
            get => Get<string>();
            set => Set(value);
        }
           
        [AttributeLogicalName(FieldFfKeyN16)]
        public string FfKeyN16
        {
            get => Get<string>();
            set => Set(value);
        }
        
        [AttributeLogicalName(FieldCvrNumber)]
        public string CvrNumber
        {
            get => Get<string>();
            set => Set(value);
        }
        
        [AttributeLogicalName(FieldLegalName)]
        public string LegalName
        {
            get => Get<string>();
            set => Set(value);
        }
        
        [AttributeLogicalName(FieldAccountFolder)]
        public string AccountFolder
        {
            get => Get<string>();
            set => Set(value);
        }
    }
}