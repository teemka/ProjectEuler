using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace Problem017
{
    class Program
    {
        /// <summary>
        /// If the numbers 1 to 5 are written out in words: one, two, three, four, five, then there are 3 + 3 + 5 + 4 + 4 = 19 letters used in total.
        /// If all the numbers from 1 to 1000 (one thousand) inclusive were written out in words, how many letters would be used?
        /// NOTE: Do not count spaces or hyphens.For example, 342 (three hundred and forty-two) contains 23 letters and 115 (one hundred and fifteen) contains 20 letters.
        /// The use of "and" when writing out numbers is in compliance with British usage.
        /// </summary>
        static void Main()
        {
            var names = Enumerable.Range(1, 1000).Select(x => PrintNumber(x));
            var sum = names.Select(x => x.Replace(" ", "").Replace("-", "").Count()).Sum();
            Console.WriteLine(sum);
        }

        static readonly IReadOnlyDictionary<int, string> numberNames = new ReadOnlyDictionary<int, string>(new Dictionary<int, string>
        {
            { 1, "one" },
            { 2, "two" },
            { 3, "three" },
            { 4, "four" },
            { 5, "five" },
            { 6, "six" },
            { 7, "seven" },
            { 8, "eight" },
            { 9, "nine" },
            { 10, "ten" },
            { 11, "eleven" },
            { 12, "twelve" },
            { 13, "thirteen" },
            { 14, "fourteen" },
            { 15, "fifteen" },
            { 16, "sixteen" },
            { 17, "seventeen" },
            { 18, "eighteen" },
            { 19, "nineteen" },
            { 20, "twenty" },
            { 30, "thirty" },
            { 40, "forty" },
            { 50, "fifty" },
            { 60, "sixty" },
            { 70, "seventy" },
            { 80, "eighty" },
            { 90, "ninety" }
        });

        static string PrintNumber(int n)
        {
            var terms = new List<string>();
            var thousands = Math.DivRem(n, 1000, out n);
            if (thousands > 0)
                terms.Add($"{numberNames[thousands]} thousand");
            var hundreds = Math.DivRem(n, 100, out n);
            if (hundreds > 0)
                terms.Add($"{numberNames[hundreds]} hundred");
            if (n == 0)
                ; // do nothing
            else if (n <= 20)
                terms.Add(numberNames[n]);
            else
            {
                var tens = Math.DivRem(n, 10, out n);
                var tensName = numberNames[tens * 10];
                if (n > 0)
                    tensName += $"-{numberNames[n]}";
                terms.Add(tensName);
            }

            return string.Join(" and ", terms);
        }
    }
}
