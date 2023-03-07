using System.Collections.Generic;
using System.Linq;

namespace Batch___Framework.Tools;

public static class Extensions
{
    public static List<List<T>> ChunkBy<T>(this IEnumerable<T> values, int chunkSize)
    {
        return values.Select((x, i) => new { Index = i, Value = x })
            .GroupBy(x => x.Index / chunkSize)
            .Select(x => x.Select(v => v.Value).ToList())
            .ToList();
    }
}