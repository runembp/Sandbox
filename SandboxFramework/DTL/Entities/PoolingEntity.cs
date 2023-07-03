using System;
using System.Reflection;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Client;

namespace DTL.Entities
{
    [EntityLogicalName(EntityLogicalName)]
    public class PoolingEntity : BaseEntity
    {
        public PoolingEntity() 
        {
            LogicalName = typeof(PoolingEntity).GetCustomAttribute<EntityLogicalNameAttribute>().LogicalName;
        }

        public const string EntityLogicalName = "new_pooling";
        public const string EntityId = "new_poolingid";
        public const string FieldAccount = "new_account";
        public const string FieldLevel = "new_level";
        public const string FieldPoolingNetwork = "new_poolingnetwork";
        public const string FieldPoolingStatus = "new_poolingstatus";
        public const string FieldStartDate = "new_startdate";
        public const string FieldEndDate = "new_enddate";

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

        [AttributeLogicalName(FieldStartDate)]
        public DateTime? StartDate
        {
            get => Get<DateTime?>(); 
            set => Set(value);
        }

        [AttributeLogicalName(FieldEndDate)]
        public DateTime? EndDate
        {
            get => Get<DateTime?>(); 
            set => Set(value);
        }

        [AttributeLogicalName(FieldLevel)]
        public OptionSetValue Level 
        { 
            get => Get<OptionSetValue>();
            set => Set(value); 
        }
        
        [AttributeLogicalName(FieldPoolingStatus)]
        public OptionSetValue PoolingStatus 
        { 
            get => Get<OptionSetValue>();
            set => Set(value); 
        }
    }
}