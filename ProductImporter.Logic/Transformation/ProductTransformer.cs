using Microsoft.Extensions.DependencyInjection;
using ProductImporter.Model;
using ProductImporter.Logic.Shared;
using ProductImporter.Logic.Transformations;

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

        var productTransformations = scope.ServiceProvider.GetRequiredService<IEnumerable<IProductTransformations>>();


        Thread.Sleep(2000);

        foreach (var productTransformation in productTransformations)
        {
            productTransformation.Execute();
        }

        
        if (transformationContext.IsProductChanged())
        {
            _importStatistics.IncrementTransformationCount();
        }

        var transformedProduct = transformationContext.GetProduct();
        return transformedProduct;
    }
}
