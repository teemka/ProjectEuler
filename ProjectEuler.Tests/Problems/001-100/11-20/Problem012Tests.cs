using ProjectEuler.Problems._001_100._11_20;

namespace ProjectEuler.Tests.Problems._001_100._11_20;

[InheritsTests]
public class Problem012Tests : ProblemTestBase
{
    protected override IProblem Problem => new Problem012();

    protected override string Answer => "76576500";
}
