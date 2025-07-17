using System.Globalization;

namespace ProjectEuler.Problems._001_100._91_100;

/// <summary>
/// https://projecteuler.net/problem=93
/// </summary>
public class Problem093 : IProblem
{
    private static readonly ArithmeticOperation[] Operations =
    [
        new Addition(),
        new Subtraction(),
        new Multiplication(),
        new Division(),
    ];

    private static readonly ArithmeticOperation[][] OperationCombinationsPermutations = Operations
        .GetCombinationsWithRepetitions(3)
        .SelectMany(x => x.GetPermutations())
        .Select(x => x.ToArray())
        .DistinctBy(x => string.Concat([.. x]))
        .ToArray();

    private static readonly int[] Orders = [1, 2, 3];

    private static readonly int[][] OrderPermutations = Orders
        .GetPermutations()
        .Select(x => x.ToArray())
        .ToArray();

    public Task<string> CalculateAsync(string[] args)
    {
        IList<int> resultDigits = [];
        var max = 0;
        // (9 4) = 126
        foreach (var digits in Enumerable.Range(1, 9).ToArray().GetCombinations(4))
        {
            var count = CalculateConsecutivePositiveIntegers(digits);

            if (count > max)
            {
                resultDigits = digits;
                max = count;
            }
        }

        return Task.FromResult(string.Concat(resultDigits));
    }

    public static int CalculateConsecutivePositiveIntegers(IList<int> digitsCombination)
    {
        var results = new HashSet<int>();
        // 4! = 24
        foreach (var digits in digitsCombination.GetPermutations())
        {
            // 4^3 = 64
            foreach (var operations in OperationCombinationsPermutations)
            {
                // 3! = 6
                foreach (var order in OrderPermutations)
                {
                    var expression = GetExpression(digits, operations, order);
                    var result = expression.Value;

                    if (double.IsPositive(result) && double.IsInteger(result))
                    {
                        results.Add((int)result);
                    }
                }
            }
        }

        var ordered = results.Order().ToArray();

        return ordered
            .Zip(ordered.Skip(1))
            .TakeWhile(x => x.First == x.Second - 1)
            .Count();
    }

    public static Expression GetExpression(
        IList<int> digits,
        IList<ArithmeticOperation> operations,
        IList<int> order)
    {
        var opCp = operations.ToList();
        var orderCp = order.ToList();
        var expression = digits.Select(x => new Literal(x)).Cast<Expression>().ToList();
        for (var i = 1; i < 4; i++)
        {
            var index = orderCp.IndexOf(i);

            var e = new BinaryExpression(expression[index], expression[index + 1], opCp[index]);
            expression[index] = e;
            expression.RemoveAt(index + 1);
            opCp.RemoveAt(index);
            orderCp.RemoveAt(index);
        }

        return expression[0];
    }

    public abstract class ArithmeticOperation
    {
        public abstract double Operation(double a, double b);

        public static ArithmeticOperation Parse(string value) => value switch
        {
            "+" => new Addition(),
            "-" => new Subtraction(),
            "*" => new Multiplication(),
            "/" => new Division(),
            _ => throw new NotImplementedException(),
        };
    }

    private sealed class Addition : ArithmeticOperation
    {
        public override double Operation(double a, double b) => a + b;

        public override string ToString() => "+";
    }

    private sealed class Subtraction : ArithmeticOperation
    {
        public override double Operation(double a, double b) => a - b;

        public override string ToString() => "-";
    }

    private sealed class Multiplication : ArithmeticOperation
    {
        public override double Operation(double a, double b) => a * b;

        public override string ToString() => "*";
    }

    private sealed class Division : ArithmeticOperation
    {
        public override double Operation(double a, double b) => a / b;

        public override string ToString() => "/";
    }

    public abstract class Expression
    {
        public abstract double Value { get; }
    }

    private class BinaryExpression(Expression left, Expression right, ArithmeticOperation operation) : Expression
    {
        public override double Value => operation.Operation(left.Value, right.Value);

        public override string ToString() => $"({left}{operation}{right})";
    }

    private class Literal(double value) : Expression
    {
        public override double Value { get; } = value;

        public override string ToString() => this.Value.ToString(CultureInfo.InvariantCulture);
    }
}
