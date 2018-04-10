using System;
using System.Linq;

public class BinarySearch
{
    public BinarySearch(int[] input)
    {
        OrderedArray = input.OrderBy(i => i).ToArray();
    }

    public int Find(int value)
    {
        int low = 0;
        int high = OrderedArray.Length - 1;
        int mid = (low + high) / 2;

        while (low <= high)
        {
            if (value == OrderedArray[mid])
            {
                return mid;
            }
            if (value < OrderedArray[mid])
            {
                high = mid - 1;
                mid = (low + high) / 2; 
            }
            else if (value > OrderedArray[mid])
            {
                low = mid + 1;
                mid = (low + high) / 2;
            }
        }
        return -1;
    }

    private int[] OrderedArray { get; set; }
}