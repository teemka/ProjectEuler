namespace ProjectEuler.Problems._001_100._71_80;

/// <summary>
/// https://projecteuler.net/problem=77
/// </summary>
public class Problem077 : IProblem
{
    private readonly Dictionary<(int N, int Index), int> cache = new();
    private readonly int[] primes;

    public Problem077()
    {
        this.primes = new SieveOfErasthotenes(1_000).GetEnumerated().ToArray();
    }

    public Task<string> CalculateAsync(string[] args)
    {
        var size = 5_000; // default
        if (args.Length == 1)
        {
            size = int.Parse(args[0]);
        }

        var i = 4; // first summable prime
        for (; ; i++)
        {
            var result = this.PrimeSummations(i);

            if (result > size)
            {
                break;
            }
        }

        return Task.FromResult(i.ToString());
    }

    private int PrimeSummations(int n, int index = 0)
    {
        if (this.cache.TryGetValue((n, index), out var summations))
        {
            return summations;
        }

        for (int i = index; i < this.primes.Length; i++)
        {
            var prime = this.primes[i];
            var val = n - prime;

            if (val < 0)
            {
                break;
            }

            if (val == 0)
            {
                summations++;
                break;
            }

            summations += this.PrimeSummations(val, i);
        }

        this.cache.Add((n, index), summations);

        return summations;
    }
}
