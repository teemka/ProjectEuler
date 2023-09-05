using Microsoft.Extensions.Logging;

namespace ProjectEuler.Problems._001_100._51_60;

public class Problem060 : IProblem
{
    private readonly ILogger<Problem060> logger;
    private readonly SieveOfErasthotenes sieve = new();

    public Problem060(ILogger<Problem060> logger)
    {
        this.logger = logger;
    }

    public Task<string> CalculateAsync(string[] args)
    {
        bool IsConcatenationPrime(long a, long b) => this.sieve.Contains(long.Parse($"{a}{b}"));
        bool IsConcatenationPrimeArr(long[] arr) => IsConcatenationPrime(arr[0], arr[1]) && IsConcatenationPrime(arr[1], arr[0]);

        var output = this.sieve
            .GetEnumerated()
            .Where(x => x != 2 && x != 5)
            .ToArray()
            .Combinations(4)
            .First(x => x.Combinations(2).All(x => IsConcatenationPrimeArr(x)));

        foreach (var permutation in output.Combinations(2))
        {
            this.logger.LogDebug("{perm0}{perm1}", permutation[0], permutation[1]);
            this.logger.LogDebug("{perm1}{perm0}", permutation[1], permutation[0]);
        }

        return Task.FromResult(output.Sum().ToString());
    }
}
