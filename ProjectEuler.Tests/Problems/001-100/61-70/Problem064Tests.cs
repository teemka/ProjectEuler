using ProjectEuler.Problems._001_100._61_70;

namespace ProjectEuler.Tests.Problems._001_100._61_70;

public class Problem064Tests : ProblemTestBase
{
    protected override IProblem Problem => new Problem064();

    protected override string Answer => "1322";

    [Theory]
    [InlineData(2, 1, new[] { 2 })]
    [InlineData(3, 1, new[] { 1, 2 })]
    [InlineData(5, 2, new[] { 4 })]
    [InlineData(6, 2, new[] { 2, 4 })]
    [InlineData(7, 2, new[] { 1, 1, 1, 4 })]
    [InlineData(8, 2, new[] { 1, 4 })]
    [InlineData(10, 3, new[] { 6 })]
    [InlineData(11, 3, new[] { 3, 6 })]
    [InlineData(12, 3, new[] { 2, 6 })]
    [InlineData(13, 3, new[] { 1, 1, 1, 1, 6 })]
    [InlineData(23, 4, new[] { 1, 3, 1, 8 })]
    public void Should_ExpandExamples(int power, int expectedFirstInteger, int[] expectedPeriod)
    {
        // Act
        var (firstInteger, period) = Problem064.SquareRootPeriod(power);

        // Assert
        Assert.Equal(expectedFirstInteger, firstInteger);
        Assert.Equal(expectedPeriod, period);
    }
}
