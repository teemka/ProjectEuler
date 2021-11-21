using ProjectEuler.Helpers;

namespace ProjectEuler.Tests.Helpers;

public class SequencesTests
{
    [Fact]
    public void Should_GetFirst5TriangleNumbers()
    {
        var triangleNumbers = Sequences.TriangleNumbers().Take(5).ToArray();

        triangleNumbers.Should().Equal(1, 3, 6, 10, 15);
    }

    [Fact]
    public void Should_GetFirst10PentagonalNumbers()
    {
        var pentagonalNumbers = Sequences.PentagonalNumbers().Take(10).ToArray();

        pentagonalNumbers.Should().Equal(1, 5, 12, 22, 35, 51, 70, 92, 117, 145);
    }

    [Fact]
    public void Should_GetFirst5HexagonalNumbers()
    {
        var hexagonalNumbers = Sequences.HexagonalNumbers().Take(5).ToArray();

        hexagonalNumbers.Should().Equal(1, 6, 15, 28, 45);
    }
}
