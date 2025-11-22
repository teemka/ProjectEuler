using ProjectEuler.Problems._001_100._61_70;

namespace ProjectEuler.Tests.Problems._001_100._61_70;

[InheritsTests]
public class Problem069Tests : ProblemTestBase
{
    protected override IProblem Problem => new Problem069();

    protected override string Answer => "510510";

    [Test]
    public async Task Should_SolveExample()
    {
        // Arrange
        var args = new[] { "10" };

        // Act
        var result = await this.Problem.CalculateAsync(args);

        // Assert
        await Assert.That(result).IsEqualTo("6");
    }
}
