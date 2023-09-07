namespace ProjectEuler.Problems._001_100._51_60;

public class Problem060 : IProblem
{
    private readonly SieveOfErasthotenes sieve = new(10_000);

    public Task<string> CalculateAsync(string[] args)
    {
        var target = 5; // default
        if (args.Length == 1)
        {
            _ = int.TryParse(args[0], out target);
        }

        var clique = this.Find(target);

        var sum = clique.Sum();
        return Task.FromResult(sum.ToString());
    }

    private List<int> Find(int target)
    {
        var primes = this.sieve.GetEnumerated()
            .Where(x => x != 2 && x != 5) // 2 or 5 at the end of a number result in not a prime
            .ToArray();

        // For all primes find maximal clique to which they belong
        foreach (var initialPrime in primes)
        {
            var clique = new List<int> { initialPrime };
            foreach (var prime in primes)
            {
                if (clique.All(x =>
                    this.sieve.IsPrime(new ConcatenatedNumber(x, prime).Value) &&
                    this.sieve.IsPrime(new ConcatenatedNumber(prime, x).Value)))
                {
                    clique.Add(prime);

                    if (clique.Count >= target)
                    {
                        return clique;
                    }
                }
            }
        }

        throw new Exception("Clique not found");
    }
}
