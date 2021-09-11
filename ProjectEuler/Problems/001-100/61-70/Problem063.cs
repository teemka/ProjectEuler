using System.Numerics;
using System.Threading.Tasks;

namespace ProjectEuler.Problems._001_100._61_70
{
    /// <summary>
    /// https://projecteuler.net/problem=63
    /// </summary>
    public class Problem063 : IProblem
    {
        public Task<string> CalculateAsync(string[] args)
        {
            int expBase = 1;
            int count = 0;
            while (expBase < 10) // only take numbers under 10 into account
            {
                int exp = 1;
                while (true)
                {
                    var result = BigInteger.Pow(expBase, exp);
                    var resultDigitsCount = result.ToString().Length;
                    if (resultDigitsCount == exp)
                    {
                        count++;
                    }
                    else if (resultDigitsCount < exp)
                    {
                        break;
                    }

                    exp++;
                }
                expBase++;
            }

            return Task.FromResult(count.ToString());
        }
    }
}
