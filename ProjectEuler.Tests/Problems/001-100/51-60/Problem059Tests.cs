using Microsoft.Extensions.Logging.Abstractions;
using ProjectEuler.Problems._001_100._51_60;

namespace ProjectEuler.Tests.Problems._001_100._51_60;

[InheritsTests]
public class Problem059Tests : ProblemTestBase
{
    protected override IProblem Problem => new Problem059(NullLogger<Problem059>.Instance);

    protected override string Answer => "129448";
}
