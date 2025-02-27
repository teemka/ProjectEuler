using ProjectEuler.Extensions;

namespace ProjectEuler.Tests.Extensions;

public class EnumerableExtensionsTests
{
    [Fact]
    public void Should_GetLexicographicPermutations()
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

        Assert.Equal(expected, permutations);
    }

    [Theory]
    [InlineData("0")]
    [InlineData("001")]
    [InlineData("1")]
    [InlineData("100")]
    [InlineData("123")]
    public void Should_CreateNumber(string number)
    {
        // Arrange
        var expected = int.Parse(number);
        var digits = number.Select(x => x.ToInt()).ToArray();

        // Act
        var result = digits.ToNumberFromDigits();

        // Assert
        Assert.Equal(expected, result);
    }
}
