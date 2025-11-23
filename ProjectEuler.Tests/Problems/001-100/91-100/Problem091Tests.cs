using ProjectEuler.Problems._001_100._91_100;

namespace ProjectEuler.Tests.Problems._001_100._91_100;

[InheritsTests]
public class Problem091Tests : ProblemTestBase
{
    protected override IProblem Problem => new Problem091();

    protected override string Answer => "14234";

    [Test]
    public async Task Should_SolveExample()
    {
        // Act
        var result = await this.Problem.CalculateAsync(["2"]);

        // Assert
        await Assert.That(result).IsEqualTo("14");
    }
}
