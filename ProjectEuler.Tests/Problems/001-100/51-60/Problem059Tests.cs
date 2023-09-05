using Microsoft.Extensions.Logging.Abstractions;
using ProjectEuler.Problems._001_100._51_60;

namespace ProjectEuler.Tests.Problems._001_100._51_60;

public class Problem059Tests : ProblemTestBase
{
    public override IProblem Problem => new Problem059(NullLogger<Problem059>.Instance);

    public override string Answer => "129448";
}
