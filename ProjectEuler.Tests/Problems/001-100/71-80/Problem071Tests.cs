using ProjectEuler.Problems._001_100._71_80;

namespace ProjectEuler.Tests.Problems._001_100._71_80;

public class Problem071Tests : ProblemTestBase
{
    public override IProblem Problem => new Problem071();

    public override string Answer => "428570";

    [Fact]
    public void Should_CalculateExample()
    {
        var result = Problem071.Calculate(8);

        result.Nominator.Should().Be(2);
        result.Denominator.Should().Be(5);
    }
}
