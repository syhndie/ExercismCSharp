using System;
using System.Collections.Generic;
using System.Linq;

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