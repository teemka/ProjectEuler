using System.Numerics;

namespace ProjectEuler.Problems._001_100._51_60;

/// <summary>
/// Square root convergents
/// https://projecteuler.net/problem=57
/// </summary>
public class Problem057 : IProblem
{
    public Task<string> CalculateAsync(string[] args)
    {
        var count = Enumerable.Range(1, 1000)
            .Select(x => SqaureRootOfTwoFractionApprox(x))
            .Where(x => x.Nominator.ToString().Length > x.Denominator.ToString().Length)
            .Count();

        return Task.FromResult(count.ToString());
    }

    private static Fraction SqaureRootOfTwoFractionApprox(int n)
    {
        var dn = new Fraction(1, 2);
        for (int i = 0; i < n - 1; i++)
        {
            dn = Sum(2, dn).Inverse;
        }
        return Sum(1, dn);
    }

    public class Fraction
    {
        public Fraction(BigInteger nominator, BigInteger denominator)
        {
            Nominator = nominator;
            Denominator = denominator;

            while (true)
            {
                var gcd = BigInteger.GreatestCommonDivisor(Nominator, Denominator);
                if (gcd == 1)
                    break;

                Nominator /= gcd;
                Denominator /= gcd;
            }
        }

        public BigInteger Nominator { get; }

        public BigInteger Denominator { get; }

        public override string ToString() => $"{Nominator}/{Denominator}";

        public Fraction Inverse => new(Denominator, Nominator);
    }

    public static Fraction Sum(BigInteger left, Fraction right)
    {
        var nominator = (left * right.Denominator) + right.Nominator;
        var denominator = right.Denominator;
        return new(nominator, denominator);
    }
}
