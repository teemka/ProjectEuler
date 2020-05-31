using Microsoft.Extensions.DependencyInjection;
using System;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace ProjectEuler
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("Provide problem number");
                return;
            }

            var problemNumber = args[0];
            var problemName = $"Problem{problemNumber.PadLeft(3, '0')}";

            var sc = new ServiceCollection();

            var problemTypes = Assembly.GetExecutingAssembly().GetTypes().Where(t => typeof(IProblem).IsAssignableFrom(t) && !t.IsInterface);
            foreach (var problemType in problemTypes)
            {
                sc.AddTransient(typeof(IProblem), problemType);
            }

            var problems = sc.BuildServiceProvider().GetServices<IProblem>();

            IProblem? maybeProblem = problems.FirstOrDefault(s => s.GetType().Name == problemName);

            if (!(maybeProblem is IProblem problem))
            {
                Console.WriteLine($"{problemName} is not implemented. Implemented problems:");
                foreach (var p in problems)
                    Console.WriteLine(p.GetType().Name);
                return;
            }

            var sw = Stopwatch.StartNew();
            var solution = await problem.CalculateAsync(args.Skip(1).ToArray());
            sw.Stop();

            Console.WriteLine($"{problemName} solution: {solution}");
            Console.WriteLine($"Elapsed time: {sw.Elapsed}");
        }
    }
}
