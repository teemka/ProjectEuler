using System.Collections;

namespace ProjectEuler.Problems._101_200._181_190;

/// <summary>
/// https://projecteuler.net/problem=186
/// Answer: 2325629
/// </summary>
public class Problem186 : IProblem
{
    private const int PMNumber = 524287;
    private const int NetworkSize = 1_000_000;

    private readonly LaggedFibonacciGenerator lfg = new();
    private readonly DisjointSet<int> network = [];

    public Problem186()
    {
        foreach (var number in Enumerable.Range(0, NetworkSize))
        {
            this.network.Add(number);
        }
    }

    public Task<string> CalculateAsync(string[] args)
    {
        var count = 0;
        do
        {
            var caller = this.lfg.Next();
            var called = this.lfg.Next();

            if (caller == called)
            {
                // misdiall - skip
                continue;
            }

            count++;
            this.network.Union(caller, called);
        }
        while (this.network.GetSize(PMNumber) / (double)NetworkSize < 0.99);

        return Task.FromResult(count.ToString());
    }

    public class LaggedFibonacciGenerator : IEnumerable<int>
    {
        private readonly int[] prev = new int[55];
        private int k = 0;

        public int Next()
        {
            this.k++;
            if (this.k <= 55)
            {
                var value = (100003 - (200003 * this.k) + (300007 * (long)Math.Pow(this.k, 3))) % 1000000;

                this.prev[Index(this.k)] = (int)value;
            }
            else
            {
                this.prev[Index(this.k)] = (this.prev[Index(this.k - 24)] + this.prev[Index(this.k - 55)]) % 1000000;
            }

            return this.prev[Index(this.k)];
        }

        public IEnumerator<int> GetEnumerator()
        {
            while (true)
            {
                yield return this.Next();
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();

        private static int Index(int k) => (k - 1) % 55;
    }
}
