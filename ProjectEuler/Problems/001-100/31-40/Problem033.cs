namespace ProjectEuler.Problems._001_100._31_40;

/// <summary>
/// https://projecteuler.net/problem=33
/// Answer:
/// </summary>
public class Problem033 : IProblem
{
    public Task<string> CalculateAsync(string[] args)
    {
        var fractions = new List<(int Numerator, int Denominator)>();

        var numeratorRange = Enumerable.Range(10, 90);
        foreach (var numerator in numeratorRange)
        {
            var denominatorRange = Enumerable.Range(numerator + 1, 99 - numerator);
            foreach (var denominator in denominatorRange)
            {
                if (IsCuriousFraction(numerator, denominator))
                {
                    fractions.Add((numerator, denominator));
                }
            }
        }

        var product = fractions.Aggregate((first, second) => (first.Numerator * second.Numerator, first.Denominator * second.Denominator));

        var lowestDenominator = product.Denominator / product.Numerator;

        return Task.FromResult(lowestDenominator.ToString());
    }

    private static bool IsCuriousFraction(int numerator, int denominantor)
    {
        // don't consider trivial cases
        if (IsDivisibleBy10(numerator) && IsDivisibleBy10(denominantor))
        {
            return false;
        }

        var numeratorString = numerator.ToString();
        var denominatorString = denominantor.ToString();

        var intersection = numeratorString.Intersect(denominatorString).ToHashSet();

        if (intersection.Count != 1)
        {
            return false;
        }

        var digit = intersection.First();

        var newNumerator = CreateNumberWithoutDigits(numeratorString, digit);
        var newDenominator = CreateNumberWithoutDigits(denominatorString, digit);

        if (newDenominator == 0)
        {
            return false;
        }

        return newNumerator / (double)newDenominator == numerator / (double)denominantor;
    }

    private static bool IsDivisibleBy10(int number) => number % 10 == 0;

    private static int CreateNumberWithoutDigits(string value, char digit)
    {
        var idx = value.IndexOf(digit);
        var digits = value.ToList();
        digits.RemoveAt(idx);
        var newString = string.Concat(digits);

        return int.Parse(newString);
    }
}
