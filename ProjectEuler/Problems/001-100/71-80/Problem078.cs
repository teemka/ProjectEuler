using Microsoft.Extensions.Logging;
using System.Collections.Concurrent;

namespace ProjectEuler.Problems._001_100._71_80;

public class Problem078(ILogger<Problem078> logger) : IProblem
{
    private readonly Lock @lock = new();
    private readonly ConcurrentDictionary<int, int> summations = [];

    public Task<string> CalculateAsync(string[] args)
    {
        if (File.Exists("memoization.txt"))
        {
            var lines = File.ReadAllLines("memoization.txt");
            foreach (var line in lines)
            {
                var split = line.Split(':');
                var n = int.Parse(split[0]);
                var p = int.Parse(split[1]);
                this.summations.TryAdd(n, p);
            }

            File.WriteAllLines("memoization.txt", this.summations.OrderBy(x => x.Key).Select(x => x.Key + ":" + x.Value));
        }

        using var sw = File.AppendText("memoization.txt");

        const int range = 30_000;
        const int million = 1_000_000;
        var output = 0;
        var arr = Enumerable.Range(1, range).ToList();

        Parallel.For(2, range, (n, state) =>
        {
            if (this.summations.TryGetValue(n, out var p))
            {
                if (p % million == 0)
                {
                    output = n;
                    state.Break();
                }
                return;
            }

            logger.LogInformation("N: {N}", n);

            var table = new int[n + 1];
            table[0] = 1;
            for (var i = 0; i < n - 1; i++)
            {
                for (var j = arr[i]; j <= n; j++)
                {
                    checked
                    {
                        var a = arr[i];
                        var b = j - a;
                        var c = table[b] % million;
                        table[j] %= million;
                        table[j] += c;
                    }
                }
            }

            p = table[n] + 1;
            lock (@lock)
            {
                sw.WriteLine($"{n}:{p}");
                sw.Flush();
            }
            this.summations.TryAdd(n, p);

            if (p % million == 0)
            {
                output = n;
                state.Break();
            }
        });

        return Task.FromResult(output.ToString());
    }
}
