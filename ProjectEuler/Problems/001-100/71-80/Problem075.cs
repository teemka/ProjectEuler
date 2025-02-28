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

# if DEBUG
        var rightTriangles = new List<RightTriangle>();
#else
        Dictionary<long, int> countByPerimeter = new();
#endif


        var range = Enumerable.Range(1, limit / 2).Select(x => (long)x);

        foreach (var a in range)
        {
            var a2 = a * a;
            var b = a;
            while (true)
            {
                if (b > limit)
                {
                    break;
                }

                var legsSum = a + b;
                if (legsSum > limit)
                {
                    break;
                }

                var b2 = b * b;
                var hypotenuse = Math.Sqrt(a2 + b2);
                if (hypotenuse + legsSum > limit)
                {
                    break;
                }

                var hypCeiling = Math.Ceiling(hypotenuse);
                if (hypCeiling != hypotenuse)
                {
                    b++;
                    continue;
                }

                var rightTriangle = new RightTriangle(a, b, (long)hypotenuse);
# if DEBUG
                rightTriangles.Add(rightTriangle);
#else
                ref var count = ref CollectionsMarshal.GetValueRefOrAddDefault(countByPerimeter, rightTriangle.Perimeter, out _);
                count++;
#endif
                b++;
            }
        }

        var result = 0;
#if DEBUG
        var singularIntRightTriangles = rightTriangles
            .GroupBy(x => x.Perimeter)
            .Where(x => x.Count() == 1)
            .ToArray();
        result = singularIntRightTriangles.Length;
#else
        result = countByPerimeter.Count(x => x.Value == 1);
#endif

        return Task.FromResult(result.ToString());
    }

    private readonly struct RightTriangle(long a, long b, long c)
    {
        public long Perimeter { get; } = a + b + c;

        public override string ToString() => $"{a}, {b}, {c}";
    }
}
