using Fractions;
using System.Numerics;

namespace ProjectEuler.Problems._001_100._91_100;

/// <summary>
/// https://projecteuler.net/problem=100
/// </summary>
public sealed class Problem100 : IProblem
{
    private static readonly Fraction Half = new(1, 2);

    public Task<string> CalculateAsync(string[] args)
    {
        // tried until 707372877805
        double x = 707106781186, y;
        y = .5 * (Math.Sqrt((8 * x * x) - (8 * x) + 1) - (2 * x) + 1);

        var b = (BigInteger)x; // 707106781186
        var r = (BigInteger)y; // 292893218813

        var outputs = new List<(BigInteger B, BigInteger R, Fraction P)>();
        var lastP = Fraction.Zero;
        while (true)
        {
            var p = P2(b, r);

            if (p == Half)
            {
                outputs.Add((b, r, p));
                break;
            }

            if (p > Half)
            {
                b--;
                r++;
            }

            if (p < Half)
            {
                b++;
                r--;
            }

            if (lastP > Half && p < Half)
            {
                b++;
                lastP = p;
            }

            if (lastP < Half && p > Half)
            {
                r++;
                lastP = p;
            }
        }

        static Fraction P2(BigInteger b, BigInteger r) => new Fraction(b, b + r) * new Fraction(b - 1, b + r - 1);

        return Task.FromResult(outputs[^1].ToString());
    }

    public static double P (double b, double r) => ((b * b) - b) / ((b * b) + (2 * b * r) + (r * r) - b - r);
}
