using Damk.Core;

namespace Damk.Infrastructure;

public class ContentRetriever : IContentRetriever
{
    public string Get(string filename)
    {
        string source = File.ReadAllText(filename);
        string[] parts = source.Split("---", StringSplitOptions.RemoveEmptyEntries);

        if (parts.Length != 2)
        {
            throw new InvalidOperationException($"Invalid content format, driver seems missing in {filename}");
        }

        return parts[1];
    }
}
