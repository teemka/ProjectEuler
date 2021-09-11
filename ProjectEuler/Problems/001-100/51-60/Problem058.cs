using ProjectEuler.Problems._001_100._21_30;

namespace ProjectEuler.Problems._001_100._51_60;

/// <summary>
/// Spiral primes
/// https://projecteuler.net/problem=58
/// Solution: 8581146
/// </summary>
public class Problem058 : IProblem
{
    public Task<string> CalculateAsync(string[] args)
    {
        int count = 1;
        int primesTotal = 0;
        var sequence = Problem028.Sequence().GetEnumerator();
        sequence.MoveNext();
        while (true)
        {
            count += 4;
            for (int i = 0; i < 4; i++)
            {
                sequence.MoveNext();
                var number = sequence.Current;
                if (NumberHelper.IsPrime(number))
                    primesTotal++;
            }
            var ratio = primesTotal / (double)count;
            if (ratio < 0.1)
                break;
        }
        int sideLength = ((count - 1) / 2) + 1;

        return Task.FromResult(sideLength.ToString());
    }
}
