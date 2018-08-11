using System.Collections;

public static class FlattenArray
{
    public static IEnumerable Flatten(IEnumerable input)
    {
        foreach (var i in input)
        {
            if (i == null) continue;

            if (i is IEnumerable)
            {
                foreach (var j in Flatten(i as IEnumerable)) yield return j;
            }

            else yield return i;
        }
    }
}