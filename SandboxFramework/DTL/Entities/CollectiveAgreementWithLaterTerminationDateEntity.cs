using System;
using System.Reflection;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Client;

namespace DTL.Entities
{
    [EntityLogicalName(EntityLogicalName)]
    public class CollectiveAgreementWithLaterTerminationDateEntity : BaseEntity
    {
        public CollectiveAgreementWithLaterTerminationDateEntity()
        {
            LogicalName = typeof(CollectiveAgreementWithLaterTerminationDateEntity).GetCustomAttribute<EntityLogicalNameAttribute>().LogicalName;
        }
        
        public const string EntityLogicalName = "new_collectiveagreementslatertermination";
        public const string EntityId = "new_collectiveagreementslaterterminationid";
        public const string FieldName = "new_name";
        public const string FieldAccount = "new_account";
        public const string FieldRegistration = "new_registration";
        public const string FieldCollectiveAgreement = "new_collectiveagreement";
        public const string FieldTerminationDate = "new_terminationdate";
        
        [AttributeLogicalName(EntityId)]
        public Guid? Guid
        {
            get => Get<Guid?>();
            set => Set(value);
        }

        [AttributeLogicalName(FieldName)]
        public string Name
        {
            get => Get<string>();
            set => Set(value);
        }

        [AttributeLogicalName(FieldAccount)]
        public EntityReference Account
        {
            get => Get<EntityReference>();
            set => Set(value);
        }
        
        [AttributeLogicalName(FieldRegistration)]
        public EntityReference Registration
        {
            get => Get<EntityReference>();
            set => Set(value);
        }
        
        [AttributeLogicalName(FieldCollectiveAgreement)]
        public EntityReference CollectiveAgreement
        {
            get => Get<EntityReference>();
            set => Set(value);
        }
        
        [AttributeLogicalName(FieldTerminationDate)]
        public DateTime TerminationDate
        {
            get => Get<DateTime>();
            set => Set(value);
        }
    }
}