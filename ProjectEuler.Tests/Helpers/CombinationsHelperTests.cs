using ProjectEuler.Helpers;

namespace ProjectEuler.Tests.Helpers;

public class CombinationsHelperTests
{
    private static readonly int[] List = [1, 2, 3];

    [Fact]
    public void Should_GetCombinations()
    {
        // Act
        var result = List
            .GetCombinations(2)
            .ToArray();

        // Assert
        Assert.Equal(
            [
                [1, 2],
                [1, 3],
                [2, 3],
            ],
            result);
    }

    [Fact]
    public void Should_GetCombinationsWithRepetitions()
    {
        // Act
        var result = List
            .GetCombinationsWithRepetitions(2)
            .ToArray();

        // Assert
        Assert.Equal(
            [
                [1, 1],
                [1, 2],
                [1, 3],
                [2, 2],
                [2, 3],
                [3, 3],
            ],
            result);
    }
}
