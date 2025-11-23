using ProjectEuler.Problems._001_100._1_10;

namespace ProjectEuler.Tests.Problems._001_100._1_10;

[InheritsTests]
public class Problem007Tests : ProblemTestBase
{
    protected override IProblem Problem => new Problem007();

    protected override string Answer => "104743";
}
