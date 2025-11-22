using ProjectEuler.Problems._001_100._71_80;

namespace ProjectEuler.Tests.Problems._001_100._71_80;

[InheritsTests]
public class Problem071Tests : ProblemTestBase
{
    protected override IProblem Problem => new Problem071();

    protected override string Answer => "428570";

    [Test]
    public async Task Should_CalculateExample()
    {
        var result = Problem071.Calculate(8);

        await Assert.That(result.Numerator).IsEqualTo(2);
        await Assert.That(result.Denominator).IsEqualTo(5);
    }
}
