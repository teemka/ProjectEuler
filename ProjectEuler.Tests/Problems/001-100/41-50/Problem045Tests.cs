using ProjectEuler.Helpers;
using ProjectEuler.Problems._001_100._41_50;

namespace ProjectEuler.Tests.Problems._001_100._41_50;

public class Problem045Tests : ProblemTestBase
{
    public override IProblem Problem => new Problem045();

    public override string Answer => "1533776805";

    [Fact]
    public void Should_Contain40755()
    {
        var t285 = Sequences.TriangleNumbers(285).First();
        var p165 = Sequences.PentagonalNumbers(165).First();
        var h143 = Sequences.HexagonalNumbers(143).First();

        t285.Should().Be(p165).And.Be(h143);
    }
}
