using ProjectEuler.Helpers;
using TUnit.Assertions.Enums;

namespace ProjectEuler.Tests.Helpers;

public class SequencesTests
{
    [Test]
    public async Task Should_GetFirst5TriangleNumbers()
    {
        var triangleNumbers = Sequences.TriangleNumbers().Take(5).ToArray();

        await Assert.That(triangleNumbers).IsEquivalentTo([1L, 3, 6, 10, 15], CollectionOrdering.Matching);
    }

    [Test]
    public async Task Should_GetFirstSquareNumbers()
    {
        var squareNumbers = Sequences.SquareNumbers().Take(5).ToArray();

        await Assert.That(squareNumbers).IsEquivalentTo([1L, 4, 9, 16, 25], CollectionOrdering.Matching);
    }

    [Test]
    public async Task Should_GetFirst10PentagonalNumbers()
    {
        var pentagonalNumbers = Sequences.PentagonalNumbers().Take(10).ToArray();

        await Assert.That(pentagonalNumbers).IsEquivalentTo([1L, 5, 12, 22, 35, 51, 70, 92, 117, 145], CollectionOrdering.Matching);
    }

    [Test]
    public async Task Should_GetFirst5HexagonalNumbers()
    {
        var hexagonalNumbers = Sequences.HexagonalNumbers().Take(5).ToArray();

        await Assert.That(hexagonalNumbers).IsEquivalentTo([1L, 6, 15, 28, 45], CollectionOrdering.Matching);
    }

    [Test]
    public async Task Should_GetFirst5HeptagonalNumbers()
    {
        var hexagonalNumbers = Sequences.HeptagonalNumbers().Take(5).ToArray();

        await Assert.That(hexagonalNumbers).IsEquivalentTo([1L, 7, 18, 34, 55], CollectionOrdering.Matching);
    }

    [Test]
    public async Task Should_GetFirst5OctagonalNumbers()
    {
        var hexagonalNumbers = Sequences.OctagonalNumbers().Take(5).ToArray();

        await Assert.That(hexagonalNumbers).IsEquivalentTo([1L, 8, 21, 40, 65], CollectionOrdering.Matching);
    }
}
