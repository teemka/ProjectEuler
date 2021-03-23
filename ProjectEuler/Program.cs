using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectEuler
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("Provide problem number or --all");
                return;
            }

            var problems = CreateProblems();

            if (args[0] == "--all")
            {
                await problems.ForEachAsync(24, async p => await CalculateProblem(args, p));
            }
            else if (int.TryParse(args[0], out var problemNumber))
            {
                var problemName = $"Problem{problemNumber:000}";
                IProblem? maybeProblem = problems.FirstOrDefault(s => s.GetType().Name == problemName);

                if (maybeProblem is not IProblem problem)
                {
                    Console.WriteLine($"{problemName} is not implemented. Implemented problems:");
                    foreach (var p in problems)
                        Console.WriteLine(p.GetType().Name);
                    return;
                }

                await CalculateProblem(args, problem);
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

        private static IEnumerable<IProblem> CreateProblems()
        {
            var sc = new ServiceCollection();

            var problemTypes = Assembly.GetExecutingAssembly().GetTypes()
                .Where(t => typeof(IProblem).IsAssignableFrom(t) && !t.IsInterface);

            foreach (var problemType in problemTypes)
                sc.AddTransient(typeof(IProblem), problemType);

            return sc.BuildServiceProvider()
                .GetServices<IProblem>()
                .OrderBy(p => p.GetType().Name);
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
