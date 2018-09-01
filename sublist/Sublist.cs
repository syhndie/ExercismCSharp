using System;
using System.Collections.Generic;
using System.Linq;

public enum SublistType
{
    Equal,
    Unequal,
    Superlist,
    Sublist
}

public static class Sublist
{ 
    public static SublistType Classify<T>(List<T> list1, List<T> list2)
        where T : IComparable
    {            
        if (list1.SequenceEqual(list2)) return SublistType.Equal;

        if (list1.Count < list2.Count() && firstIsSublistOfSecond(list1, list2)) return SublistType.Sublist;

        if (list2.Count < list1.Count() && firstIsSublistOfSecond(list2, list1)) return SublistType.Superlist;

        return SublistType.Unequal;
    }

    public static bool firstIsSublistOfSecond<T>(List<T> shortList, List<T> longList)
        where T : IComparable
    {
        for (int slider = 0; slider <= longList.Count - shortList.Count; slider++)
        {
            var sublist = longList.Skip(slider).Take(shortList.Count);
            if (shortList.SequenceEqual(sublist)) return true;
        }

        return false;
    }
}