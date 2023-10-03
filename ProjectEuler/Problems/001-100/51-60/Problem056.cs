using System.Numerics;

namespace ProjectEuler.Problems._001_100._51_60;

/// <summary>
/// Powerful digit sum
/// https://projecteuler.net/problem=56
/// </summary>
public class Problem056 : IProblem
{
    public Task<string> CalculateAsync(string[] args)
    {
        BigInteger maxDigitSum = 0;
        for (int a = 1; a < 100; a++)
        {
            for (int b = 1; b < 100; b++)
            {
                var digitSum = BigInteger.Pow(a, b).DigitSum();
                if (digitSum > maxDigitSum)
                {
                    maxDigitSum = digitSum;
                }
            }
        }

        return Task.FromResult(maxDigitSum.ToString());
    }
}
