namespace ProjectEuler.Problems._001_100._71_80;

/// <summary>
/// https://projecteuler.net/problem=75
/// </summary>
public class Problem075 : IProblem
{
    public Task<string> CalculateAsync(string[] args)
    {
        if (!int.TryParse(args.FirstOrDefault(), out var limit))
        {
            limit = 1_500_000;
        }

        var perimeters = new List<int>();

        // Use Euclid's formula to generate triplets
        for (var n = 1; n < Math.Sqrt((double)limit / 2); n++)
        {
            for (var m = n + 1; m < Math.Sqrt((double)limit / 2); m++)
            {
                // Numbers are coprime
                if (NumberHelper.GCD(m, n) != 1)
                {
                    continue;
                }

                // Exactly one of them is even (sum is not even)
                if (int.IsEvenInteger(m + n))
                {
                    continue;
                }

                var perimeter = CalculateRightTrianglePerimeter(m, n);

                // Create multiples
                for (var k = 1; ; k++)
                {
                    var multiple = perimeter * k;

                    if (multiple > limit)
                    {
                        break;
                    }

                    perimeters.Add(multiple);
                }
            }
        }

        var result = perimeters
            .GroupBy(x => x)
            .Count(x => x.Count() == 1);

        return Task.FromResult(result.ToString());
    }

    private static int CalculateRightTrianglePerimeter(int m, int n)
    {
        // Euclid's formula
        var a = m * m - n * n;
        var b = 2 * m * n;
        var c = m * m + n * n;

        return a + b + c;
    }
}
