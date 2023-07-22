using ProductImporter.Model;
using ProductImporter.Logic.Transformations.Util;

namespace ProductImporter.Logic.Transformations;

public class ReferenceAdder : IProductTransformations
{
    private readonly IProductTransformationContext _productTransformationContext;
    private readonly IReferenceGenerator _referenceGenerator;

    public ReferenceAdder(IProductTransformationContext context,IReferenceGenerator referenceGenerator)
    {
        _productTransformationContext = context;
        _referenceGenerator = referenceGenerator;
    }
    public void Execute()
    {
        var product = _productTransformationContext.GetProduct();

        var reference = _referenceGenerator.GetReference();

        var newProduct = new Product(product.Id, product.Name, product.Price, product.Stock, reference);

        _productTransformationContext.SetProduct(newProduct);    



    }
}
