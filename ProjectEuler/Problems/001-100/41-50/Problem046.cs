namespace ProjectEuler.Problems._001_100._41_50;

/// <summary>
/// https://projecteuler.net/problem=46
/// </summary>
public class Problem046 : IProblem
{
    private static readonly List<long> Primes = [];

    public Task<string> CalculateAsync(string[] args)
    {
        long curentNumber = 2;
        while (true)
        {
            var isPrime = true;
            var currentRoot = Math.Sqrt(curentNumber);
            foreach (var cachedPrime in Primes)
            {
                if (curentNumber % cachedPrime == 0)
                {
                    isPrime = false;
                    break;
                }

                if (cachedPrime > currentRoot)
                {
                    break;
                }
            }

            if (isPrime)
            {
                Primes.Add(curentNumber);
            }
            else if (curentNumber % 2 == 1)
            {
                // current number is odd composite number
                var result = CheckGoldbachsOtherConjecture(curentNumber);

                if (!result)
                {
                    return Task.FromResult(curentNumber.ToString());
                }
            }

            curentNumber++;
        }
    }

    private static bool CheckGoldbachsOtherConjecture(long currentNumber)
    {
        // check from the last prime
        for (var i = Primes.Count - 1; i >= 0; i--)
        {
            var prime = Primes[i];
            var rest = currentNumber - prime;

            if (double.IsInteger(Math.Sqrt(rest / 2)))
            {
                return true;
            }
        }

        return false;
    }
}
