using System;
using System.Linq;

namespace Problem004
{
    class Program
    {
        /// <summary>
        /// A palindromic number reads the same both ways. The largest palindrome made from the product of two 2-digit numbers is 9009 = 91 × 99.
        /// Find the largest palindrome made from the product of two 3-digit numbers.
        /// </summary>
        static void Main()
        {
            var threeDigitNumbers = Enumerable.Range(100, 899).Reverse();

            var products = from number1 in threeDigitNumbers
                           from number2 in threeDigitNumbers
                           select number1 * number2;

            var largestProduct = products
                .OrderByDescending(x => x)
                .Where(x => IsPalindrome(x.ToString()))
                .First();

            Console.WriteLine(largestProduct);
        }

        public static bool IsPalindrome(string value)
        {
            return value.SequenceEqual(value.Reverse());
        }
    }
}
