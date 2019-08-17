using System;

namespace Problem015
{
    class Program
    {
        /// <summary>
        /// Starting in the top left corner of a 2×2 grid, and only being able to move to the right and down, there are exactly 6 routes to the bottom right corner.
        /// How many such routes are there through a 20×20 grid?
        /// </summary>
        static void Main()
        {
            Console.WriteLine(BinomialCoefficient(40, 20));
        }

        static decimal BinomialCoefficient(int n, int k)
        {
            decimal result = 1;
            for (int i = 1; i <= k; i++)
            {
                result *= n - (k - i);
                result /= i;
            }
            return result;
        }
    }
}
