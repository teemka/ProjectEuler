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
    public void Should_GetFirstSquareNumbers()
    {
        var squareNumbers = Sequences.SquareNumbers().Take(5).ToArray();

        squareNumbers.Should().Equal(1, 4, 9, 16, 25);
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

    [Fact]
    public void Should_GetFirst5HeptagonalNumbers()
    {
        var hexagonalNumbers = Sequences.HeptagonalNumbers().Take(5).ToArray();

        hexagonalNumbers.Should().Equal(1, 7, 18, 34, 55);
    }

    [Fact]
    public void Should_GetFirst5OctagonalNumbers()
    {
        var hexagonalNumbers = Sequences.OctagonalNumbers().Take(5).ToArray();

        hexagonalNumbers.Should().Equal(1, 8, 21, 40, 65);
    }
}
