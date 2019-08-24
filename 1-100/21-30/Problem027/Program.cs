using System;
using System.Diagnostics;
using System.Linq;
using CommonProblems;

namespace Problem027
{
    class Program
    {
        /// <summary>
        /// 
        /// </summary>
        static void Main()
        {
            var aCandidates = Enumerable.Range(-999, 1999);
            var bCandidates = Enumerable.Range(-1000, 2001);

            var result = aCandidates.CartesianProduct(bCandidates)
                .Select(x => (x.a, x.b, max: MaximumNumberOfPrimes(x.a, x.b)))
                .OrderByDescending(x => x.max)
                .ToList();

            var max = result.First();
            Console.WriteLine(max.a * max.b);
        }

        static int MaximumNumberOfPrimes(int a, int b)
        {
            int Equation(int n) => n * n + a * n + b;
            int i = 0;
            while (Equation(i).IsPrime())
                i++;
            return i;
        }
    }
}
