using ProjectEuler.Helpers;

namespace ProjectEuler.Tests.Helpers;

public class CombinationsHelperTests
{
    private static readonly int[] List = [1, 2, 3];

    [Test]
    public async Task Should_GetCombinations()
    {
        // Act
        var result = List
            .GetCombinations(2)
            .ToList();

        // Assert
        var expected = new List<List<int>>
        {
            new() { 1, 2 },
            new() { 1, 3 },
            new() { 2, 3 },
        };

        await Assert.That(result).IsEquivalentTo(expected);
    }

    [Test]
    public async Task Should_GetCombinationsWithRepetitions()
    {
        // Act
        var result = List
            .GetCombinationsWithRepetitions(2)
            .ToArray();

        // Assert
        var expected = new List<List<int>>
        {
            new() { 1, 1 },
            new() { 1, 2 },
            new() { 1, 3 },
            new() { 2, 2 },
            new() { 2, 3 },
            new() { 3, 3 },
        };

        await Assert.That(result).IsEquivalentTo(expected);
    }
}
