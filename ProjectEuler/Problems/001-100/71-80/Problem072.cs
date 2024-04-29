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

        HashSet<Fraction> set = [];

        // Use primes
        for (int numerator = 1; numerator <= size; numerator++)
        {
            for (int denominator = 1; denominator <= size; denominator++)
            {
                if (numerator < denominator)
                {
                    set.Add(new Fraction(numerator, denominator));
                }
            }
        }

        return Task.FromResult(set.Count.ToString());
    }
}
