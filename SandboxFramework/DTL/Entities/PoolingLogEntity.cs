using System;
using System.Reflection;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Client;

namespace DTL.Entities
{
    [EntityLogicalName(EntityLogicalName)]
    public class PoolingLogEntity : BaseEntity
    {
        public PoolingLogEntity() 
        {
            LogicalName = typeof(PoolingLogEntity).GetCustomAttribute<EntityLogicalNameAttribute>().LogicalName;
        }
        
        public const string EntityLogicalName = "new_poolinglog";
        public const string FieldName = "new_name";
        public const string FieldAccount = "new_account";
        public const string FieldPoolingNetwork = "new_poolingnetwork";
        public const string FieldDate = "new_date";
        public const string FieldContractAccount = "new_contractaccount";
        public const string FieldPooling = "new_pooling";
        public const string FieldPoolingLogStatus = "new_status";

        [AttributeLogicalName(FieldAccount)]
        public EntityReference Account
        {
            get => Get<EntityReference>(); 
            set => Set(value);
        }
        
        [AttributeLogicalName(FieldPoolingNetwork)]
        public OptionSetValue PoolingNetwork
        {
            get => Get<OptionSetValue>(); 
            set => Set(value);
        }

        [AttributeLogicalName(FieldDate)]
        public DateTime? Date
        {
            get => Get<DateTime>();
            set => Set(value);
        }
        
        [AttributeLogicalName(FieldContractAccount)]
        public EntityReference ContractAccount
        {
            get => Get<EntityReference>(); 
            set => Set(value);
        }
        
        [AttributeLogicalName(FieldPooling)]
        public EntityReference Pooling
        {
            get => Get<EntityReference>(); 
            set => Set(value);
        }
        
        [AttributeLogicalName(FieldPoolingLogStatus)]
        public OptionSetValue PoolingLogStatus
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
    }
}