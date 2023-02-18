using System;
using System.Reflection;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Client;

namespace SandboxFramework.Entities;

[EntityLogicalName(EntityLogicalName)]
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

    [AttributeLogicalName(EntityId)]
    public Guid PensionSchemeId
    {
        get => Get<Guid>();
        set => Set(value);
    }
    
    [AttributeLogicalName(FieldAccount)]
    public EntityReference Account
    {
        get => Get<EntityReference>();
        set => Set(value);
    }
    
    [AttributeLogicalName(FieldSubScheme)]
    public EntityReference SubScheme
    {
        get => Get<EntityReference>();
        set => Set(value);
    }
}