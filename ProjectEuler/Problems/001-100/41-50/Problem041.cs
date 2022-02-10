namespace ProjectEuler.Problems._001_100._41_50;

/// <summary>
/// We shall say that an n-digit number is pandigital if it makes use of all the digits 1 to n exactly once. For example, 2143 is a 4-digit pandigital and is also prime.
/// What is the largest n-digit pandigital prime that exists?
/// </summary>
public class Problem041 : IProblem
{
    public Task<string> CalculateAsync(string[] args)
    {
        var primes = NumberHelper.Primes(999_999_999).ToArray();
        int max = 0;
        foreach (var prime in primes)
        {
            if (prime.IsPandigital() && prime > max)
            {
                max = prime;
            }
        }

        return Task.FromResult(max.ToString());
    }
}
