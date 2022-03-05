using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using System.Text.RegularExpressions;

namespace ProjectEuler.Extensions;

internal static class DependencyInjection
{
    internal static IServiceCollection AddProblems(this IServiceCollection services)
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

    internal static IDictionary<int, IProblem> GetProblemsByNumber(this IServiceProvider sp) => sp
        .GetServices<IProblem>()
        .ToDictionary(
            x => int.Parse(x.GetType().Name.Substring(7, 3)),
            x => x);
}
