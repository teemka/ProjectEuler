using Fractions;

namespace ProjectEuler.Problems._001_100._71_80;

/// <summary>
/// https://projecteuler.net/problem=71
/// Answer: 428570
/// </summary>
public class Problem071 : IProblem
{
    public Task<string> CalculateAsync(string[] args)
    {
        if (!int.TryParse(args.FirstOrDefault(), out var size))
        {
            size = 1_000_000;
        }

        var result = Calculate(size);

        return Task.FromResult(result.Numerator.ToString());
    }

    internal static Fraction Calculate(int size)
    {
        var target = new Fraction(3, 7);
        var best = new Fraction(1, size);

        for (var denominator = size; denominator > 1; denominator--)
        {
            var start = (int)(denominator * (double)target);
            for (var numerator = start; numerator < size; numerator++)
            {
                var current = new Fraction(numerator, denominator, normalize: false);
                if (current >= target)
                {
                    break;
                }

                if (current > best)
                {
                    best = current;
                }
            }
        }

        return best.Reduce();
    }
}
