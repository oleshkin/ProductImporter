using ProductImporter.Model;

namespace ProductImporter.Logic.Transformations;

public interface IProductTransformationContext
{
    Product GetProduct();
    bool IsProductChanged();
    void SetProduct(Product product);
}