using Fractions;
using System.Numerics;

namespace ProjectEuler.Problems._001_100._71_80;

/// <summary>
/// Passcode derivation
/// https://projecteuler.net/problem=80
/// </summary>
public class Problem080 : IProblem
{
    private const int Iterations = 8;
    private const int NumberOfDigits = 100;
    private static readonly Fraction Half = new(1, 2);

    public Task<string> CalculateAsync(string[] args)
    {
        var sum = 0;
        for (int i = 1; i <= 100; i++)
        {
            sum += DigitSum(i);
        }

        return Task.FromResult(sum.ToString());
    }

    public static int DigitSum(int n)
    {
        var estimate = CalculateSquareRootEstimate(n, Iterations);

        if (estimate.Denominator == 1)
        {
            return 0;
        }

        var digits = GetDigitsFromLongDivision(estimate, NumberOfDigits);

        return digits.Sum();
    }

    private static Fraction CalculateSquareRootEstimate(int n, int iterationCount)
    {
        var squareRoot = (int)Math.Sqrt(n);

        // Heron's method
        var s = new Fraction(n);
        var estimate = new Fraction(squareRoot);
        for (var i = 0; i < iterationCount; i++)
        {
            estimate = Half * (estimate + s / estimate);
        }

        return estimate;
    }

    private static List<int> GetDigitsFromLongDivision(Fraction estimate, int limit)
    {
        var (a, b) = (estimate.Numerator, estimate.Denominator);

        var digits = new List<int>(limit);
        for (int i = 0; i < limit; i++)
        {
            (var quotient, a) = BigInteger.DivRem(a, b);
            digits.Add((int)quotient);
            a *= 10;
        }

        return digits;
    }
}
