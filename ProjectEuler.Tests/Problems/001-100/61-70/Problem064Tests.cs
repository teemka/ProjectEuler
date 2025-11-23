using ProjectEuler.Problems._001_100._61_70;

namespace ProjectEuler.Tests.Problems._001_100._61_70;

[InheritsTests]
public class Problem064Tests : ProblemTestBase
{
    protected override IProblem Problem => new Problem064();

    protected override string Answer => "1322";

    [Test]
    [Arguments(2, 1, new[] { 2 })]
    [Arguments(3, 1, new[] { 1, 2 })]
    [Arguments(5, 2, new[] { 4 })]
    [Arguments(6, 2, new[] { 2, 4 })]
    [Arguments(7, 2, new[] { 1, 1, 1, 4 })]
    [Arguments(8, 2, new[] { 1, 4 })]
    [Arguments(10, 3, new[] { 6 })]
    [Arguments(11, 3, new[] { 3, 6 })]
    [Arguments(12, 3, new[] { 2, 6 })]
    [Arguments(13, 3, new[] { 1, 1, 1, 1, 6 })]
    [Arguments(23, 4, new[] { 1, 3, 1, 8 })]
    public async Task Should_ExpandExamples(int power, int expectedFirstInteger, int[] expectedPeriod)
    {
        // Act
        var (firstInteger, period) = Problem064.SquareRootPeriod(power);

        // Assert
        await Assert.That(firstInteger).IsEqualTo(expectedFirstInteger);
        await Assert.That(period).IsEquivalentTo(expectedPeriod);
    }
}
