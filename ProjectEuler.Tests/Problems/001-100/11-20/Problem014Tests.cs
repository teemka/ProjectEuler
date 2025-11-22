using ProjectEuler.Problems._001_100._11_20;

namespace ProjectEuler.Tests.Problems._001_100._11_20;

[InheritsTests]
public class Problem014Tests : ProblemTestBase
{
    protected override IProblem Problem => new Problem014();

    protected override string Answer => "837799";

    [Test]
    [Arguments(13, 10)]
    [Arguments(837799, 525)]
    public async Task Should_SolveExample(int start, int expected)
    {
        // Act
        var result = new Problem014().CollatzCount(start);

        // Assert
        await Assert.That(result).IsEqualTo(expected);
    }
}
