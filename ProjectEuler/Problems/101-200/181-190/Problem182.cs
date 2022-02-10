using System.Numerics;

namespace ProjectEuler.Problems._101_200._181_190;

/// <summary>
/// https://projecteuler.net/problem=182
/// </summary>
public class Problem182 : IProblem
{
    public Task<string> CalculateAsync(string[] args)
    {
        int p = 1009;
        int q = 3643;
        int n = p * q;
        int phi = (p - 1) * (q - 1);

        var expontents = Enumerable.Range(2, phi - 2)
            .Where(e => NumberHelper.GCD(e, phi) == 1)
            .TakeLast(10)
            .ToArray();

        var results = new List<(int, int)>();

        Parallel.ForEach(expontents, e =>
        {
            int count = 0;
            foreach (var m in Enumerable.Range(1, n - 2))
            {
                if (IsConcealed(m, e, n))
                {
                    if (count == 7)
                    {
                        return;
                    }

                    count++;
                }
            }

            results.Add((e, count));
        });

        return Task.FromResult(string.Empty);
    }

    private static bool IsConcealed(int message, int e, int n)
    {
        var m = new BigInteger(message);
        return BigInteger.Pow(m, e) % n == m;
    }
}
