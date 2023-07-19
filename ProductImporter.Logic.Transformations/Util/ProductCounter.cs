namespace ProductImporter.Logic.Transformations.Util;

public class ProductCounter : IProductCounter
{
    private int _count = 0;

    public int Get() => _count;

    public void Increment() => _count++;

    public override string? ToString()
    {
        return _count.ToString();
    }
}