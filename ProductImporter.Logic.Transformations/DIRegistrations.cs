using Microsoft.Extensions.DependencyInjection;
using ProductImporter.Logic.Transformations.Util;

namespace ProductImporter.Logic.Transformations;

public static class DIRegistrations
{
    public static IServiceCollection AddProductTransformations(this IServiceCollection services, 
        Action<ProductTransformationOptions> optionsModifier)
    {
        var options = new ProductTransformationOptions();

        services.AddScoped<IProductTransformationContext, ProductTransformationContext>();

        optionsModifier(options);
        if (options.EnableCurrencyNormalizer)
        {
            services.AddScoped<IProductTransformations, CurrencyNormalizer>();
        }
        else
        {
            services.AddScoped<IProductTransformations, NullCurrencyNormalizer>();
        }
        services.AddScoped<IProductTransformations, NameDecapitaliser>();

        services.AddScoped<IDateTimeProvider, DateTimeProvider>();
        services.AddScoped<IProductTransformations, ReferenceAdder>();
        services.AddScoped<IReferenceGenerator, ReferenceGenerator>();
        services.AddSingleton<IProductCounter, ProductCounter>();
        return services;
    }
}