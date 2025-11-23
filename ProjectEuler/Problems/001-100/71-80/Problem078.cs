namespace ProjectEuler.Problems._001_100._71_80;

/// <summary>
/// https://projecteuler.net/problem=78
/// </summary>
public class Problem078 : IProblem
{
    private readonly List<int> p = [1];

    public Task<string> CalculateAsync(string[] args)
    {
        const int million = 1_000_000;

        // Use partition function recurrence relation
        for (var n = 1; ; n++)
        {
            var sum = 0;
            for (var k = 1; ; k++)
            {
                var sign = int.IsEvenInteger(k) ? -1 : 1;

                var g = k * (3 * k - 1) / 2;

                if (g > n)
                {
                    break;
                }

                sum += sign * this.p[n - g];

                g = k * (3 * k + 1) / 2;

                if (g > n)
                {
                    break;
                }

                sum += sign * this.p[n - g];
            }

            sum %= million;
            if (sum == 0)
            {
                return Task.FromResult(n.ToString());
            }

            this.p.Add(sum);
        }
    }
}
