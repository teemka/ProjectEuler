using ProjectEuler.Problems._001_100._31_40;

namespace ProjectEuler.Tests.Problems._001_100._31_40;

public class Problem038Tests : ProblemTestBase
{
    protected override IProblem Problem => new Problem038();

    protected override string Answer => "932718654";

    [Theory]
    [InlineData(1, 2, 12)]
    [InlineData(123, 3, 123246369)]
    [InlineData(1, 9, 123456789)]
    [InlineData(192, 3, 192384576)]
    [InlineData(9, 5, 918273645)]
    public void Should_SolveExample(int number, int n, long expected)
    {
        // Arrange

        // Act
        var result = new Problem038().CreateMultiple(number, n);

        // Assert
        Assert.Equal(expected, result);
    }
}
