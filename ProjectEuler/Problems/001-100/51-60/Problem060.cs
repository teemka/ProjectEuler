using System;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectEuler.Problems._001_100._51_60
{
    public class Problem060 : IProblem
    {
        public Task<string> CalculateAsync(string[] args)
        {

            var primes = NumberHelper.Primes(1000000).ToHashSet();
            int primesCount = primes.Count;

            bool IsConcatenationPrime(int a, int b) => primes.Contains(int.Parse($"{a}{b}"));
            bool IsConcatenationPrimeArr(int[] arr) => IsConcatenationPrime(arr[0], arr[1]) && IsConcatenationPrime(arr[1], arr[0]);

            var output = primes
                .Where(x => x != 2 && x != 5)
                .ToArray()
                .Combinations(4)
                .First(x => x.Combinations(2).All(x => IsConcatenationPrimeArr(x)));

            //foreach(var permutation in output.Combinations(2))
            //{
            //    Console.WriteLine($"{permutation[0]}{permutation[1]}");
            //    Console.WriteLine($"{permutation[1]}{permutation[0]}");
            //}

            return Task.FromResult(output.Sum().ToString());
        }
    }
}
