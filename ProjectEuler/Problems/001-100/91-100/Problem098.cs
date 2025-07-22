using System.Buffers;

namespace ProjectEuler.Problems._001_100._91_100;

/// <summary>
/// https://projecteuler.net/problem=98
/// </summary>
public sealed class Problem098 : IProblem
{
    private static readonly int[] Digits = [.. Enumerable.Range(0, 10)];

    public async Task<string> CalculateAsync(string[] args)
    {
        var text = await File.ReadAllTextAsync("Problems/001-100/91-100/0098_words.txt");
        var words = text.Split(",").Select(x => x.Trim('"')).ToList();

        var anagramGroups = words
            .GroupBy(x => string.Concat(x.Order()))
            .Where(x => x.Count() > 1)
            .ToDictionary(x => x.Key, x => x.ToList());

        var pairs = anagramGroups
            .Select(x => x.Value.GetCombinations(2))
            .SelectMany(x => x)
            .Select(x => (x[0], x[1]))
            .ToList();

        var max = 0;
        foreach (var pair in pairs)
        {
            var letters = pair.Item1.ToHashSet();
            var n = letters.Count;

            foreach (var combination in Digits.GetCombinations(n).SelectMany(x => x.GetPermutations()))
            {
                // TODO: Optimize the hot path
                var assignment = combination
                    .Zip(letters)
                    .ToDictionary(x => x.Second, x => x.First);

                var isNumber1Square = IsSquare(pair.Item1, assignment, out var number1);
                if (!isNumber1Square)
                {
                    continue;
                }

                var isNumber2Square = IsSquare(pair.Item2, assignment, out var number2);
                if (!isNumber2Square)
                {
                    continue;
                }

                max = Math.Max(max, Math.Max(number1, number2));
            }
        }

        return max.ToString();
    }

    private static bool IsSquare(string word, Dictionary<char, int> assignment, out int number)
    {
        var array = ArrayPool<int>.Shared.Rent(assignment.Count);
        for (var i = 0; i < assignment.Count; i++)
        {
            array[i] = assignment[word[i]];
        }

        if (array[0] == 0)
        {
            number = 0;
            return false;
        }

        number = array.ToNumberFromDigits(0, assignment.Count);
        ArrayPool<int>.Shared.Return(array);
        var sqrt = Math.Sqrt(number);
        return double.IsInteger(sqrt);
    }
}
