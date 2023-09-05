using ProjectEuler.Problems._601_700._681_690;

namespace ProjectEuler.Tests.Problems._601_700._681_690;

public class Problem686Tests
{
    [Theory]
    [InlineData("12", "1", "7")]
    [InlineData("12", "2", "80")]
    [InlineData("123", "45", "12710")]
    public async void Should_CalculateExample(string l, string n, string j)
    {
        var problem = new Problem686();

        var result = await problem.CalculateAsync(new[] { l, n });

        Assert.Equal(j, result);
    }
}
