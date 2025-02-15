using ProjectEuler.Problems._101_200._101_110;

namespace ProjectEuler.Tests.Problems._101_200._101_110;

public class Problem107Tests : ProblemTestBase
{
    protected override IProblem Problem => new Problem107();

    protected override string Answer => "259679";

    [Fact]
    public async Task Should_SolveExample()
    {
        var exampleLines = await File.ReadAllLinesAsync("p107_network_example.txt");
        var result = Problem107.Solve(exampleLines);
        Assert.Equal(150, result);
    }
}
