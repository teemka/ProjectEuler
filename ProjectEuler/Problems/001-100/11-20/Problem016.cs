using System.Numerics;

namespace ProjectEuler.Problems._001_100._11_20;

/// <summary>
/// 2^15 = 32768 and the sum of its digits is 3 + 2 + 7 + 6 + 8 = 26.

/// What is the sum of the digits of the number 2^1000?
/// </summary>
public class Problem016 : IProblem
{
    public Task<string> CalculateAsync(string[] args)
    {
        var result = BigInteger.Pow(2, 1000);
        var digitSum = result.ToString().Select(x => int.Parse(x.ToString())).Sum();
        return Task.FromResult(digitSum.ToString());
    }
}
