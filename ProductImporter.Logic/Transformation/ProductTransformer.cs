using Microsoft.Extensions.DependencyInjection;
using ProductImporter.Model;
using ProductImporter.Logic.Shared;
using ProductImporter.Logic.Transformations;
using ProductImporter.Logic.Transformations.Util;

namespace ProductImporter.Logic.Transformation;

public class ProductTransformer : IProductTransformer
{
    private readonly IServiceScopeFactory _serviceScopeFactory;
    private readonly IImportStatistics _importStatistics;

    public ProductTransformer(IServiceScopeFactory serviceScopeFactory, IImportStatistics importStatistics)
    {
        _serviceScopeFactory = serviceScopeFactory;
        _importStatistics = importStatistics;
    }

    public Product ApplyTransformations(Product product)
    {
        using var scope = _serviceScopeFactory.CreateScope();

        var transformationContext = scope.ServiceProvider.GetRequiredService<IProductTransformationContext>();
        transformationContext.SetProduct(product);

        var nameCapitalizer = scope.ServiceProvider.GetRequiredService<INameDecapitaliser>();
        var currencyNormalizer = scope.ServiceProvider.GetRequiredService<ICurrencyNormalizer>();
        var referenceAdder = scope.ServiceProvider.GetRequiredService<IReferenceAdder>();

        nameCapitalizer.Execute();
        currencyNormalizer.Execute();
        referenceAdder.Execute();

        Thread.Sleep(2000);
        
        if (transformationContext.IsProductChanged())
        {
            _importStatistics.IncrementTransformationCount();
        }

        var transformedProduct = transformationContext.GetProduct();
        return transformedProduct;
    }
}
