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

if (args[0] == "--all")
{
    await Parallel.ForEachAsync(
        sp.GetServices<IProblem>(),
        async (p, _) => await ExecuteProblem(p));

    return;
}

if (int.TryParse(args[0], out var problemNumber))
{
    var problem = sp.GetKeyedService<IProblem>(problemNumber);

    if (problem is null)
    {
        Console.WriteLine($"Problem{problemNumber:000} is not implemented. Implemented problems:");
        foreach (var p in sp.GetServices<IProblem>())
        {
            Console.WriteLine(p.GetType().Name);
        }

        return;
    }

    await ExecuteProblem(problem);
    return;
}

Console.WriteLine($"Command '{args[0]}' not known");

Task ExecuteProblem(IProblem problem) => sp
    .GetRequiredService<ProblemExecutor>()
    .CalculateProblem(args[1..], problem);
