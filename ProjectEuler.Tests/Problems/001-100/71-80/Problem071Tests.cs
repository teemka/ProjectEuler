using ProjectEuler.Problems._001_100._71_80;

namespace ProjectEuler.Tests.Problems._001_100._71_80;

public class Problem071Tests : ProblemTestBase
{
    protected override IProblem Problem => new Problem071();

    protected override string Answer => "428570";

    [Fact]
    public void Should_CalculateExample()
    {
        var result = Problem071.Calculate(8);

        Assert.Equal(2, result.Numerator);
        Assert.Equal(5, result.Denominator);
    }
}
