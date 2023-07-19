using ProductImporter.Model;
using System.Globalization;

namespace ProductImporter.Logic.Source;

public class PriceParser : IPriceParser
{
    public Money Parse(string price)
    {
        var parts = price.Split(' ');

        var currency = parts[0];
        decimal amount = decimal.Parse(parts[1], NumberStyles.Number, CultureInfo.InvariantCulture);
        

        return new Money(currency, amount);
    }
}