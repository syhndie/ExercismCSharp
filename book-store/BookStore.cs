using System;
using System.Collections.Generic;
using System.Linq;

public static class BookStore
{
    public static double Total(IEnumerable<int> books)
    {

/*
 * Note that change in discount between a set of 3 and a set of 4 is twice the change between a set
 * of 4 and a set a 5.
 * 
 * If the discounts change, the adjustment code at the end of this program needs to change to 
 * accomodate the new pricing structure
*/
        decimal basePrice = 8m;
        Dictionary<int, decimal> discounts = new Dictionary<int, decimal>
        {
            [5] = 0.25m,
            [4] = 0.2m,
            [3] = 0.1m,
            [2] = 0.05m
        };

        List<int> booksList = books.ToList();

        decimal priceOfFive = (basePrice - (basePrice * discounts[5])) * 5;
        decimal priceOfFour = (basePrice - (basePrice * discounts[4])) * 4;
        decimal priceOfThree = (basePrice - (basePrice * discounts[3])) * 3;
        decimal priceOfTwo = (basePrice - (basePrice * discounts[2])) * 2;

        decimal price = 0;

        int countOfFives = 0;
        int countOFFours = 0;
        int countOfThrees = 0;
        int countOfTwos = 0;

        List<int> distinctBooks = booksList.Distinct().ToList();

        int countDistinct = distinctBooks.Count();
        while (countDistinct > 0)
        {
            if (countDistinct == 5)
            {
                price += priceOfFive;
                countOfFives++;
            }
            else if (countDistinct == 4)
            {
                price += priceOfFour;
                countOFFours++;
            }
            else if (countDistinct == 3)
            {
                price += priceOfThree;
                countOfThrees++;
            }
            else if (countDistinct == 2)
            {
                price += priceOfTwo;
                countOfTwos++;
            }
            else if (countDistinct == 1)
            {
                price += basePrice;
            }

            foreach (int book in distinctBooks) booksList.Remove(book);
            distinctBooks = booksList.Distinct().ToList();
            countDistinct = distinctBooks.Count();
        }

/*
 * Because the change in discount between a set of 3 and a set of 4 is twice the change between a set
 * of 4 and a set a 5, if there is a set of 5 and a set of 3, it is cheaper to turn that into 2 sets of 4
 * 
 * If the discounts change, the following code needs to change to accomodate the new pricing structure
*/
        while (countOfFives > 0 && countOfThrees > 0)
        {
            price -= priceOfFive;
            price -= priceOfThree;
            price += 2 * priceOfFour;
            countOfFives--;
            countOfThrees--;
            countOFFours += 2;
        }

        return (double)price;
    }
}