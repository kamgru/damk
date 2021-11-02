using System.ComponentModel;
using Damk.Core;

namespace Damk.Infrastructure;

public class OutputFilenameBuilder : IOutputFilenameBuilder
{
    private readonly IPathResolver _pathResolver;

    public OutputFilenameBuilder(
        IPathResolver pathResolver)
    {
        _pathResolver = pathResolver;
    }

    public string Build(Driver driver) => driver.Kind switch
    {
        DriverKind.Article => BuildForArticle(driver),
        DriverKind.Page => BuildForPage(driver),
        _ => throw new InvalidEnumArgumentException(
            nameof(Driver.Kind),
            (int)driver.Kind,
            typeof(DriverKind))
    };

    private string BuildForArticle(Driver driver)
    {
        string filename = Path.GetFileNameWithoutExtension(driver.SourceFilename.ToLowerInvariant());
        filename = Path.ChangeExtension(filename, "html");

        string outputPath = Path.Combine(_pathResolver.GetArticlesOutputPath(), filename);
        return outputPath;
    }

    private string BuildForPage(Driver driver)
    {
        string filename = Path.GetFileName(driver.Title.ToLowerInvariant());
        filename = Path.ChangeExtension(filename, "html");

        string outputPath = Path.Combine(_pathResolver.GetPagesOutputPath(), filename);
        return outputPath;
    }
}
