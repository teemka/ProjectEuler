using ProjectEuler.Problems._001_100._71_80;

namespace ProjectEuler.Tests.Problems._001_100._71_80;

public class Problem074Tests : ProblemTestBase
{
    protected override IProblem Problem => new Problem074();

    protected override string Answer => "402";

    [Theory]
    [InlineData(69, 5)]
    [InlineData(78, 4)]
    [InlineData(540, 2)]
    public void Should_CalculateExampleLength(int input, int expected)
    {
        // Act
        var result = new Problem074().ChainLength(input);

        // Assert
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(0, 1)]
    [InlineData(145, 145)]
    [InlineData(169, 363601)]
    [InlineData(363601, 1454)]
    [InlineData(1454, 169)]
    public void Should_CalculateDigitFactorial(int input, int expected)
    {
        var result = Problem074.DigitFactorial(input);

        Assert.Equal(expected, result);
    }
}
