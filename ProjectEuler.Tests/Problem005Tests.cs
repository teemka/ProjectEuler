using ProjectEuler.Problems._001_100._1_10;

namespace ProjectEuler.Tests;

public class Problem005Tests : ProblemTestBase
{
    public override IProblem Problem => new Problem005();

    public override string Answer => "232792560";

    [Theory]
    [InlineData(2520, 10)]
    [InlineData(232792560, 20)]
    public void Should_BeEvenlyDivisible(int number, int divisorsCount)
    {
        // Arrange
        var divisors = Enumerable.Range(1, divisorsCount).ToArray();

        // Act
        var result = Problem005.IsEvenlyDivisible(number, divisors);

        // Assert
        result.Should().BeTrue();
    }
}
