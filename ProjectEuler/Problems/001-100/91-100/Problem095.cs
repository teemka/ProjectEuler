namespace ProjectEuler.Problems._001_100._91_100;

public class Problem095 : IProblem
{
    public Task<string> CalculateAsync(string[] args)
    {
        List<int> longest = [];
        for (var i = 1; i <= 20_000; i++) // limit from heuristic
        {
            if (!FindLoop(i, out var loop))
            {
                continue;
            }

            if (loop.Count <= longest.Count)
            {
                continue;
            }

            longest = loop;
        }

        return Task.FromResult(longest.Min().ToString());
    }

    private static bool FindLoop(int number, out List<int> loop)
    {
        loop = [];
        var x = number;
        while (true)
        {
            var index = loop.IndexOf(x);
            if (index > 0)
            {
                loop = loop[index..];
                return true; // Loop found
            }

            loop.Add(x);

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
