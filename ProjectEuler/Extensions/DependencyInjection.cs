using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using System.Text.RegularExpressions;

namespace ProjectEuler.Extensions;

/// <summary>
/// Dependency injection helpers.
/// </summary>
internal static partial class DependencyInjection
{
    internal static IServiceCollection AddProblems(this IServiceCollection services)
    {
        var problemTypes = Assembly
            .GetExecutingAssembly()
            .GetTypes()
            .Where(t => typeof(IProblem).IsAssignableFrom(t)
                && !t.IsInterface
                && ProblemRegex().IsMatch(t.Name))
            .OrderBy(x => x.Name);

        foreach (var problemType in problemTypes)
        {
            services.AddTransient(typeof(IProblem), problemType);
        }

        services.AddTransient<IPrimes, SieveOfErasthotenes>();

        return services;
    }

    internal static IDictionary<int, IProblem> GetProblemsByNumber(this IServiceProvider sp) => sp
        .GetServices<IProblem>()
        .ToDictionary(
            x => int.Parse(x.GetType().Name.Substring(7, 3)),
            x => x);

    [GeneratedRegex("^Problem\\d{3}$")]
    private static partial Regex ProblemRegex();
}
