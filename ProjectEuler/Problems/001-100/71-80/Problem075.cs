using System.Runtime.InteropServices;

namespace ProjectEuler.Problems._001_100._71_80;

/// <summary>
/// https://projecteuler.net/problem=75
/// Answer:
/// </summary>
public class Problem075 : IProblem
{
    public Task<string> CalculateAsync(string[] args)
    {
        if (!int.TryParse(args.FirstOrDefault(), out var limit))
        {
            limit = 1_500_000;
        }

        var rightTriangles = new HashSet<RightTriangle>();

        // TODO: check the limit
        // Use Euclid's formula to generate triplets
        for (var n = 1; n < Math.Sqrt(limit); n++)
        {
            for (var m = n + 1;; m++)
            {
                if (NumberHelper.GCD(m, n) != 1)
                {
                    continue;
                }

                var rightTriangle = CreateRightTriangle(m, n);

                if (rightTriangle.CalculatePerimeter() > limit)
                {
                    break;
                }
                rightTriangles.Add(rightTriangle);

                // Create multiples
                for (var k = 2;; k++)
                {
                    var multiple = rightTriangle.CreateMultiple(k);

                    if (multiple.CalculatePerimeter() > limit)
                    {
                        break;
                    }
                    rightTriangles.Add(multiple);
                }
            }
        }

        var result = rightTriangles
            .Select(x => x.CalculatePerimeter())
            .GroupBy(x => x)
            .Count(x => x.Count() == 1);

        return Task.FromResult(result.ToString());
    }

    private static RightTriangle CreateRightTriangle(int m, int n)
    {
        var a = m * m - n * n;
        var b = 2 * m * n;
        var c = m * m + n * n;

        if (a > b)
        {
            (a, b) = (b, a);
        }

        return new(a, b, c);
    }

    private readonly record struct RightTriangle(int A, int B, int C)
    {
        public int CalculatePerimeter() => this.A + this.B + this.C;

        public RightTriangle CreateMultiple(int k) => new(this.A * k, this.B * k, this.C * k);
    }
}
