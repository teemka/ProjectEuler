using ProjectEuler.Extensions;
using ProjectEuler.Problems._001_100._91_100;

namespace ProjectEuler.Tests.Problems._001_100._91_100;

using static Problem093;

public class Problem093Tests : ProblemTestBase
{
    protected override IProblem Problem => new Problem093();

    protected override string Answer => "1258";

    [Fact]
    public void Should_SolveExample()
    {
        // Act
        var result = CalculateConsecutivePositiveIntegers([1, 2, 3, 4]);

        // Assert
        Assert.Equal(28, result);
    }

    public static TheoryData<string, string, string, string> ExpressionTestData => new()
    {
        { "4132", "*+/", "213", "((4*(1+3))/2)" },
        { "4312", "*+/", "321", "(4*(3+(1/2)))" },
        { "4231", "*+-", "213", "((4*(2+3))-1)" },
        { "3421", "**+", "231", "((3*4)*(2+1))" },
    };

    [Theory]
    [MemberData(nameof(ExpressionTestData))]
    public void Should_SolveExample_Expression(string numbers, string operations, string order, string expected)
    {
        // Arrange
        var numbers1 = numbers.Select(x => x.ToInt()).ToList();
        var operations1 = operations.Select(x => ArithmeticOperation.Parse(x.ToString())).ToList();
        var order1 = order.Select(x => x.ToInt()).ToList();

        // Act
        var result = GetExpression(numbers1, operations1, order1);

        // Assert
        Assert.Equal(expected, result.ToString());
    }
}
