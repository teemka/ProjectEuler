using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using ProjectEuler;

if (args.Length == 0)
{
    Console.WriteLine("Provide problem number or --all");
    return;
}

await using var sp = new ServiceCollection()
    .AddLogging(x => x.AddSimpleConsole())
    .AddProblems()
    .AddTransient<ProblemExecutor>()
    .BuildServiceProvider();

var problems = sp.GetProblemsByNumber();

if (args[0] == "--all")
{
    await Parallel.ForEachAsync(problems.Values, async (p, ct) => await ExecuteProblem(p));
}
else if (int.TryParse(args[0], out var problemNumber))
{
    if (!problems.TryGetValue(problemNumber, out var problem))
    {
        Console.WriteLine($"Problem{problemNumber:000} is not implemented. Implemented problems:");
        foreach (var p in problems)
        {
            Console.WriteLine(p.Value.GetType().Name);
        }

        return;
    }

    await ExecuteProblem(problem);
}
else
{
    Console.WriteLine("Command not known");
}

Task ExecuteProblem(IProblem problem) => sp
    .GetRequiredService<ProblemExecutor>()
    .CalculateProblem(args.Skip(1).ToArray(), problem);
