namespace ProductImporter.Logic.Transformations.Util;

public class ReferenceGenerator : IReferenceGenerator
{
    private readonly IDateTimeProvider _dateTimeProvider;
    private readonly IProductCounter _productCounter;

    public ReferenceGenerator(IDateTimeProvider dateTimeProvider, IProductCounter productCounter)
    {
        _dateTimeProvider = dateTimeProvider;
        _productCounter = productCounter;
    }
    public string GetReference()
    {
        _productCounter.Increment();
        var dateTime = _dateTimeProvider.GetUtcDateTime();

        var reference = $"{dateTime:yyyy-MM-ddTHH:mm:ss.FFF}-{_productCounter.Get():D4}";

        return reference;
    }
}
