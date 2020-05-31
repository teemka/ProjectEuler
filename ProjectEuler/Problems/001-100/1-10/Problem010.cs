using System.Linq;
using System.Threading.Tasks;

namespace ProjectEuler.Problems._001_100._1_10
{
    /// <summary>
    /// The sum of the primes below 10 is 2 + 3 + 5 + 7 = 17.
    /// Find the sum of all the primes below two million.
    /// </summary>
    public class Problem010 : IProblem
    {
        public Task<string> CalculateAsync(string[] args)
        {
            long sum = NumberHelper.Primes(2_000_000).Select(x => (long)x).Sum();
            return Task.FromResult(sum.ToString());
        }
    }
}
