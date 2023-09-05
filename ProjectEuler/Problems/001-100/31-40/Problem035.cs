namespace ProjectEuler.Problems._001_100._31_40;

/// <summary>
/// The number, 197, is called a circular prime because all rotations of the digits: 197, 971, and 719, are themselves prime.
///
/// There are thirteen such primes below 100: 2, 3, 5, 7, 11, 13, 17, 31, 37, 71, 73, 79, and 97.
///
/// How many circular primes are there below one million?
/// </summary>
public class Problem035 : IProblem
{
    private readonly SieveOfErasthotenes sieve = new(1_000_000);

    public Task<string> CalculateAsync(string[] args)
    {
        var circuralPrimes = this.sieve.GetEnumerated().Where(IsCircuralPrime).ToArray();

        bool IsCircuralPrime(int n)
        {
            var number = n.ToString();
            string src = number + number;
            return Enumerable
                .Range(0, number.Length)
                .Select(x => src.Substring(x, number.Length))
                .Select(int.Parse)
                .All(this.sieve.Contains);
        }

        var result = circuralPrimes.Length;

        return Task.FromResult(result.ToString());
    }
}
