using Fractions;

namespace ProjectEuler.Problems._001_100._61_70;

/// <summary>
/// https://projecteuler.net/problem=64
/// </summary>
public class Problem064 : IProblem
{
    public Task<string> CalculateAsync(string[] args)
    {
        var count = 0;
        for (var i = 2; i <= 10_000; i++)
        {
            var (_, period) = SquareRootPeriod(i);
            if (!period.Any())
            {
                continue;
            }

            if (int.IsOddInteger(period.Count))
            {
                count++;
            }
        }

        return Task.FromResult(count.ToString());
    }

    internal static (int FirstInteger, IReadOnlyCollection<int> Period) SquareRootPeriod(int number)
    {
        var sqrt = Math.Sqrt(number);
        var firstInteger = (int)Math.Floor(sqrt);

        if (sqrt == firstInteger)
        {
            return (firstInteger, Array.Empty<int>());
        }

        var set = new HashSet<(int Digit, int NumeratorTerm, int Denominator)>();
        var period = new List<int>();

        var numeratorFactor = 1;
        var numeratorTerm = firstInteger;
        while (true)
        {
            var denominator = number - (numeratorTerm * numeratorTerm);
            var integer = (int)Math.Floor(numeratorFactor * (sqrt + numeratorTerm) / denominator);

            // Reduce the fraction
            denominator = (int)new Fraction(numeratorFactor, denominator).Denominator;

            numeratorTerm = Math.Abs(numeratorTerm - (denominator * integer));
            numeratorFactor = denominator;

            // Check if sequence repeats
            if (!set.Add((integer, numeratorTerm, denominator)))
            {
                break;
            }

            period.Add(integer);
        }

        return (firstInteger, period);
    }
}
