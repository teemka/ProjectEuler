using ProjectEuler.Helpers;

namespace ProjectEuler.Tests.Helpers;

public class PermutationsHelperTests
{
    [Test]
    public async Task Should_GetPermutations()
    {
        // Arrange
        int[] arr = [1, 2, 3];

        // Act
        var result = arr.GetPermutations().Select(x => x.ToList());

        // Assert
        var expected = new List<List<int>>
        {
            new() { 1, 2, 3 },
            new() { 2, 1, 3 },
            new() { 3, 1, 2 },
            new() { 1, 3, 2 },
            new() { 2, 3, 1 },
            new() { 3, 2, 1 },
        };

        await Assert.That(result).IsEquivalentTo(expected);
    }
}
