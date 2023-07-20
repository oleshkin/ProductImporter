using Microsoft.Extensions.DependencyInjection;
using ProductImporter.Logic.Shared;
using ProductImporter.Logic.Source;
using ProductImporter.Logic.Target;
using ProductImporter.Logic.Transformation;
using ProductImporter.Logic.Transformations.Util;
using ProductImporter.Logic.Transformations;
using ProductImporter.Logic;

namespace ProductImporter.CompositionRoot;

public static class ProductImporterCompositionRoot
{
    public static IServiceCollection AddProductImporter(this IServiceCollection services)
    {
        services.AddProductImporterLogic();
        services.AddProductTransformations(o => {
            o.EnableCurrencyNormalizer = true;
        });
        // Same as above, but shorthand
        //services.AddProductTransformations(o => o.EnableCurrencyNormalizer = true);

        return services;
    }
}
