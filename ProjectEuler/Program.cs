using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ProjectEuler
{
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
                await problems.Values.ForEachAsync(24, async p => await CalculateProblem(args, p));
            }
            else if (int.TryParse(args[0], out var problemNumber))
            {
                if (!problems.TryGetValue(problemNumber, out var problem))
                {
                    Console.WriteLine($"Problem{problemNumber:000} is not implemented. Implemented problems:");
                    foreach (var p in problems)
                        Console.WriteLine(p.GetType().Name);
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
                    && Regex.IsMatch(t.Name, @"^Problem\d{3}$"));

            foreach (var problemType in problemTypes)
                services.AddTransient(typeof(IProblem), problemType);

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

    public static class XDFD
    {
        public static Task ForEachAsync<T>(this IEnumerable<T> source, int dop, Func<T, Task> body)
        {
            return Task.WhenAll(
                from partition in Partitioner.Create(source).GetPartitions(dop)
                select Task.Run(async delegate
                {
                    using (partition)
                    {
                        while (partition.MoveNext())
                            await body(partition.Current);
                    }
                }));
        }
    }
}
