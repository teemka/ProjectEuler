using System.Linq;
using System.Threading.Tasks;

namespace ProjectEuler.Problems._001_100._1_10
{
    /// <summary>
    /// 2520 is the smallest number that can be divided by each of the numbers from 1 to 10 without any remainder.
    /// What is the smallest positive number that is evenly divisible by all of the numbers from 1 to 20?
    /// Answer: 232792560
    /// </summary>
    public class Problem005 : IProblem
    {
        public Task<string> CalculateAsync(string[] args)
        {
            var divisors = Enumerable.Range(1, 20).ToArray();

            int value = 20;
            while (!IsEvenlyDivisible(value, divisors))
                value++;

            return Task.FromResult(value.ToString());
        }

        public static bool IsEvenlyDivisible(int value, int[] divisors)
        {
            return divisors.All(divisor => value % divisor == 0);
        }
    }
}
