using ProjectEuler.Problems._001_100._21_30;

namespace ProjectEuler.Tests.Problems._001_100._21_30;

[InheritsTests]
public class Problem025Tests : ProblemTestBase
{
    protected override IProblem Problem => new Problem025();

    protected override string Answer => "4782";
}
