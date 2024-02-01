namespace ProjectEuler.Problems._701_800._701_710;

public class Problem709 : IProblem
{
    private static readonly Dictionary<int, long> Posibilities = new()
    {
        { 0, 0 },
        { 1, 0 },
        { 2, 2 },
    };

    public Task<string> CalculateAsync(string[] args)
    {
        throw new NotImplementedException();

        var limit = int.Parse(args[0]);
        var posibilites = CalculatePosibilities(limit);
        return Task.FromResult(posibilites.ToString());
    }

    private static long CalculatePosibilities(int n)
    {
        if (Posibilities.ContainsKey(n))
        {
            return Posibilities[n];
        }

        long sum = 0;
        var div = n / 2;

        for (int i = 0; i < div; i++)
        {
            var k = (i + 1) * 2;

            sum += NumberHelper.BinomialCoefficient(n - 1, k);
        }

        sum++;

        Posibilities[n] = sum;

        return sum;
    }
}
