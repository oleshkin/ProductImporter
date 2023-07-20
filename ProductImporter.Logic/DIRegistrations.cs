using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProductImporter.Logic.Shared;
using ProductImporter.Logic.Source;
using ProductImporter.Logic.Target;
using ProductImporter.Logic.Transformation;

namespace ProductImporter.Logic;

public static class DIRegistrations
{
    public static IServiceCollection AddProductImporterLogic(this IServiceCollection services)
    {
        services.AddTransient<IPriceParser, PriceParser>();
        services.AddTransient<IProductFormatter, ProductFormatter>();
        services.AddTransient<IProductSource, ProductSource>();
        services.AddTransient<IProductTarget, CsvProductTarget>();

        services.AddTransient<Logic.ProductImporter>();

        services.AddSingleton<IImportStatistics, ImportStatistics>();
        services.AddTransient<IProductTransformer, ProductTransformer>();

        services.AddOptions<CsvProductTargetOptions>()
            .Configure<IConfiguration>((options, configuration) =>
            {
                configuration.GetSection().Bind(options);
            });
        return services;
    }
}
