using ProjectEuler.Problems._001_100._71_80;

namespace ProjectEuler.Tests.Problems._001_100._71_80;

[InheritsTests]
public class Problem080Tests : ProblemTestBase
{
    protected override IProblem Problem => new Problem080();

    protected override string Answer => "40886";

    [Test]
    public async Task Should_SolveExample()
    {
        var result = Problem080.DigitSum(2);

        await Assert.That(result).IsEqualTo(475);
    }
}
