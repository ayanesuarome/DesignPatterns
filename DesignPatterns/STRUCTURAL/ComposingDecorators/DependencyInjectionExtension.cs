using ComposingDecorators.Decorators;
using Microsoft.Extensions.Caching.Memory;
using Polly;

namespace ComposingDecorators;

public static class DependencyInjectionExtension
{
    public static IServiceCollection AddDecoratorManually(this IServiceCollection services)
    {
        services.AddTransient<ProductService>();

        // Register the decorators manually
        services.AddTransient<IProductService>(serviceProvider =>
        {
            var retryPolicy = serviceProvider.GetRequiredService<IAsyncPolicy>();
            var cacheMemory = serviceProvider.GetRequiredService<IMemoryCache>();
            var logging = serviceProvider.GetRequiredService<ILogger<LoggingProductServiceDecorator>>();

            // Resolve the inner service (ProductService)
            // 4th (last) to be called
            var productService = serviceProvider.GetRequiredService<ProductService>();

            // Wrap with the retry decorator
            // 3rd to be called
            var retryDecorator = new RetryProductServiceDecorator(productService, retryPolicy);

            // Wrap with the caching decorator
            // 2nd to be called
            var cachingDecorator = new CachingProductServiceDecorator(retryDecorator, cacheMemory);

            // Wrap with the logging decorator
            // 1st to be called
            return new LoggingProductServiceDecorator(cachingDecorator, logging);
        });

        return services;
    }

    public static IServiceCollection AddDecoratorWithScrutor(this IServiceCollection services)
    {
        services.AddScoped<IProductService, ProductService>();

        services.Decorate<IProductService, RetryProductServiceDecorator>();
        services.Decorate<IProductService, CachingProductServiceDecorator>();
        services.Decorate<IProductService, LoggingProductServiceDecorator>();

        return services;
    }
}
