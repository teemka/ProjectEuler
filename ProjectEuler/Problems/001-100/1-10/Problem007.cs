namespace ProjectEuler.Problems._001_100._1_10;

/// <summary>
/// By listing the first six prime numbers: 2, 3, 5, 7, 11, and 13, we can see that the 6th prime is 13.
/// What is the 10 001st prime number?
/// </summary>
public class Problem007 : IProblem
{
    public Task<string> CalculateAsync(string[] args)
    {
        var primeNo10001 = new SieveOfErasthotenes(105000).Take(10001).Last();
        return Task.FromResult(primeNo10001.ToString());
    }
}
