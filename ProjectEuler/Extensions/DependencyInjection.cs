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
            services.AddKeyedTransient(typeof(IProblem), problemType.GetProblemNumber(), problemType);
        }

        return services;
    }

    private static int GetProblemNumber(this Type type) => int.Parse(type.Name.Substring(7, 3));

    [GeneratedRegex("^Problem\\d{3}$")]
    private static partial Regex ProblemRegex();
}
