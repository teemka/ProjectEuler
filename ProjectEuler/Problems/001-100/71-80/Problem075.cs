namespace ProjectEuler.Problems._001_100._71_80;

/// <summary>
/// https://projecteuler.net/problem=75
/// Answer:
/// </summary>
public class Problem075 : IProblem
{
    private static readonly int UpperLimit = 750_000;

    public Task<string> CalculateAsync(string[] args)
    {
        var rightTriangles = new List<RightTriangle>();

        var range = Enumerable.Range(1, UpperLimit).Select(x => (long)x);
        var squares = SquaresSequence().Take(UpperLimit).ToArray();

        foreach (var a in range)
        {
            var a2 = (long)Math.Pow(a, 2);
            var limit = a2 / 2;
            var b = a;
            while (true)
            {
                if (b > limit)
                {
                    break;
                }

                var legsSum = a + b;
                if (legsSum > 1_500_000)
                {
                    break;
                }

                var b2 = (long)Math.Pow(b, 2);
                var hypotenuse = Math.Sqrt(a2 + b2);
                if (hypotenuse + legsSum > 1_500_000)
                {
                    break;
                }

                var hypCeiling = Math.Ceiling(hypotenuse);
                if (hypCeiling != hypotenuse)
                {
                    var candidateB = squares[(int)hypCeiling];
                    b = b <= candidateB ? b + 1 : candidateB;
                    continue;
                }

                var rightTriangle = new RightTriangle(a, b, (long)hypotenuse);
                rightTriangles.Add(rightTriangle);
                b++;
            }
        }

        var singularIntRighTriangles = rightTriangles
            .GroupBy(x => x.Perimeter)
            .Where(x => x.Count() == 1)
            .ToArray();

        return Task.FromResult(singularIntRighTriangles.Length.ToString());
    }

    private static IEnumerable<long> SquaresSequence(long n = 1)
    {
        while (true)
        {
            yield return (long)Math.Pow(n, 2);
            n++;
        }
    }

    private readonly struct RightTriangle
    {
        public readonly long A;
        public readonly long B;
        public readonly long C;

        public RightTriangle(long a, long b, long c)
        {
            this.A = a;
            this.B = b;
            this.C = c;
            this.Perimeter = a + b + c;
        }

        public long Perimeter { get; }

        public override string ToString() => $"{this.A}, {this.B}, {this.C}";
    }
}
