using ProjectEuler.Problems._001_100._91_100;

namespace ProjectEuler.Tests.Problems._001_100._91_100;

public class Problem091Tests : ProblemTestBase
{
    protected override IProblem Problem => new Problem091();

    protected override string Answer => "14234";

    [Fact]
    public async Task Should_SolveExample()
    {
        // Act
        var result = await this.Problem.CalculateAsync(["2"]);

        // Assert
        Assert.Equal("14", result);
    }
}
