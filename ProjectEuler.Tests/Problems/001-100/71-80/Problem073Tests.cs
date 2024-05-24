using ProjectEuler.Problems._001_100._71_80;

namespace ProjectEuler.Tests.Problems._001_100._71_80;

public class Problem073Tests : ProblemTestBase
{
    public override IProblem Problem => new Problem073();

    public override string Answer => "7295372";

    [Fact]
    public async Task Should_CalculateExample()
    {
        var result = await this.Problem.CalculateAsync(["8"]);

        result.Should().Be("3");
    }
}
