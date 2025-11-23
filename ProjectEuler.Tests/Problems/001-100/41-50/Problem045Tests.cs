using ProjectEuler.Helpers;
using ProjectEuler.Problems._001_100._41_50;

namespace ProjectEuler.Tests.Problems._001_100._41_50;

[InheritsTests]
public class Problem045Tests : ProblemTestBase
{
    protected override IProblem Problem => new Problem045();

    protected override string Answer => "1533776805";

    [Test]
    public async Task Should_Contain40755()
    {
        var t285 = Sequences.TriangleNumbers(285).First();
        var p165 = Sequences.PentagonalNumbers(165).First();
        var h143 = Sequences.HexagonalNumbers(143).First();

        await Assert.That(t285).IsEqualTo(p165);
        await Assert.That(t285).IsEqualTo(h143);
    }
}
