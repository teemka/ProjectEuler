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
            var seq = Calc(i);
            if (!seq.Any())
            {
                continue;
            }

            var numbers = seq.Skip(1).ToArray();
            if (int.IsOddInteger(numbers.Length))
            {
                count++;
            }
        }

        return Task.FromResult(count.ToString());
    }

    internal static IEnumerable<int> Calc(int number)
    {
        var sqrt = Math.Sqrt(number);
        var floor = (int)Math.Floor(sqrt);

        if (sqrt == floor)
        {
            yield break;
        }

        yield return floor;

        var set = new HashSet<(int Digit, int NumeratorTerm, int Denominator)>();

        int denominator;
        var numeratorFactor = 1;
        var numeratorTerm = floor;
        while (true)
        {
            denominator = number - (numeratorTerm * numeratorTerm);
            var digit = (int)Math.Floor(numeratorFactor * (sqrt + numeratorTerm) / denominator);
            var proper = new Fraction(numeratorFactor, denominator);
            denominator = (int)proper.Denominator;
            numeratorTerm = Math.Abs(numeratorTerm - (denominator * digit));
            numeratorFactor = denominator;

            if (!set.Add((digit, numeratorTerm, denominator)))
            {
                break;
            }

            yield return digit;
        }
    }
}
