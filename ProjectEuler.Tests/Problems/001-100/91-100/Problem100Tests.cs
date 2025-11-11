using ProjectEuler.Problems._001_100._91_100;

namespace ProjectEuler.Tests.Problems._001_100._91_100;

public class Problem100Tests : ProblemTestBase
{
    protected override IProblem Problem { get; } = new Problem100();

    protected override string Answer { get; } = "";

    [Fact]
    public void ShouldSolveExample()
    {
        this.Problem.CalculateAsync([]);
    }
}
