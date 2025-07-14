using ProjectEuler.Extensions;

namespace ProjectEuler.Tests.Problems._001_100._91_100;

/// <summary>
/// https://projecteuler.net/problem=93
/// </summary>
public class Problem093 : IProblem
{
    private delegate double Operation(double a, double b);

    public Task<string> CalculateAsync(string[] args)
    {
        // There should be 864 combinations
        static double Addition(double a, double b) => a + b;
        static double Subtraction(double a, double b) => a - b;
        static double Multiplication(double a, double b) => a * b;
        static double Division(double a, double b) => a / b;
        var operations = new Operation[]
        {
            Addition,
            Subtraction,
            Multiplication,
            Division,
        };

        var order = new[] { 1, 2, 3 };

        IList<int> resultDigits = [];
        var max = 0;
        foreach (var digits in Enumerable.Range(1, 9).ToArray().GetCombinations(4))
        {
            var results = new HashSet<int>();
            foreach (var digitPermutation in digits.GetPermutations())
            {
                foreach (var operationCombination in operations.GetCombinationsWithRepetitions(3))
                {
                    foreach (var orderPerm in order.GetPermutations())
                    {
                        var orderedOperations = operationCombination
                            .Zip(orderPerm)
                            .OrderBy(x => x.Second)
                            .Select(x => x.First)
                            .ToList();

                        var result = (double)digitPermutation[0];
                        for (var i = 0; i < 3; i++)
                        {
                            result = orderedOperations[i].Invoke(result, digitPermutation[i + 1]);
                        }

                        result = double.Round(result,1);
                        if (result > 0 && double.IsInteger(result))
                        {
                            results.Add((int)result);
                        }
                    }
                }
            }

            var orderedResults = results.Order().ToArray();
            var count = orderedResults.Zip(orderedResults.Skip(1)).TakeWhile(x => x.First == x.Second - 1).Count() +1;
            if (count > max)
            {
                resultDigits = digits;
                max = count;
            }
        }

        return Task.FromResult(string.Join("", resultDigits));
    }
}
