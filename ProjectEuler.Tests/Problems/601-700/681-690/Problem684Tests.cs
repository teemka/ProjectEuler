using ProjectEuler.Helpers;
using ProjectEuler.Problems._601_700._681_690;

namespace ProjectEuler.Tests.Problems._601_700._681_690;

public class Problem684Tests
{
    [Fact]
    public void Should_GetSmallestNumberOfDigits_For10()
    {
        Problem684.SmallestNumberWithDigitSumOf(10).Should().Be(19);
    }

    [Fact]
    public void Should_GetS20()
    {
        var f90 = Sequences.Fibonacci<int>().Skip(89).First();
        var result = Problem684.SmallestNumberWithDigitSumOf(f90);
    }
}
