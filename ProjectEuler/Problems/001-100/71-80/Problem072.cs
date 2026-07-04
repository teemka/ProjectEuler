namespace ProjectEuler.Problems._001_100._71_80;

/// <summary>
/// Counting Fractions
/// https://projecteuler.net/problem=72
/// </summary>
public class Problem072 : IProblem
{
    public Task<string> CalculateAsync(string[] args)
    {
        if (!int.TryParse(args.FirstOrDefault(), out var size))
        {
            size = 1_000_000;
        }

        // Farey Sequence (without 0/1 and 1/1)
        var farey = Phi(size) - 1;

        return Task.FromResult(farey.ToString());
    }

    /// <summary>
    /// Totient summatory function.
    /// </summary>
    public static long Phi(int n)
    {
        var totients = TotientSieve(n);

        var sum = 0L;
        for (var i = 1; i <= n; i++)
        {
            sum += totients[i];
        }

        return sum;
    }

    /// <summary>
    /// Euler's totient of every number in [0, n], via Euler's product formula
    /// applied one prime at a time.
    /// </summary>
    public static int[] TotientSieve(int n)
    {
        var phi = new int[n + 1];
        for (var i = 0; i <= n; i++)
        {
            phi[i] = i;
        }

        for (var p = 2; p <= n; p++)
        {
            if (phi[p] != p)
            {
                // p was already reduced by a smaller prime, so it is composite
                continue;
            }

            for (var m = p; m <= n; m += p)
            {
                phi[m] -= phi[m] / p;
            }
        }

        return phi;
    }
}
