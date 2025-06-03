
namespace ProjectEuler.Problems._001_100._81_90;

public class Problem085 : IProblem
{
    public Task<string> CalculateAsync(string[] args)
    {
        if (!int.TryParse(args.FirstOrDefault(), out var target))
        {
            target = 2_000_000; // default value
        }

        var closestArea = 0;
        var closest = int.MaxValue;
        for (int i = 1; i < 1000; i++)
        {
            for (int j = 1; j < 1000; j++)
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

    public static int GetSquares(int x, int y)
    {
        var sum = 0;
        for (int i = 1; i <= x; i++)
        {
            for (int j = 1; j <= y; j++)
            {
                var a = x - i + 1;
                var b = y - j + 1;
                sum += a * b;
            }
        }

        return sum;
    }
}
