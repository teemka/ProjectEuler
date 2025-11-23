namespace ProjectEuler.Problems._001_100._81_90;

/// <summary>
/// https://projecteuler.net/problem=85
/// </summary>
public class Problem085 : IProblem
{
    public Task<string> CalculateAsync(string[] args)
    {
        if (!int.TryParse(args.FirstOrDefault(), out var target))
        {
            target = 2_000_000; // default value
        }

        var closestArea = 0;
        var closest = long.MaxValue;
        for (int i = 1; i < 100; i++)
        {
            for (int j = 1; j < 100; j++)
            {
                var squares = GetSquares(i, j);
                if (squares > target)
                {
                    break;
                }

                if (Math.Abs(target - squares) < closest)
                {
                    closestArea = i * j;
                    closest = Math.Abs(target - squares);
                }
            }
        }

        return Task.FromResult(closestArea.ToString());
    }

    public static long GetSquares(int x, int y) =>
        NumberHelper.TriangleNumber(x) * NumberHelper.TriangleNumber(y);
}
