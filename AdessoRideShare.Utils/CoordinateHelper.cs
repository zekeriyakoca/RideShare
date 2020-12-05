using System;
using System.Collections.Generic;
using System.Text;

namespace AdessoRideShare.Utils
{
    public static class CoordinateHelper
    {
        // Here Logic Comes...
        //TODO : Improve performance and logic
        //TODO : Test against edge cases
        public static bool IsBetween(Coordinate first, Coordinate second, Coordinate targetFirst, Coordinate targetSecond)
        {
            return Math.Min(first.X, second.X) <= Math.Min(targetFirst.X, targetSecond.X)
                && Math.Max(first.X, second.X) >= Math.Max(targetFirst.X, targetSecond.X)
                && Math.Min(first.Y, second.Y) <= Math.Min(targetFirst.Y, targetSecond.Y)
                && Math.Max(first.Y, second.Y) >= Math.Max(targetFirst.Y, targetSecond.Y);
        }
    }

    public class Coordinate
    {
        public int X { get; set; }
        public int Y { get; set; }
    }
}
