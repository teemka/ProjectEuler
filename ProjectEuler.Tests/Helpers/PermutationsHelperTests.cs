using ProjectEuler.Helpers;

namespace ProjectEuler.Tests.Helpers;

public class PermutationsHelperTests
{
    [Fact]
    public void Should_GetPermutations()
    {
        // Arrange
        int[] arr = [1, 2, 3];

        // Act
        var result = arr.GetPermutations().Select(x => x.ToList());

        // Assert
        Assert.Equal(
            [
                [1, 2, 3],
                [2, 1, 3],
                [3, 1, 2],
                [1, 3, 2],
                [2, 3, 1],
                [3, 2, 1],
            ],
            result);
    }
}
