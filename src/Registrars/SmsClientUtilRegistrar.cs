```
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Soenneker.Communication.Sms.Client.Abstract;

namespace Soenneker.Communication.Sms.Client.Registrars;

/// <summary>
/// An async thread-safe singleton for the Azure Communication Services SMS client
/// </summary>
public static class SmsClientUtilRegistrar
{
    /// <summary>
    /// Adds <see cref="ISmsClientUtil"/> as a singleton service. <para/>
    /// </summary>
    public static IServiceCollection AddSmsClientUtilAsSingleton(this IServiceCollection services)
    {
        services.TryAddSingleton<ISmsClientUtil, SmsClientUtil>();
        return services;
    }

    /// <summary>
    /// Adds <see cref="ISmsClientUtil"/> as a scoped service. <para/>
    /// </summary>
    public static IServiceCollection AddSmsClientUtilAsScoped(this IServiceCollection services)
    {
        services.TryAddScoped<ISmsClientUtil, SmsClientUtil>();
        return services;
    }
}
```