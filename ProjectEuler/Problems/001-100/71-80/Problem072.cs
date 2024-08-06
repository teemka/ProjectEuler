using Fractions;

namespace ProjectEuler.Problems._001_100._71_80;

/// <summary>
/// Counting Fractions
/// https://projecteuler.net/problem=72
/// </summary>
public class Problem072 : IProblem
{
    public Task<string> CalculateAsync(string[] args)
    {
        if (!int.TryParse(args.FirstOrDefault(), out var size))
        {
            size = 1_000_000;
        }

        // Farey Sequence (without 0/1 and 1/1)
        var farey = Phi(size) - 1;

        return Task.FromResult(farey.ToString());
    }

    /// <summary>
    /// Totient summatory function.
    /// </summary>
    public static long Phi(int n)
    {
        var sum = 0L;
        for (int i = 1; i <= n; i++)
        {
            sum += EulersTotient(i);
        }

        return sum;
    }

    public static int EulersTotient(int n)
    {
        // Euler's product formula
        var factors = n.PrimeFactors();
        var product = new Fraction(n, 1);
        foreach (var factor in factors)
        {
            product *= Fraction.One - new Fraction(1, factor, false);
        }

        return product.ToInt32();
    }
}
