namespace ProjectEuler.Problems._001_100._91_100;

public class Problem095 : IProblem
{
    public Task<string> CalculateAsync(string[] args)
    {
        List<int> longest = [];
        for (var i = 1; i <= 1_000_000; i++)
        {
            if (FindLoop(i, out var chain))
            {
                if (chain.Count > longest.Count)
                {
                    longest = chain;
                }
            }
        }

        return Task.FromResult(longest.Min().ToString());
    }

    private static bool FindLoop(int number, out List<int> chain)
    {
        chain = [];
        var x = number;
        while (true)
        {
            if (chain.Contains(x))
            {
                var start = chain.IndexOf(x);
                chain = chain[start..];
                return true; // Loop found
            }

            chain.Add(x);

            var sum = x.ProperDivisors().Sum();
            if (sum == x)
            {
                return false; // Perfect number, no loop
            }

            x = sum;

            if (x > 1_000_000)
            {
                return false; // No loop found, number is too large
            }

            if (x == 1)
            {
                return false;
            }
        }
    }
}
