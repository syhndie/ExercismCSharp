using System;
using System.Collections.Generic;
using System.Linq;

/*
One copy of any of the five books costs $8.                   $8 per book       $8 for 1

If, however, you buy two different books, you get a 5%        $7.6 per book     $15.2 for 2
discount on those two books.

If you buy 3 different books, you get a 10% discount.         $7.2 per book     $21.6 for 3

If you buy 4 different books, you get a 20% discount.         $6.4 per book     $25.6 for 4

If you buy all 5, you get a 25% discount.                     $6 per book       $30 for 5
*/

public static class BookStore
{
    public static double Total(IEnumerable<int> books)
    {
        List<int> booksList = books.ToList();
        decimal price = 0;
        int countOfFives = 0;
        int countOfThrees = 0;

        List<int> distinctBooks = booksList.Distinct().ToList();

        int countDistinct = distinctBooks.Count();
        while (countDistinct > 0)
        {
            if (countDistinct == 5)
            {
                price += 30m;
                countOfFives++;
            }
            else if (countDistinct == 4) price += 25.6m;
            else if (countDistinct == 3)
            {
                price += 21.6m;
                countOfThrees++;
            }
            else if (countDistinct == 2) price += 15.2m;
            else if (countDistinct == 1) price += 8m;

            foreach (int book in distinctBooks) booksList.Remove(book);
            distinctBooks = booksList.Distinct().ToList();
            countDistinct = distinctBooks.Count();
        }

        while (countOfFives >0 && countOfThrees > 0)
        {
            price -= .4m;
            countOfFives--;
            countOfThrees--;
        }
       
        return (double)price;

    }
}