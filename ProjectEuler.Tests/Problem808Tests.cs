using ProjectEuler.Helpers;
using ProjectEuler.Problems._801_900._801_810;

namespace ProjectEuler.Tests;

public class Problem808Tests : ProblemTestBase
{
    public override IProblem Problem => new Problem808(new SieveOfErasthotenes());

    public override string Answer => "3807504276997394";
}
