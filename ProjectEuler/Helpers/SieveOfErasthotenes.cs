using System.Collections;
using System.Diagnostics;

namespace ProjectEuler.Helpers;

internal class SieveOfErasthotenes : IPrimes
{
    private const int Offset = 3;

    // true means is composite
    private bool[] sieve;

    public SieveOfErasthotenes(long upperLimit = 1_000_000)
    {
        this.sieve = new bool[ToIndex(upperLimit) + 1];
        var upperSqrtIndex = ToIndex((int)Math.Sqrt(upperLimit));
        for (var i = 0; i <= upperSqrtIndex; i++)
        {
            if (this.sieve[i])
            {
                continue;
            }

            var prime = ToNumber(i);
            var squareIndex = ToIndex(prime * prime);
            for (var j = squareIndex; j < this.sieve.LongLength; j += prime)
            {
                this.sieve[j] = true;
            }
        }
    }

    public IEnumerator<long> GetEnumerator()
    {
        yield return 2;

        long i = 0;
        while (true)
        {
            for (var j = i; j < this.sieve.Length; j++)
            {
                if (!this.sieve[j])
                {
                    yield return ToNumber(j);
                }
            }

            i = this.sieve.LongLength;
            this.Grow(i * 2);
        }
    }

    public bool IsPrime(long n)
    {
        // First check if number is even. All evens but 2 are not primes.
        if (n % 2 == 0)
        {
            return n == 2;
        }

        // Check if an odd number is contained in the sieve
        var index = ToIndex(n);

        if (index > this.sieve.LongLength)
        {
            this.Grow(n);
        }

        return !this.sieve[index];
    }

    IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();

    public IEnumerable<long> GetEnumerated()
    {
        yield return 2;

        for (var i = 0; i < this.sieve.Length; i++)
        {
            if (!this.sieve[i])
            {
                yield return ToNumber(i);
            }
        }
    }

    private static long ToIndex(long number) => (number - Offset) / 2;

    private static long ToNumber(long index) => (2 * index) + Offset;

    private void Grow(long newSize)
    {
        var newSizeInt = (int)newSize;
        Debug.Assert(newSizeInt > this.sieve.LongLength, "New size is smaller than the previous");

        var oldSize = this.sieve.LongLength;
        Array.Resize(ref this.sieve, newSizeInt);

        var lowerLimit = ToNumber(oldSize);
        var upperLimit = ToNumber(newSize);

        var upperSqrtIndex = ToIndex((int)Math.Sqrt(upperLimit));
        for (var i = 0; i <= upperSqrtIndex; i++)
        {
            if (this.sieve[i])
            {
                continue;
            }

            var prime = ToNumber(i);

            // start from the first odd multiple of the prime below the limit
            var start = lowerLimit - (lowerLimit % prime);
            if (start % 2 == 0)
            {
                start += prime;
            }

            for (var j = ToIndex(start); j < this.sieve.LongLength; j += prime)
            {
                this.sieve[j] = true;
            }
        }
    }
}
