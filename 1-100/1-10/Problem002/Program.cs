using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem002
{
    class Program
    {
        static void Main()
        {
            var sum = FibonacciSequence().TakeWhile(x => x <= 4_000_000).Where(x => x % 2 == 0).Sum();
            Console.WriteLine(sum);
        }

        static IEnumerable<int> FibonacciSequence()
        {
            int prev = 1;
            int current = 1;
            int temp;
            yield return prev;
            while (true)
            {
                temp = current;
                current += prev;
                yield return current;
                prev = temp;
            }
        }
    }
}
