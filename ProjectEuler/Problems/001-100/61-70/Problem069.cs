namespace ProjectEuler.Problems._001_100._61_70;

/// <summary>
/// https://projecteuler.net/problem=69
/// </summary>
public class Problem069 : IProblem
{
    // This dictionary stores result of φ(n) function
    private readonly Dictionary<int, int> phiByN = [];

    public Task<string> CalculateAsync(string[] args)
    {
        var size = 1_000_000; // default
        if (args.Length == 1)
        {
            size = int.Parse(args[0]);
        }

        var result = this.TotientMaximum(size);
        return Task.FromResult(result.ToString());
    }

    private int TotientMaximum(int size)
    {
        this.PopulatePhis(size);

        var (max, nOfMax) = (0d, 0);
        foreach (var (n, phi) in this.phiByN)
        {
            var reverse = n / (double)phi;
            if (reverse > max)
            {
                max = reverse;
                nOfMax = n;
            }
        }

        return nOfMax;
    }

    private void PopulatePhis(int size)
    {
        for (int n = 1; n <= size; n++)
        {
            if (this.phiByN.ContainsKey(n))
            {
                continue;
            }

            // 1 is always relatively prime
            // so start the loop from two
            var phi = 1;
            for (int i = 2; i < n; i++)
            {
                var gcd = NumberHelper.GCD(i, n);
                if (gcd == 1)
                {
                    phi++;
                }

                // If two numbers m and n are relatively prime, then φ(mn) = φ(m)φ(n).
                // n - 1 is always relatively prime to n so calculate
                // φ(n(n-1)) = φ(n)φ(n-1).
                // I've noticed that will always produce the minimum totient (don't know why)
                if (i == n - 1)
                {
                    var key = n * (n - 1);

                    if (key > size)
                    {
                        return;
                    }

                    var value = phi * this.phiByN[n - 1];
                    this.phiByN.Add(key, value);
                }
            }

            this.phiByN.Add(n, phi);
        }
    }
}
