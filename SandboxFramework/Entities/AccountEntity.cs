using System;
using System.Collections.Generic;
using System.Reflection;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Client;

namespace SandboxFramework.Entities
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
        public const string FieldDailyContactAccount = "new_dailycontactaccountid";

        public const string RelationsRelatedPensionSchemes = "new_account_new_pensionschemes";
        public const string FieldNumberOfEnsured = "new_numberofensured";
        public const string FieldPoolingStatus = "new_poolingstatus";
        public const string FieldPoolingNetwork = "new_poolingnetwork";
        public const string FieldLevel = "new_level";
        public const string FieldContractN16 = "new_contractnon16";

        [AttributeLogicalName(EntityId)]
        public Guid AccountId
        {
            get => Get<Guid>();
            set => Set(value);
        }
        
        [AttributeLogicalName(FieldName)]
        public string Name { 
            get => Get<string>(); 
            set => Set(value); 
        }

        [AttributeLogicalName(FieldAccountSegment)]
        public EntityReference? AccountSegment { 
            get => Get<EntityReference>(); 
            set => Set(value); 
        }
        
        [AttributeLogicalName(FieldDailyContactAccount)]
        public EntityReference? DailyContactAccount { 
            get => Get<EntityReference>(); 
            set => Set(value); 
        }
        
        [AttributeLogicalName(FieldEUUdbudskrav)]
        public bool? EuUdbudskrav
        {
            get => Get<bool>(); 
            set => Set(value);
        }

        [AttributeLogicalName(FieldNumberOfEnsured)]
        public int? NumberOfEnsured
        {
            get => Get<int>(); 
            set => Set(value);
        }
        
        [RelationshipSchemaName(RelationsRelatedPensionSchemes)]
        public IEnumerable<PensionSchemeEntity> new_account_new_pensionschemes
        {
            get => GetRelatedEntities<PensionSchemeEntity>(RelationsRelatedPensionSchemes, null);
            set => SetRelatedEntities(RelationsRelatedPensionSchemes, null, value);
        }

        
        
    }
}