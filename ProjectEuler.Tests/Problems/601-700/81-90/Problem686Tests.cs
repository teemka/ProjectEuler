using ProjectEuler.Problems._601_700._81_90;

namespace ProjectEuler.Tests.Problems._601_700._81_90;

[InheritsTests]
public class Problem686Tests : ProblemTestBase
{
    protected override IProblem Problem => new Problem686();

    protected override string Answer => "193060223";

    [Test]
    public async Task Should_SolveExample()
    {
        var actual = Problem686.Calculate(45);

        await Assert.That(actual).IsEqualTo(12710);
    }
}
