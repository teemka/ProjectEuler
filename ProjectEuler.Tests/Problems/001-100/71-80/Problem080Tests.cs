using ProjectEuler.Problems._001_100._71_80;

namespace ProjectEuler.Tests.Problems._001_100._71_80;

public class Problem080Tests : ProblemTestBase
{
    protected override IProblem Problem => new Problem080();

    protected override string Answer => "40886";

    [Fact]
    public void Should_SolveExample()
    {
        var result = Problem080.DigitSum(2);

        Assert.Equal(475, result);
    }
}
