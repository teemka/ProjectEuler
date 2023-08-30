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
        this.Populate(upperLimit);
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
                    var prime = ToNumber(j);
                    yield return prime;
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

    private static long ToIndex(long number) => (number - Offset) / 2;

    private static long ToNumber(long index) => (2 * index) + Offset;

    private void Grow(long newSize)
    {
        Debug.Assert(newSize > this.sieve.LongLength, "New size is smaller than the previous");

        Array.Resize(ref this.sieve, (int)newSize);

        var upperLimit = ToNumber(newSize);
        this.Populate(upperLimit);
    }

    private void Populate(long upperLimit)
    {
        var upperSqrtIndex = ToIndex((int)Math.Sqrt(upperLimit));
        for (var i = 0; i <= upperSqrtIndex; i++)
        {
            // If this bit has already been turned off, then its associated number is composite.
            if (this.sieve[i])
            {
                continue;
            }

            var number = ToNumber(i);

            // Any multiples of number are composite and their respective bits should be turned off.
            for (var j = ToIndex(number * number); j > i && j < this.sieve.LongLength; j += number)
            {
                this.sieve[j] = true;
            }
        }
    }
}
