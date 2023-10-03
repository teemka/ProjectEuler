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
            var period = SquareRootPeriod(i);
            if (!period.Any())
            {
                continue;
            }

            var numbers = period.Skip(1).ToArray();
            if (int.IsOddInteger(numbers.Length))
            {
                count++;
            }
        }

        return Task.FromResult(count.ToString());
    }

    internal static IEnumerable<int> SquareRootPeriod(int number)
    {
        var sqrt = Math.Sqrt(number);
        var floor = (int)Math.Floor(sqrt);

        if (sqrt == floor)
        {
            yield break;
        }

        yield return floor;

        var set = new HashSet<(int Digit, int NumeratorTerm, int Denominator)>();

        var numeratorFactor = 1;
        var numeratorTerm = floor;
        while (true)
        {
            var denominator = number - (numeratorTerm * numeratorTerm);
            var digit = (int)Math.Floor(numeratorFactor * (sqrt + numeratorTerm) / denominator);

            // Reduce the fraction
            denominator = (int)new Fraction(numeratorFactor, denominator).Denominator;

            numeratorTerm = Math.Abs(numeratorTerm - (denominator * digit));
            numeratorFactor = denominator;

            // Check if sequence repeats
            if (!set.Add((digit, numeratorTerm, denominator)))
            {
                break;
            }

            yield return digit;
        }
    }
}
