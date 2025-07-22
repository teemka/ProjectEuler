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
    public void Should_SolveExample_Expression(string numbersS, string operationsS, string orderS, string expected)
    {
        // Arrange
        var numbers = numbersS.Select(x => x.ToInt()).ToList();
        var operations = operationsS.Select(x => ArithmeticOperation.Parse(x.ToString())).ToList();
        var order = orderS.Select(x => x.ToInt()).ToList();

        // Act
        var result = GetExpression(numbers, operations, order);

        // Assert
        Assert.Equal(expected, result.ToString());
    }
}
