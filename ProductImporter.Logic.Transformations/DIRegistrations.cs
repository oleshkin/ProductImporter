using Microsoft.Extensions.DependencyInjection;
using ProductImporter.Logic.Transformations.Util;

namespace ProductImporter.Logic.Transformations;

public static class DIRegistrations
{
    public static IServiceCollection AddProductTransformations(this IServiceCollection services)
    {
        services.AddScoped<IProductTransformationContext, ProductTransformationContext>();
        services.AddScoped<ICurrencyNormalizer, CurrencyNormalizer>();
        services.AddScoped<INameDecapitaliser, NameDecapitaliser>();

        services.AddScoped<IDateTimeProvider, DateTimeProvider>();
        services.AddScoped<IReferenceAdder, ReferenceAdder>();
        services.AddScoped<IReferenceGenerator, ReferenceGenerator>();
        services.AddSingleton<IProductCounter, ProductCounter>();
        return services;
    }
}
