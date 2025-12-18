using Fractions;

namespace ProjectEuler.Problems._001_100._51_60;

/// <summary>
/// Square root convergents
/// https://projecteuler.net/problem=57
/// </summary>
public class Problem057 : IProblem
{
    public Task<string> CalculateAsync(string[] args)
    {
        var count = SqaureRootOfTwoFractionApproxMinus1()
            .Take(1000)
            .Select(x => Fraction.One + x)
            .Count(x => x.Numerator.DigitCount() > x.Denominator.DigitCount());

        return Task.FromResult(count.ToString());
    }

    internal static IEnumerable<Fraction> SqaureRootOfTwoFractionApproxMinus1()
    {
        var dn = new Fraction(1, 2);
        while (true)
        {
            yield return dn;
            dn = (Fraction.Two + dn).Reciprocal();
        }
    }
}
