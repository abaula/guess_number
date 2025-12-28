using Microsoft.Extensions.DependencyInjection;

namespace GuessNumber
{
    static class ServiceCollectionExctensions
    {
        public static IServiceCollection AddScopedWithLazy<TService, TImplementation>(this IServiceCollection services)
            where TService : class
            where TImplementation : class, TService
        {
            services.AddScoped<TService, TImplementation>();
            services.AddScoped(_ => new Lazy<TService>(() => _.GetRequiredService<TService>()));
            return services;
        }

        public static IServiceCollection AddSingletonWithLazy<TService, TImplementation>(this IServiceCollection services)
            where TService : class
            where TImplementation : class, TService
        {
            services.AddSingleton<TService, TImplementation>();
            services.AddSingleton(_ => new Lazy<TService>(() => _.GetRequiredService<TService>()));
            return services;
        }
    }
}