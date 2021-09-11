using ProjectEuler.Problems._001_100._41_50;

namespace ProjectEuler.Tests;

public class Problem045Tests
{
    [Fact]
    public void Should_GetExampleTriangleNumbers()
    {
        var triangleNumbers = Problem045.TriangleNumbers().Take(5).ToArray();

        triangleNumbers.Should().Equal(1, 3, 6, 10, 15);
    }

    [Fact]
    public void Should_GetExamplePentagonalNumbers()
    {
        var pentagonalNumbers = Problem045.PentagonalNumbers().Take(5).ToArray();

        pentagonalNumbers.Should().Equal(1, 5, 12, 22, 35);
    }

    [Fact]
    public void Should_GetExampleHexagonalNumbers()
    {
        var hexagonalNumbers = Problem045.HexagonalNumbers().Take(5).ToArray();

        hexagonalNumbers.Should().Equal(1, 6, 15, 28, 45);
    }

    [Fact]
    public void Should_Contain40755()
    {
        var t285 = Problem045.TriangleNumbers(285).First();
        var p165 = Problem045.PentagonalNumbers(165).First();
        var h143 = Problem045.HexagonalNumbers(143).First();

        t285.Should().Be(p165).And.Be(h143);
    }
}
