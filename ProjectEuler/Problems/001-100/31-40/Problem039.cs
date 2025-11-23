namespace ProjectEuler.Problems._001_100._31_40;

/// <summary>
/// https://projecteuler.net/problem=39
/// Answer: 840
/// </summary>
public class Problem039 : IProblem
{
    public Task<string> CalculateAsync(string[] args)
    {
        var rightTriangles = new List<RightTriangle>();

        for (var i = 1; i <= 1000; i++)
        {
            for (var j = i; j <= 1000; j++)
            {
                if (i + j > 1000)
                {
                    break;
                }

                var hypotenuse = Math.Sqrt(Math.Pow(i, 2) + Math.Pow(j, 2));

                if (!double.IsInteger(hypotenuse))
                {
                    continue;
                }

                if (hypotenuse + i + j > 1000)
                {
                    break;
                }

                var rightTriangle = new RightTriangle(i, j, (int)hypotenuse);
                rightTriangles.Add(rightTriangle);
            }
        }

        var perimeter = rightTriangles
            .GroupBy(x => x.Perimeter)
            .MaxBy(x => x.Count())?.Key;

        return Task.FromResult(perimeter?.ToString() ?? "0");
    }

    private readonly struct RightTriangle(int a, int b, int c)
    {
        public int Perimeter { get; } = a + b + c;

        public override string ToString() => $"{a}, {b}, {c}";
    }
}
