using System;
using System.Linq;
using CommonProblems;

namespace Problem036
{
    class Program
    {
        /// <summary>
        /// The decimal number, 585 = 10010010012 (binary), is palindromic in both bases.

        /// Find the sum of all numbers, less than one million, which are palindromic in base 10 and base 2.

        /// (Please note that the palindromic number, in either base, may not include leading zeros.)
        /// </summary>
        static void Main()
        {
            long sum = Enumerable.Range(1, 999_999)
                .Where(x => x.ToString().IsPalindrome() && Convert.ToString(x, 2).IsPalindrome())
                .Select(x => (long)x)
                .Sum();

            Console.WriteLine(sum);
        }
    }
}
