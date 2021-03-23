using ProjectEuler.Extensions;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectEuler.Problems._001_100._31_40
{
    /// <summary>
    /// 145 is a curious number, as 1! + 4! + 5! = 1 + 24 + 120 = 145.

    /// Find the sum of all numbers which are equal to the sum of the factorial of their digits.

    /// Note: as 1! = 1 and 2! = 2 are not sums they are not included.
    /// </summary>
    public class Problem034 : IProblem
    {
        public Task<string> CalculateAsync(string[] args)
        {
            // 9! = 362880. Sum of factorials of digits of 9,999,999 is 7*9! = 2,540,160 
            var curiousNumbers = Enumerable.Range(3, 2_540_160)
                .Select(x => (x, sumOfDigitFactorials: x.GetDigits().Sum(d => Factorial(d))))
                .Where(x => x.x == x.sumOfDigitFactorials)
                .ToArray();

            var result = curiousNumbers.Sum(x => x.x);

            return Task.FromResult(result.ToString());
        }

        static readonly Dictionary<int, int> factorials = new() { { 0, 1 }, { 1, 1 }, { 2, 2 } };

        static int Factorial(int n)
        {
            if (factorials.ContainsKey(n))
                return factorials[n];

            var value = n * Factorial(n - 1);
            factorials[n] = value;
            return value;
        }
    }
}
