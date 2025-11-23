using ProjectEuler.Problems._001_100._51_60;

namespace ProjectEuler.Tests.Problems._001_100._51_60;

[InheritsTests]
public class Problem060Tests : ProblemTestBase
{
    protected override IProblem Problem => new Problem060();

    protected override string Answer => "26033";

    [Test]
    public async Task Should_SolveExample()
    {
        // Arrange
        var args = new[] { "4" };

        // Act
        var result = await this.Problem.CalculateAsync(args);

        // Assert
        await Assert.That(result).IsEqualTo("792");
    }
}
