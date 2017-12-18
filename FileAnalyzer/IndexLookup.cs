using System;
using System.Collections.Generic;
using System.Linq;

public static class IndexLookup
{
    public static int[] FindAllIndexof<T>(this IEnumerable<T> values, T value)
    {
        return values.Select((x, i) => Equals(x, value) ? i : -1).Where(i => i != -1).ToArray();
    }

    public static bool IsNumeric(string Expression)
    {
        double retNum;

        bool isNum = Double.TryParse(Expression, System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out retNum);
        return isNum;
    }
}

