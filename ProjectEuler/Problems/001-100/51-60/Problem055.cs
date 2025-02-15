using System.Numerics;

namespace ProjectEuler.Problems._001_100._51_60;

/// <summary>
/// Lychrel numbers
/// https://projecteuler.net/problem=55
/// </summary>
public class Problem055 : IProblem
{
    public Task<string> CalculateAsync(string[] args)
    {
        var result = Enumerable.Range(1, 10000).Where(x => IsLychrelNumber(x)).Count();
        return Task.FromResult(result.ToString());
    }

    private static bool IsLychrelNumber(BigInteger number, int iterations = 50)
    {
        for (var i = 0; i < iterations; i++)
        {
            number += BigInteger.Parse(number.ToString().Reverse().Concat());

            if (number.ToString().IsPalindrome())
            {
                return false;
            }
        }

        return true;
    }
}
