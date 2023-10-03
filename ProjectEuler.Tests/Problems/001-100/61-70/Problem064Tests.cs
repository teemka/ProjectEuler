using ProjectEuler.Problems._001_100._51_60;
using ProjectEuler.Problems._001_100._61_70;

namespace ProjectEuler.Tests.Problems._001_100._61_70;

public class Problem064Tests : ProblemTestBase
{
    public override IProblem Problem => new Problem064();

    public override string Answer => "1322";

    [Theory]
    [InlineData(2, new[] { 1, 2 })]
    [InlineData(3, new[] { 1, 1, 2 })]
    [InlineData(5, new[] { 2, 4 })]
    [InlineData(6, new[] { 2, 2, 4 })]
    [InlineData(7, new[] { 2, 1, 1, 1, 4 })]
    [InlineData(8, new[] { 2, 1, 4 })]
    [InlineData(10, new[] { 3, 6 })]
    [InlineData(11, new[] { 3, 3, 6 })]
    [InlineData(12, new[] { 3, 2, 6 })]
    [InlineData(13, new[] { 3, 1, 1, 1, 1, 6 })]
    [InlineData(23, new[] { 4, 1, 3, 1, 8 })]
    public void Should_ExpandExamples(int power, int[] expected)
    {
        // Act
        var sequence = Problem064.SquareRootPeriod(power);

        // Assert
        sequence.Should().BeEquivalentTo(expected);
    }
}
