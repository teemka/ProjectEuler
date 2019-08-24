using System;
using System.Linq;
using System.Numerics;
using CommonProblems;

namespace Problem025
{
    class Program
    {
        /// <summary>
        /// What is the index of the first term in the Fibonacci sequence to contain 1000 digits?
        /// </summary>
        static void Main()
        {
            var thousandDigits = NumberHelper.FibonacciSequenceBigInt()
                .Select((x, i) => (digits: (int)Math.Floor(BigInteger.Log10(x) + 1), index: i + 1))
                .SkipWhile(x => x.digits < 1000)
                .First();
            Console.WriteLine(thousandDigits.index);
        }
    }
}
