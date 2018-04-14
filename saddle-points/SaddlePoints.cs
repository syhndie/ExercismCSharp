using System;
using System.Collections.Generic;
using System.Linq;

public class SaddlePoints
{
    public SaddlePoints(int[,] values)
    {
    }

    public IEnumerable<Tuple<int, int>> Calculate()
    {
        throw new NotImplementedException("You need to implement this function.");
    }
}

//It's called a "saddle point" because it is greater than or equal to
//every element in its row and less than or equal to every element in
//its column.

//[Fact]
//public void Can_identify_multiple_saddle_points()
//{
//    var input = new[,]
//    {
//            { 4, 5, 4 },
//            { 3, 5, 5 },
//            { 1, 5, 4 }
//        };
//    var sut = new SaddlePoints(input);
//    var actual = sut.Calculate();
//    var expected = new[] { Tuple.Create(0, 1), Tuple.Create(1, 1), Tuple.Create(2, 1) };
//    Assert.Equal(expected, actual);
//}