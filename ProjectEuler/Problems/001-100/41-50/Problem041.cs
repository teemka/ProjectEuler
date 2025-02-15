namespace ProjectEuler.Problems._001_100._41_50;

/// <summary>
/// We shall say that an n-digit number is pandigital if it makes use of all the digits 1 to n exactly once. For example, 2143 is a 4-digit pandigital and is also prime.
/// What is the largest n-digit pandigital prime that exists?
/// </summary>
public class Problem041 : IProblem
{
    public Task<string> CalculateAsync(string[] args)
    {
        var largestPandigitalPrime = Solve();

        return Task.FromResult(largestPandigitalPrime.ToString());
    }

    private static long Solve()
    {
        // 8-digit and 9-digit pandigital numbers are divisible by 3 (sum of digits)
        // So the greatest possible is 7-digit
        var primes = new SieveOfErasthotenes(9_999_999).GetEnumerated().Reverse().ToArray();

        return primes.FirstOrDefault(prime => prime.IsPandigital());
    }
}
