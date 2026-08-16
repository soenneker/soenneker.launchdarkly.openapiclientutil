using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Soenneker.LaunchDarkly.HttpClients.Registrars;
using Soenneker.LaunchDarkly.OpenApiClientUtil.Abstract;

namespace Soenneker.LaunchDarkly.OpenApiClientUtil.Registrars;

/// <summary>
/// Registers the OpenAPI client utility for dependency injection.
/// </summary>
public static class LaunchDarklyOpenApiClientUtilRegistrar
{
    /// <summary>
    /// Adds <see cref="LaunchDarklyOpenApiClientUtil"/> as a singleton service. <para/>
    /// </summary>
    public static IServiceCollection AddLaunchDarklyOpenApiClientUtilAsSingleton(this IServiceCollection services)
    {
        services.AddLaunchDarklyOpenApiHttpClientAsSingleton()
                .TryAddSingleton<ILaunchDarklyOpenApiClientUtil, LaunchDarklyOpenApiClientUtil>();

        return services;
    }

    /// <summary>
    /// Adds <see cref="LaunchDarklyOpenApiClientUtil"/> as a scoped service. <para/>
    /// </summary>
    public static IServiceCollection AddLaunchDarklyOpenApiClientUtilAsScoped(this IServiceCollection services)
    {
        services.AddLaunchDarklyOpenApiHttpClientAsSingleton()
                .TryAddScoped<ILaunchDarklyOpenApiClientUtil, LaunchDarklyOpenApiClientUtil>();

        return services;
    }
}
