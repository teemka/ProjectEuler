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

        var result = MaxSum(million);

        return Task.FromResult(result.ToString());
    }

    internal static long MaxSum(int limit)
    {
        var primes = new SieveOfErasthotenes(limit);
        var arr = primes.GetEnumerated().ToArray();

        var maxSum = 0L;
        var maxConsecutiveCount = 0;
        for (int i = 0; i < arr.Length - 1; i++)
        {
            var sum = arr[i];
            for (int j = i + 1; j < arr.Length - i; j++)
            {
                sum += arr[j];

                if (sum > limit)
                {
                    break;
                }

                var count = j - i + 1;
                if (count > maxConsecutiveCount && primes.IsPrime(sum))
                {
                    maxSum = sum;
                    maxConsecutiveCount = count;
                }
            }
        }

        return maxSum;
    }
}
