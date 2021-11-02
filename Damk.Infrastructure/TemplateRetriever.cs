using Damk.Core;

namespace Damk.Infrastructure;

public class TemplateRetriever : ITemplateRetriever
{
    public Template Get()
    {
        string layout = File.ReadAllText("template/layout.html");
        string toCEntry = File.ReadAllText("template/tocEntry.html");

        return new Template(
            layout,
            toCEntry);
    }
}