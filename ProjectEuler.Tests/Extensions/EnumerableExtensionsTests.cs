using ProjectEuler.Extensions;

namespace ProjectEuler.Tests.Extensions;

public class EnumerableExtensionsTests
{
    [Fact]
    public void Should_Permute()
    {
        var permutations = "123".ToCharArray().GetPermutations().Select(x => string.Concat(x)).ToArray();

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
}
