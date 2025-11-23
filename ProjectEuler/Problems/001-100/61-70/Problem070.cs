namespace ProjectEuler.Problems._001_100._61_70;

/// <summary>
/// https://projecteuler.net/problem=70
/// </summary>
public class Problem070 : IProblem
{
    private const int Limit = 10_000_000; // 10^7
    private readonly SieveOfErasthotenes sieve = new(4283); // heuristic, solved with 10_000 limit

    public Task<string> CalculateAsync(string[] args)
    {
        var primes = this.sieve.GetEnumerated().ToArray();

        var (min, nOfMin) = (double.MaxValue, 0);

        // φ(prime) cannot be a permutation of prime because they differ by one (φ(prime) = prime - 1)
        // Then search in the next best undivisible number - a multiplication of two primes.
        // Start from 345 - heuristic from tests, solved with start from 0
        for (var i = 345; i < primes.Length; i++)
        {
            var prime1 = primes[i];
            for (var j = i; j < primes.Length; j++)
            {
                var prime2 = primes[j];

                // Here we have a pair of primes - prime1 and prime2
                // Use the fact that φ(n) == φ(prime1 * prime2) == φ(prime1) * φ(prime2).
                var phi = PhiPrime(prime1) * PhiPrime(prime2);

                if (phi > Limit)
                {
                    break;
                }

                var n = prime1 * prime2;
                if (!IsPermutation(n, phi))
                {
                    continue;
                }

                var reverse = n / (double)phi;
                if (reverse >= min)
                {
                    continue;
                }

                min = reverse;
                nOfMin = n;
            }
        }

        return Task.FromResult(nOfMin.ToString());
    }

    // Phi of prime is special
    private static int PhiPrime(int prime) => prime - 1;

    private static bool IsPermutation(int a, int b) => a.GetDigits().Order().SequenceEqual(b.GetDigits().Order());
}
