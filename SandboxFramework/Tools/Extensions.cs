using System;
using System.Collections.Generic;
using System.Linq;

namespace SandboxFramework.Tools;

public static class Extensions
{
    public static List<List<T>> ChunkBy<T>(this IEnumerable<T> values, int chunkSize)
    {
        return values.Select((x, i) => new { Index = i, Value = x })
            .GroupBy(x => x.Index / chunkSize)
            .Select(x => x.Select(v => v.Value).ToList())
            .ToList();
    }
    
    public static T GetAttributeFrom<T>(this object instance, string propertyName) where T : Attribute
    {
        var attributeType = typeof(T);
        var property = instance.GetType().GetProperty(propertyName);
        return (T)property!.GetCustomAttributes(attributeType, false).First();
    }
}