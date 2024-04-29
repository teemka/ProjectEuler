using Fractions;

namespace ProjectEuler.Problems._001_100._71_80;

/// <summary>
/// Counting Fractions
/// https://projecteuler.net/problem=72
/// </summary>
public class Problem072 : IProblem
{
    public Task<string> CalculateAsync(string[] args)
    {
        if (!int.TryParse(args.FirstOrDefault(), out var size))
        {
            size = 1_000;
        }

        IPrimes primes = new SieveOfErasthotenes(size);

        var count = 0;
        for (int denominator = size; denominator > 2; denominator--)
        {
            count++; // 1 / denominator

            var half = denominator / 2;
            foreach (var prime in primes)
            {
                if (prime > half)
                {
                    break;
                }

                var fraction = new Fraction(prime, denominator, normalize: false);

                if (fraction.Reduce() == fraction)
                {
                    count++;
                }
            }
        }

        count *= 2;
        count++;

        return Task.FromResult(count.ToString());
    }
}
