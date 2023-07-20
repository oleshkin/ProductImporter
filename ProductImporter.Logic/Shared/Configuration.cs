namespace ProductImporter.Logic.Shared;
public class Configuration
{
    // We will deal with passing in configuration in a better way in a future module
    // For now hardcoding the values is enough to practice with the concepts from this module

    public string SourceCsvPath => @"C:\Users\ealoles\OneDrive - Ericsson\Desktop\CS\c-sharp-10-dependency-injection\02\demos\Module2.BeforeDI\Module2.BeforeDI\product-input.csv";
    public string TargetCsvPath => @"C:\Users\ealoles\OneDrive - Ericsson\Desktop\CS\c-sharp-10-dependency-injection\02\demos\Module2.BeforeDI\Module2.BeforeDI\product-output.csv";
}