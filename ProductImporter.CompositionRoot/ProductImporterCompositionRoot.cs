using Microsoft.Extensions.DependencyInjection;
using ProductImporter.Logic.Shared;
using ProductImporter.Logic.Source;
using ProductImporter.Logic.Target;
using ProductImporter.Logic.Transformation;
using ProductImporter.Logic.Transformations.Util;
using ProductImporter.Logic.Transformations;

namespace ProductImporter.CompositionRoot;

public static class ProductImporterCompositionRoot
{
    public static IServiceCollection AddProductImporter(this IServiceCollection services)
    {
        services.AddSingleton<Configuration>();

        services.AddTransient<IPriceParser, PriceParser>();
        services.AddTransient<IProductFormatter, ProductFormatter>();
        services.AddTransient<IProductSource, ProductSource>();
        services.AddTransient<IProductTarget, CsvProductTarget>();
        services.AddSingleton<IImportStatistics, ImportStatistics>();

        services.AddTransient<ProductImporter.Logic.ProductImporter>();

        services.AddScoped<IProductTransformationContext, ProductTransformationContext>();
        services.AddScoped<ICurrencyNormalizer, CurrencyNormalizer>();
        services.AddScoped<INameDecapitaliser, NameDecapitaliser>();

        services.AddScoped<IDateTimeProvider, DateTimeProvider>();
        services.AddScoped<IReferenceAdder, ReferenceAdder>();
        services.AddScoped<IReferenceGenerator, ReferenceGenerator>();
        services.AddSingleton<IProductCounter, ProductCounter>();

        services.AddTransient<IProductTransformer, ProductTransformer>();

        return services;
    }
}
