using System.Collections;
using System.Diagnostics;

namespace ProjectEuler.Helpers;

internal class SieveOfErasthotenes : IPrimes
{
    private const int Offset = 3;

    // true means is composite
    private bool[] sieve;

    public SieveOfErasthotenes(int upperLimit = 1_000_000)
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
            for (var j = squareIndex; j < this.sieve.Length; j += prime)
            {
                this.sieve[j] = true;
            }
        }
    }

    public IEnumerator<int> GetEnumerator()
    {
        yield return 2;

        var i = 0;
        while (true)
        {
            for (var j = i; j < this.sieve.Length; j++)
            {
                if (!this.sieve[j])
                {
                    yield return ToNumber(j);
                }
            }

            i = this.sieve.Length;
            this.Grow(i * 2);
        }
    }

    // Prevent easy mistake of calling Linq's Contains
    public bool Contains(int n) => this.IsPrime(n);

    public bool IsPrime(int n)
    {
        // First check if number is even. All evens but 2 are not primes.
        if (int.IsEvenInteger(n))
        {
            return n == 2;
        }

        if (n <= 1)
        {
            return false;
        }

        // Check if an odd number is contained in the sieve
        var index = ToIndex(n);

        if (index >= this.sieve.Length)
        {
            var newSize = Math.Max(index + 1, this.sieve.Length * 2);
            this.Grow(newSize);
        }

        return !this.sieve[index];
    }

    IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();

    public IEnumerable<int> GetEnumerated()
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

    private static int ToIndex(int number) => (number - Offset) / 2;

    private static int ToNumber(int index) => (2 * index) + Offset;

    private void Grow(int newSize)
    {
        Debug.Assert(newSize > this.sieve.Length, "New size is smaller than the previous");
        Debug.Assert(newSize > 0, "New size probably overflowed");

        var oldSize = this.sieve.Length;
        Array.Resize(ref this.sieve, newSize);

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

            for (var j = ToIndex(start); j < this.sieve.Length; j += prime)
            {
                this.sieve[j] = true;
            }
        }
    }
}
