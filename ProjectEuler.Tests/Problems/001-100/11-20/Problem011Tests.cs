using ProjectEuler.Problems._001_100._11_20;

namespace ProjectEuler.Tests.Problems._001_100._11_20;

[InheritsTests]
public class Problem011Tests : ProblemTestBase
{
    protected override IProblem Problem => new Problem011();

    protected override string Answer => "70600674";
}
