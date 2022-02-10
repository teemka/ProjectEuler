namespace ProjectEuler.Problems._001_100._41_50;

/// <summary>
/// The prime 41, can be written as the sum of six consecutive primes:
///     41 = 2 + 3 + 5 + 7 + 11 + 13
/// This is the longest sum of consecutive primes that adds to a prime below one-hundred.
///
/// The longest sum of consecutive primes below one-thousand that adds to a prime, contains 21 terms, and is equal to 953.
///
/// Which prime, below one-million, can be written as the sum of the most consecutive primes?
/// </summary>
public class Problem050 : IProblem
{
    public Task<string> CalculateAsync(string[] args)
    {
        const int million = 1_000_000;
        var primes = NumberHelper.Primes(million).ToHashSet();

        var (maxValue, consecutiveCount) = (0, 0);
        for (int i = 0; i < primes.Count - 1; i++)
        {
            for (int j = 1; j < primes.Count - i; j++)
            {
                var sum = primes.Skip(i).Take(j).Sum();
                if (sum > million)
                {
                    break;
                }

                if (j > consecutiveCount && primes.Contains(sum))
                {
                    (maxValue, consecutiveCount) = (sum, j);
                }
            }
        }

        return Task.FromResult(maxValue.ToString());
    }
}
