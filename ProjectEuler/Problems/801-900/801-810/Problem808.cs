using System.Diagnostics;

namespace ProjectEuler.Problems._801_900._801_810;

/// <summary>
/// https://projecteuler.net/problem=808
/// </summary>
internal sealed class Problem808 : IProblem
{
    private readonly HashSet<long> reversiblePrimeSquares = [];
    private readonly SieveOfErasthotenes primes = new();

    public Task<string> CalculateAsync(string[] args)
    {
        foreach (var prime in this.primes)
        {
            var square = (long)Math.Pow(prime, 2);

            // IsPalindrome
            var reversed = square.Reverse();
            if (reversed == square)
            {
                continue;
            }

            var secondPrimeCandidate = Math.Sqrt(reversed);

            if (!double.IsInteger(secondPrimeCandidate))
            {
                continue;
            }

            var candidateInteger = (int)secondPrimeCandidate;

            if (!this.primes.IsPrime(candidateInteger))
            {
                continue;
            }

            this.reversiblePrimeSquares.Add(square);
            this.reversiblePrimeSquares.Add(reversed);

            if (this.reversiblePrimeSquares.Count < 50)
            {
                continue;
            }

            var sum = this.reversiblePrimeSquares.Sum();
            return Task.FromResult(sum.ToString());
        }

        throw new UnreachableException();
    }
}
