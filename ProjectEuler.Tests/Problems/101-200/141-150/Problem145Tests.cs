using ProjectEuler.Problems._101_200._141_150;

namespace ProjectEuler.Tests.Problems._101_200._141_150;

public class Problem145Tests : ProblemTestBase
{
    public override IProblem Problem => new Problem145();

    public override string Answer => "608720";

    [Fact]
    public async void Should_CalculateExample()
    {
        var problem = new Problem145();

        var result = await problem.CalculateAsync(["1000"]);

        Assert.Equal("120", result);
    }
}
