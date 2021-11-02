using Damk.Core;

namespace Damk.Infrastructure;

public class PageWriter : IPageWriter
{
    public void Save(PageOutput pageOutput) =>
        File.WriteAllText(pageOutput.Filename, pageOutput.Content);
}
