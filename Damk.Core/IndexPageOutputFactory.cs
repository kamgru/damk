using System.Text;

namespace Damk.Core;

public class IndexPageOutputFactory
{
    private readonly IPathResolver _pathResolver;

    public IndexPageOutputFactory(IPathResolver pathResolver)
    {
        _pathResolver = pathResolver;
    }

    public IndexPageOutput Create(
        IEnumerable<Driver> articlesDrivers,
        Template template)
    {
        StringBuilder tableOfContentStringBuilder = new();
        foreach (Driver articleDriver in articlesDrivers
                     .Where(x => x.Published.HasValue)
                     .OrderByDescending(x => x.Published))
        {
            tableOfContentStringBuilder.Append(
                template.TableOfContentEntryTemplate.BuildContentString(
                    articleDriver.Title,
                    articleDriver.Lead ?? string.Empty,
                    GetArticleUri(articleDriver),
                    articleDriver.Published!.Value));
        }

        string content = template.Layout.BuildContentString(tableOfContentStringBuilder.ToString());
        string filename = Path.Combine(_pathResolver.GetPagesOutputPath(), "index.html");

        return new IndexPageOutput(content, filename, DateTime.UtcNow);
    }

    private string GetArticleUri(Driver driver)
    {
        string filename = Path.GetFileNameWithoutExtension(driver.SourceFilename.ToLowerInvariant());
        filename = Path.ChangeExtension(filename, "html");
        return $"blog/{filename}";
    }
}
