﻿using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using Microsoft.Xrm.Sdk;

namespace SandboxFramework.Entities;

public class BaseEntity : Entity
{
    public const string FieldStateCode = "statecode";
    public const string FieldStatusCode = "statuscode";
    public const string FieldModifiedOn = "modifiedon";
    public const string FieldCreatedOn = "createdon";
        
    private string GetAttributeName(string propertyName)
    {
        return GetType()
            .GetProperties()
            .First(x => x.Name == propertyName)
            .GetCustomAttribute<AttributeLogicalNameAttribute>().LogicalName;
    }
    
    protected T Get<T>([CallerMemberName] string propertyName = null)
    {
        return GetAttributeValue<T>(GetAttributeName(propertyName));
    }

    protected void Set(object? value, [CallerMemberName] string propertyName = null)
    {
        SetAttributeValue(GetAttributeName(propertyName), value);
    }
}