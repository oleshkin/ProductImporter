using Moq;
using ProductImporter.Logic.Shared;
using ProductImporter.Logic.Source;
using ProductImporter.Logic.Target;
using ProductImporter.Logic.Transformation;
using ProductImporter.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductImporter.Logic.Test;

public class ProductImporterTest
{
    [Theory]
    [InlineData(0)]
    [InlineData(1)]
    [InlineData(4)]
    public async Task WhenItReadsNProductsFromSource_ThenItWritesNProductsToTarget(int numberOfProducts)
    {
        var productSource = new Mock<IProductSource>();
        var productTransformer = new Mock<IProductTransformer>();
        var productTarget = new Mock<IProductTarget>();
        var importStatistics = new Mock<IImportStatistics>();

        var subjectUnderTest = new ProductImporter(productSource.Object, productTransformer.Object, 
            productTarget.Object, importStatistics.Object);

        var productCounter = 0;

        productSource
            .Setup(x => x.hasMoreProducts())
            .Callback(() => productCounter++)
            .Returns(() => productCounter <= numberOfProducts);

        await subjectUnderTest.RunAsync();

        productTarget
            .Verify(x => x.AddProduct(It.IsAny<Product>()), Times.Exactly(numberOfProducts));
    }
}
