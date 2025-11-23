using ProjectEuler.Problems._001_100._31_40;

namespace ProjectEuler.Tests.Problems._001_100._31_40;

[InheritsTests]
public class Problem038Tests : ProblemTestBase
{
    protected override IProblem Problem => new Problem038();

    protected override string Answer => "932718654";

    [Test]
    [Arguments(1, 2, 12)]
    [Arguments(123, 3, 123246369)]
    [Arguments(1, 9, 123456789)]
    [Arguments(192, 3, 192384576)]
    [Arguments(9, 5, 918273645)]
    public async Task Should_SolveExample(int number, int n, long expected)
    {
        // Arrange

        // Act
        var result = new Problem038().CreateMultiple(number, n);

        // Assert
        await Assert.That(result).IsEqualTo(expected);
    }
}
