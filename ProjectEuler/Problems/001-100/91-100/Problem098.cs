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

        var letterAssignment = StringHelper.AlphabetUppercase.ToDictionary(x => x, _ => 0);
        var max = 0;
        foreach (var pair in pairs)
        {
            var letters = pair.Item1.Distinct().ToList();
            var n = letters.Count;

            foreach (var combination in Digits.GetCombinations(n).SelectMany(x => x.GetPermutations()))
            {
                for (var i = 0; i < n; i++)
                {
                    var letter = letters[i];
                    var digit = combination[i];
                    letterAssignment[letter] = digit;
                }

                var isNumber1Square = this.IsSquare(pair.Item1, n, letterAssignment, out var number1);
                if (!isNumber1Square)
                {
                    continue;
                }

                var isNumber2Square = this.IsSquare(pair.Item2, n, letterAssignment, out var number2);
                if (!isNumber2Square)
                {
                    continue;
                }

                max = Math.Max(max, Math.Max(number1, number2));
            }
        }

        return max.ToString();
    }

    private readonly int[] digitsArray = new int[9]; // longest word is 9 letters
    private bool IsSquare(string word, int n, Dictionary<char, int> assignment, out int number)
    {
        for (var i = 0; i < n; i++)
        {
            this.digitsArray[i] = assignment[word[i]];
        }

        if (this.digitsArray[0] == 0)
        {
            number = 0; // leading zeroes are not permitted
            return false;
        }

        number = this.digitsArray.ToNumberFromDigits(0, n);
        var sqrt = Math.Sqrt(number);
        return double.IsInteger(sqrt);
    }
}
