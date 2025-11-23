namespace ProjectEuler.Problems._001_100._91_100;

/// <summary>
/// https://projecteuler.net/problem=91
/// </summary>
public class Problem091 : IProblem
{
    public Task<string> CalculateAsync(string[] args)
    {
        if (!int.TryParse(args.FirstOrDefault(), out var size))
        {
            size = 50;
        }

        var count = 0;
        for (var x1 = 0; x1 <= size; x1++)
        {
            for (var y1 = 0; y1 <= size; y1++)
            {
                if ((x1, y1) == (0, 0))
                {
                    continue;
                }

                for (int x2 = 0; x2 <= size; x2++)
                {
                    for (int y2 = 0; y2 <= size; y2++)
                    {
                        if ((x2, y2) == (0, 0))
                        {
                            continue;
                        }

                        if ((x1, y1) == (x2, y2))
                        {
                            continue;
                        }

                        // Calculate the lengths of the sides of the triangle
                        // Skip square root (they will be squared later)
                        var a = y1 * y1 + x1 * x1; // simplified from zero
                        var b = y2 * y2 + x2 * x2; // simplified from zero
                        var c = (y2 - y1) * (y2 - y1) + (x2 - x1) * (x2 - x1);

                        // Ensure a <= b <= c
                        if (a > b)
                        {
                            (a, b) = (b, a);
                        }

                        if (b > c)
                        {
                            (b, c) = (c, b);
                        }

                        // Pythagorean theorem check (skipped square)
                        if (a + b == c)
                        {
                            count++;
                        }
                    }
                }
            }
        }

        count /= 2; // each triangle is counted twice

        return Task.FromResult(count.ToString());
    }
}
