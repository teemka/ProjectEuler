namespace ProjectEuler.Problems._001_100._71_80;

/// <summary>
/// Counting Fractions in a Range
/// https://projecteuler.net/problem=73
/// </summary>
internal class Problem073 : IProblem
{
    public Task<string> CalculateAsync(string[] args)
    {
        if (!int.TryParse(args.FirstOrDefault(), out var size))
        {
            size = 12_000;
        }

        var count = 0;

        // Use Farey Sequence
        for (var denominator = 3; denominator <= size; denominator++)
        {
            for (var numerator = (denominator / 3) + 1; numerator <= denominator / 2; numerator++)
            {
                if (NumberHelper.GCD(numerator, denominator) == 1)
                {
                    count++;
                }
            }
        }

        return Task.FromResult(count.ToString());
    }
}
