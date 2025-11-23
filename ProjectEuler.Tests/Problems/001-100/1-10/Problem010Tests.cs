using ProjectEuler.Problems._001_100._1_10;

namespace ProjectEuler.Tests.Problems._001_100._1_10;

[InheritsTests]
public class Problem010Tests : ProblemTestBase
{
    protected override IProblem Problem => new Problem010();

    protected override string Answer => "142913828922";
}
