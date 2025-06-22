using Microsoft.Extensions.Logging.Abstractions;
using ProjectEuler.Problems._001_100._71_80;

namespace ProjectEuler.Tests.Problems._001_100._71_80;

public class Problem078Tests : ProblemTestBase
{
    protected override IProblem Problem => new Problem078(NullLogger<Problem078>.Instance);

    protected override string Answer => "";
}
