using Fractions;
using System.Collections.Generic;
using System.Numerics;

namespace ProjectEuler.Problems._001_100._71_80;

/// <summary>
/// Passcode derivation
/// https://projecteuler.net/problem=80
/// </summary>
public class Problem080 : IProblem
{
    private const int NumberOfDigits = 100;

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
        var estimate = new Fraction(n, 1).Sqrt(accuracy: NumberOfDigits);

        if (estimate.Denominator == 1)
        {
            return 0;
        }

        var (a, b) = (estimate.Numerator, estimate.Denominator);

        // Long division
        var sum = 0;
        for (int i = 0; i < NumberOfDigits; i++)
        {
            (var quotient, a) = BigInteger.DivRem(a, b);
            sum += (int)quotient;
            a *= 10;
        }

        return sum;
    }
}
