using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Reflection;
using System.Text.RegularExpressions;

namespace ProjectEuler;

public static class Program
{
    public static async Task Main(string[] args)
    {
        if (args.Length == 0)
        {
            Console.WriteLine("Provide problem number or --all");
            return;
        }

        var sp = new ServiceCollection()
            .AddLogging(x => x.AddSimpleConsole())
            .AddProblems()
            .AddTransient<ProblemExecutor>()
            .BuildServiceProvider();

        var problems = sp.GetProblemsByNumber();

        if (args[0] == "--all")
        {
            await Parallel.ForEachAsync(problems.Values, async (p, ct) => await CalculateProblem(args, p));
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

            await sp.GetRequiredService<ProblemExecutor>()
                .CalculateProblem(args.Skip(1).ToArray(), problem);
        }
        else
        {
            Console.WriteLine("Command not known");
        }
    }

    private static async Task CalculateProblem(string[] args, IProblem problem)
    {
        var sw = Stopwatch.StartNew();
        var solution = await problem.CalculateAsync(args.Skip(1).ToArray());
        sw.Stop();

        Console.WriteLine($"{problem.GetType().Name} solved in {sw.Elapsed}. Solution: {solution}");
    }

    private static IServiceCollection AddProblems(this IServiceCollection services)
    {
        var problemTypes = Assembly
            .GetExecutingAssembly()
            .GetTypes()
            .Where(t => typeof(IProblem).IsAssignableFrom(t)
                && !t.IsInterface
                && Regex.IsMatch(t.Name, @"^Problem\d{3}$"))
            .OrderBy(x => x.Name);

        foreach (var problemType in problemTypes)
        {
            services.AddTransient(typeof(IProblem), problemType);
        }

        return services;
    }

    private static IDictionary<int, IProblem> GetProblemsByNumber(this IServiceProvider sp)
    {
        return sp
            .GetServices<IProblem>()
            .ToDictionary(
                x => int.Parse(x.GetType().Name.Substring(7, 3)),
                x => x);
    }
}
