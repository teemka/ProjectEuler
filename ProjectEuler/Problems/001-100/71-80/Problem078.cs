namespace ProjectEuler.Problems._001_100._71_80;

public class Problem078 : IProblem
{
    public Task<string> CalculateAsync(string[] args)
    {
        // TODO: this method must be memoized and possibly remade to use BigInteger
        static long p(int n) => NumberHelper.AllPossibleSummationsOf(n) + 1;

        int n = 1;
        int million = 1_000_000;
        while (p(n) % million != 0)
            n++;

        return Task.FromResult(n.ToString());
    }
}
