namespace ProjectEuler.Problems._001_100._21_30;

/// <summary>
/// https://projecteuler.net/problem=27
/// </summary>
public class Problem027 : IProblem
{
    public Task<string> CalculateAsync(string[] args)
    {
        var aCandidates = Enumerable.Range(-999, 1999);
        var bCandidates = Enumerable.Range(-1000, 2001);

        var result = aCandidates.CartesianProduct(bCandidates)
            .Select(x => (x.a, x.b, max: MaximumNumberOfPrimes(x.a, x.b)))
            .OrderByDescending(x => x.max)
            .ToList();

        var max = result.First();
        return Task.FromResult((max.a * max.b).ToString());
    }

    static int MaximumNumberOfPrimes(long a, long b)
    {
        long Equation(long n) => (n * n) + (a * n) + b;
        int i = 0;
        while (Equation(i).IsPrime())
            i++;
        return i;
    }
}
