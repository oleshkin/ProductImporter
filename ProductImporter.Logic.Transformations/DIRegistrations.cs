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
            services.AddScoped<ICurrencyNormalizer, CurrencyNormalizer>();
        }
        else
        {
            services.AddScoped<ICurrencyNormalizer, NullCurrencyNormalizer>();
        }
        services.AddScoped<INameDecapitaliser, NameDecapitaliser>();

        services.AddScoped<IDateTimeProvider, DateTimeProvider>();
        services.AddScoped<IReferenceAdder, ReferenceAdder>();
        services.AddScoped<IReferenceGenerator, ReferenceGenerator>();
        services.AddSingleton<IProductCounter, ProductCounter>();
        return services;
    }
}