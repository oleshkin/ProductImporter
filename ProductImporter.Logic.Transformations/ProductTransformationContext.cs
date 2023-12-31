﻿using ProductImporter.Model;

namespace ProductImporter.Logic.Transformations;

public class ProductTransformationContext : IProductTransformationContext
{
    private Product? _product;
    private Product? _initialProduct;

    public void SetProduct(Product product)
    {
        _product = product;

        if (_initialProduct == null)
        {
            _initialProduct = product;
        }
    }
    public Product GetProduct()
    {
        if (_product == null)
        {
            throw new InvalidOperationException("Cant get the product before it is set");
        }

        return _product;
    }
    public bool IsProductChanged()
    {
        if (_product == null || _initialProduct == null)
        {
            return false;
        }

        return ! _initialProduct.Equals(_product);
    }
}
