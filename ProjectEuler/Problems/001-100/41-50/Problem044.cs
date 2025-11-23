namespace ProjectEuler.Problems._001_100._41_50;

/// <summary>
/// https://projecteuler.net/problem=44
/// Answer: 5482660
/// </summary>
public class Problem044 : IProblem
{
    public Task<string> CalculateAsync(string[] args)
    {
        var result = Calculate();
        return Task.FromResult(result.ToString());
    }

    private static long Calculate()
    {
        var pentagonalNumbers = Sequences.PentagonalNumbers();
        var discovered = new HashSet<long>();

        foreach (var p in pentagonalNumbers)
        {
            foreach (var pk in discovered)
            {
                var pj = p - pk;
                if (!discovered.Contains(pj))
                {
                    continue;
                }

                var d = pk - pj;
                if (discovered.Contains(d))
                {
                    return d;
                }
            }

            discovered.Add(p);
        }

        return 0;
    }
}
