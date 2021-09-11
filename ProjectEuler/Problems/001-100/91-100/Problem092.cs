namespace ProjectEuler.Problems._001_100._91_100;

/// <summary>
/// https://projecteuler.net/problem=92
/// </summary>
public class Problem092 : IProblem
{
    public Task<string> CalculateAsync(string[] args)
    {
        var count = 0;
        for (var i = 1; i < 10_000_000; i++)
        {
            var number = i;
            while (true)
            {
                var next = 0;
                while (number != 0)
                {
                    number = Math.DivRem(number, 10, out var digit);
                    next += digit * digit;
                }
                number = next;

                if (number == 1)
                {
                    break;
                }
                else if (number == 89)
                {
                    count++;
                    break;
                }
            }
        }

        return Task.FromResult(count.ToString());
    }
}
