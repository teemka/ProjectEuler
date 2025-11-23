namespace ProjectEuler.Problems._001_100._31_40;

/// <summary>
/// https://projecteuler.net/problem=40
/// </summary>
public class Problem040 : IProblem
{
    public Task<string> CalculateAsync(string[] args)
    {
        var number = string.Concat(Enumerable.Range(1, 1000000));

        IEnumerable<int> Extract()
        {
            var index = 1;
            for (var i = 0; i < 7; i++)
            {
                yield return number[index - 1].ToInt();
                index *= 10;
            }
        }

        var arr = Extract().ToArray();

        var result = arr.Aggregate((x, y) => x * y);

        return Task.FromResult(result.ToString());
    }
}
