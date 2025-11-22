using ProjectEuler.Problems._001_100._1_10;

namespace ProjectEuler.Tests.Problems._001_100._1_10;

[InheritsTests]
public class Problem001Tests : ProblemTestBase
{
    protected override IProblem Problem => new Problem001();

    protected override string Answer => "233168";
}
