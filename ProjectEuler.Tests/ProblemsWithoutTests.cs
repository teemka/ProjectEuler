namespace ProjectEuler.Tests;

public class ProblemsWithoutTests
{
    [Test]
    public async Task AllShouldHaveTests()
    {
        var problems = System.Reflection.Assembly
            .GetAssembly(typeof(IProblem))!
            .GetTypes()
            .Where(t => typeof(IProblem).IsAssignableFrom(t) && !t.IsInterface)
            .Select(x => x.Name)
            .Order();

        var tests = System.Reflection.Assembly.GetExecutingAssembly()
            .GetTypes()
            .Where(t => typeof(ProblemTestBase).IsAssignableFrom(t) && t.IsClass)
            .Select(x => x.Name[..^5])
            .Order();

        await Assert.That(problems.Except(tests)).IsEmpty();
    }
}
