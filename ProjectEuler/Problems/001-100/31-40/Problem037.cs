namespace ProjectEuler.Problems._001_100._31_40;

/// <summary>
/// The number 3797 has an interesting property. Being prime itself, it is possible to continuously remove digits from left to right, and remain prime at each stage: 3797, 797, 97, and 7. Similarly we can work from right to left: 3797, 379, 37, and 3.
///
/// Find the sum of the only eleven primes that are both truncatable from left to right and right to left.
///
/// NOTE: 2, 3, 5, and 7 are not considered to be truncatable primes.
/// </summary>
public class Problem037 : IProblem
{
    private readonly SieveOfErasthotenes sieve = new(upperLimit: 1_000_000);

    public Task<string> CalculateAsync(string[] args)
    {
        var primes = this.sieve
            .GetEnumerated()
            .Skip(4) // skip single digit primes
            .ToArray();

        var output = new HashSet<int>();
        foreach (var prime in primes)
        {
            if (this.IsTruncable(prime))
            {
                output.Add(prime);
            }

            if (output.Count == 11)
            {
                break;
            }
        }

        var sum = output.Sum();
        return Task.FromResult(sum.ToString());
    }

    private bool IsTruncable(int prime)
    {
        var rightToLeft = prime;
        var leftToRight = 0;
        var i = 0;
        while (true)
        {
            (rightToLeft, var remainder) = Math.DivRem(rightToLeft, 10);

            if (rightToLeft == 0)
            {
                break;
            }

            leftToRight += remainder * (int)Math.Pow(10, i);

            var isTruncable =
                this.sieve.IsPrime(rightToLeft) &&
                this.sieve.IsPrime(leftToRight);

            if (!isTruncable)
            {
                return false;
            }

            i++;
        }

        return true;
    }
}
