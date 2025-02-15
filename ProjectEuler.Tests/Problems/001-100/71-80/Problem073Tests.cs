using ProjectEuler.Problems._001_100._71_80;

namespace ProjectEuler.Tests.Problems._001_100._71_80;

public class Problem073Tests : ProblemTestBase
{
    protected override IProblem Problem => new Problem073();

    protected override string Answer => "7295372";

    [Fact]
    public async Task Should_CalculateExample()
    {
        var result = await this.Problem.CalculateAsync(["8"]);

        Assert.Equal("3", result);
    }
}
