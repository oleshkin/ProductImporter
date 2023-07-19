namespace ProductImporter.Logic.Shared;

public interface IImportStatistics
{
    void IncrementImportCount();
    void IncrementTransformationCount();
    void IncrementOutputCount();

    string GetStatistics();
}
