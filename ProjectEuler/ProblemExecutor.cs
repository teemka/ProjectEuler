using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace ProjectEuler;

internal class ProblemExecutor(ILogger<ProblemExecutor> logger)
{
    internal async Task CalculateProblem(string[] args, IProblem problem)
    {
        var problemName = problem.GetType().Name;
        logger.LogInformation("Starting execution of {Problem}", problemName);

        var start = Stopwatch.GetTimestamp();
        var solution = await problem.CalculateAsync(args);
        var elapsed = Stopwatch.GetElapsedTime(start);

        logger.LogInformation("{Problem} solved in {Elapsed}. Solution: {Solution}", problemName, elapsed, solution);
    }
}
