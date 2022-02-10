using System.Numerics;

namespace ProjectEuler.Problems._001_100._11_20;

/// <summary>
/// n! means n × (n − 1) × ... × 3 × 2 × 1
///
/// For example, 10! = 10 × 9 × ... × 3 × 2 × 1 = 3628800,
/// and the sum of the digits in the number 10! is 3 + 6 + 2 + 8 + 8 + 0 + 0 = 27.
///
/// Find the sum of the digits in the number 100!
/// </summary>
public class Problem020 : IProblem
{
    public Task<string> CalculateAsync(string[] args)
    {
        var factorial = BigInteger.One;
        for (int i = 1; i <= 100; i++)
        {
            factorial *= i;
        }

        var sum = factorial.ToString().Select(x => int.Parse(x.ToString())).Sum();
        return Task.FromResult(sum.ToString());
    }
}
