using System.Threading.Tasks;

namespace ProjectEuler.Problems._001_100._41_50
{
    /// <summary>
    /// The series, 1^1 + 2^2 + 3^3 + ... + 10^10 = 10405071317.

    /// Find the last ten digits of the series, 1^1 + 2^2 + 3^3 + ... + 1000^1000.
    /// </summary>
    public class Problem048 : IProblem
    {
        public Task<string> CalculateAsync(string[] args)
        {
            long result = 0;
            long modulo = 10000000000;

            for (int i = 1; i <= 1000; i++)
            {
                long temp = i;
                for (int j = 1; j < i; j++)
                {
                    temp *= i;
                    if (temp >= long.MaxValue / 1000)
                    {
                        temp %= modulo;
                    }
                }

                result += temp;
                result %= modulo;
            }

            return Task.FromResult(result.ToString());
        }
    }
}
