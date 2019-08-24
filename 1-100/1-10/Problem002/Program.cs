using CommonProblems;
using System;
using System.Linq;

namespace Problem002
{
    class Program
    {
        static void Main()
        {
            var sum = NumberHelper.FibonacciSequence().TakeWhile(x => x <= 4_000_000).Where(x => x % 2 == 0).Sum();
            Console.WriteLine(sum);
        }
    }
}
