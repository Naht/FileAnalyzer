using System;
using System.Collections.Generic;
using System.Linq;

public static class IndexLookup
{
    public static int[] FindAllIndexof<T>(this IEnumerable<T> values, T value)
    {
        return values.Select((x, i) => Equals(x, value) ? i : -1).Where(i => i != -1).ToArray();
    }
}

