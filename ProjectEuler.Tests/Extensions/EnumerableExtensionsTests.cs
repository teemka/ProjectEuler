using ProjectEuler.Extensions;
using TUnit.Assertions.Enums;

namespace ProjectEuler.Tests.Extensions;

public class EnumerableExtensionsTests
{
    [Test]
    public async Task Should_GetLexicographicPermutations()
    {
        var permutations = "123".ToCharArray().GetLexicographicPermutations().Select(x => string.Concat(x)).ToArray();

        HashSet<string> expected =
        [
            "123",
            "132",
            "213",
            "231",
            "312",
            "321",
        ];

        await Assert.That(permutations).IsEquivalentTo(expected, CollectionOrdering.Matching);
    }

    [Test]
    [Arguments("0")]
    [Arguments("001")]
    [Arguments("1")]
    [Arguments("100")]
    [Arguments("123")]
    public async Task Should_CreateNumber(string number)
    {
        // Arrange
        var expected = int.Parse(number);
        var digits = number.Select(x => x.ToInt()).ToArray();

        // Act
        var result = digits.ToNumberFromDigits();

        // Assert
        await Assert.That(result).IsEqualTo(expected);
    }
}
