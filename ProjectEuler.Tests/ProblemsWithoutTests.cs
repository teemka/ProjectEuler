using System.Reflection;

namespace ProjectEuler.Tests;

public class ProblemsWithoutTests
{
    [Fact(Skip = "Some problems are unsolved")]
    public void AllShouldHaveTests()
    {
        var problems = Assembly
            .GetAssembly(typeof(IProblem))!
            .GetTypes()
            .Where(t => typeof(IProblem).IsAssignableFrom(t) && !t.IsInterface)
            .Select(x => x.Name)
            .Order();

        var tests = Assembly.GetExecutingAssembly()
            .GetTypes()
            .Where(t => typeof(ProblemTestBase).IsAssignableFrom(t) && t.IsClass)
            .Select(x => x.Name[..^5])
            .Order();

        problems.Except(tests).Should().BeEmpty();
    }
}
