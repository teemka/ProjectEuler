using ProjectEuler.Helpers;

namespace ProjectEuler.Tests.Problems._001_100._41_50;

public class Problem045Tests
{
    [Fact]
    public void Should_Contain40755()
    {
        var t285 = Sequences.TriangleNumbers(285).First();
        var p165 = Sequences.PentagonalNumbers(165).First();
        var h143 = Sequences.HexagonalNumbers(143).First();

        t285.Should().Be(p165).And.Be(h143);
    }
}
