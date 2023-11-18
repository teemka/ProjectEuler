using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace ProjectEuler;

public class ProblemExecutor(ILogger<ProblemExecutor> logger)
{
    public async Task CalculateProblem(string[] args, IProblem problem)
    {
        var problemName = problem.GetType().Name;
        logger.LogInformation("Starting execution of {Problem}", problemName);

        var sw = Stopwatch.StartNew();

        var solution = await problem.CalculateAsync(args);
        sw.Stop();
        logger.LogInformation("{Problem} solved in {Elapsed}. Solution: {solution}", problemName, sw.Elapsed, solution);
    }
}
