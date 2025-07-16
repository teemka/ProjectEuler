namespace ProjectEuler.Tests.Problems._001_100._91_100;

/// <summary>
/// https://projecteuler.net/problem=93
/// </summary>
public class Problem093 : IProblem
{
    public Task<string> CalculateAsync(string[] args)
    {
        IList<int> resultDigits = [];
        var max = 0;
        // (10 4) = 210
        foreach (var digits in Enumerable.Range(1, 9).ToArray().GetCombinations(4))
        {
            var count = GetResults(digits);

            if (count > max)
            {
                resultDigits = digits;
                max = count;
            }
        }

        // Tried
        // 1256
        // 2348
        // 2389
        return Task.FromResult(string.Join("", resultDigits));
    }

    private static readonly Operation[] Operations =
    [
        Addition,
        Subtraction,
        Multiplication,
        Division,
    ];

    private static readonly int[] Order = [1, 2, 3];

    public static int GetResults(IList<int> digits)
    {
        var results = new Dictionary<int, List<Expression>>();
        // 4! = 24
        foreach (var digitPermutation in digits.GetPermutations())
        {
            // ((4 3)) = 20
            foreach (var operationCombination in Operations.GetCombinationsWithRepetitions(3))
            {
                // 3! = 6
                foreach (var operationPermutation in operationCombination.GetPermutations())
                {
                    // 3! = 6
                    foreach (var orderPerm in Order.GetPermutations())
                    {
                        var finalExpression = GetExpression(digitPermutation, operationPermutation, orderPerm);
                        var result = finalExpression.Value;
                        if (result > 0 && double.IsInteger(result))
                        {
                            if (!results.TryGetValue((int)result, out var list))
                            {
                                list = [];
                                results.Add((int)result, list);
                            }

                            list.Add(finalExpression);
                        }
                    }
                }
            }
        }

        foreach (var kvp in results)
        {
            results[kvp.Key] = [.. kvp.Value.DistinctBy(x => x.ToString())];
        }

        var orderedResults = results.OrderBy(x => x.Key).ToArray();
        var count = orderedResults.Zip(orderedResults.Skip(1)).TakeWhile(x => x.First.Key == x.Second.Key - 1).Count() + 1;
        return count;
    }

    public static Expression GetExpression(
        IList<int> digitPermutation,
        IList<Operation> operationPermutation,
        IList<int> orderPerm)
    {
        var opCp = operationPermutation.ToList();
        var orderCp = orderPerm.ToList();
        var expression = digitPermutation.Select(x => new Literal(x)).Cast<Expression>().ToList();
        for (var i = 1; i < 4; i++)
        {
            var index = orderCp.IndexOf(i);

            var e = new BinaryExpression(expression[index], expression[index + 1], opCp[index]);
            expression[index] = e;
            expression.RemoveAt(index + 1);
            opCp.RemoveAt(index);
            orderCp.RemoveAt(index);
        }

        var finalExpression = expression[0];
        return finalExpression;
    }

    public delegate double Operation(double left, double right);

    public static double Addition(double a, double b) => a + b;
    public static double Subtraction(double a, double b) => a - b;
    public static double Multiplication(double a, double b) => a * b;
    public static double Division(double a, double b) => a / b;

    private static string ToStringOp(Operation operation)
    {
        if (operation == Addition)
        {
            return "+";
        }

        if (operation == Subtraction)
        {
            return "-";
        }

        if (operation == Multiplication)
        {
            return "*";
        }

        if (operation == Division)
        {
            return "/";
        }

        return "";
    }

    public abstract class Expression
    {
        public abstract double Value { get; }
    }

    public class BinaryExpression(Expression left, Expression right, Operation operation) : Expression
    {
        public override double Value => this.Operation(this.Left.Value, this.Right.Value);
        public Expression Left { get; } = left;
        public Expression Right { get; } = right;
        public Operation Operation { get; } = operation;

        public override string ToString() => $"({this.Left}{ToStringOp(this.Operation)}{this.Right})";
    }

    public class Literal(double value) : Expression
    {
        public override double Value { get; } = value;

        public override string ToString() => this.Value.ToString();
    }
}
