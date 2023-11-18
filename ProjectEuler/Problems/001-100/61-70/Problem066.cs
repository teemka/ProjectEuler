using Fractions;
using System.Numerics;

namespace ProjectEuler.Problems._001_100._61_70;

/// <summary>
/// https://projecteuler.net/problem=66
/// https://en.wikipedia.org/wiki/Pell%27s_equation#Fundamental_solution_via_continued_fractions
/// </summary>
public class Problem066 : IProblem
{
    public Task<string> CalculateAsync(string[] args)
    {
        var limit = 1_000; // default
        if (args.Length == 1)
        {
            limit = int.Parse(args[0]);
        }

        BigInteger max = 0;
        int dOfMax = 0;
        for (var d = 2; d <= limit; d++)
        {
            var (first, period) = Problem064.SquareRootPeriod(d);
            if (period.Count == 0)
            {
                continue;
            }

            for (var i = 1; ; i++)
            {
                var arr = period.RepeatForever().Take(i).Reverse().ToArray();
                var convergent = new Fraction(1, arr[0]);
                foreach (var integer in arr.Skip(1))
                {
                    convergent += integer;
                    convergent = convergent.Reciprocal();
                }

                convergent += first;

                var (x, y) = (convergent.Numerator, convergent.Denominator);
                if (IsEquationSolved(d, x, y))
                {
                    if (x > max)
                    {
                        max = x;
                        dOfMax = d;
                    }

                    break;
                }
            }
        }

        return Task.FromResult(dOfMax.ToString());
    }

    internal static bool IsEquationSolved(int d, BigInteger x, BigInteger y)
    {
        return (x * x) - (d * y * y) == 1;
    }
}
