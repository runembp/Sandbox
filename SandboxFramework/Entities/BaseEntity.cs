using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using Microsoft.Xrm.Sdk;

namespace SandboxFramework.Entities;

public class BaseEntity : Entity
{
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

    protected void Set(object value, [CallerMemberName] string propertyName = null)
    {
        SetAttributeValue(GetAttributeName(propertyName), value);
    }
    
    protected IEnumerable<T> GetRelated<T>(string propertyName = null) where T : Entity
    {
        return GetRelatedEntities<T>(propertyName, null);
    }
    
    protected void SetRelated<T>(IEnumerable<T> value, string relationshipName = null) where T : Entity
    {
        SetRelatedEntities(relationshipName, null, value);
    }
}