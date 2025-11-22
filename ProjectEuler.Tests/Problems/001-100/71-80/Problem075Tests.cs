using ProjectEuler.Problems._001_100._71_80;

namespace ProjectEuler.Tests.Problems._001_100._71_80;

[InheritsTests]
public class Problem075Tests : ProblemTestBase
{
    protected override IProblem Problem => new Problem075();

    protected override string Answer => "161667";

    [Test]
    public async Task Should_CalculateExample()
    {
        // Act
        var result = await new Problem075().CalculateAsync(["120"]);

        // Assert
        await Assert.That(result).IsEqualTo("13");
    }
}
