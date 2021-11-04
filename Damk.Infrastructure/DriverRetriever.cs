using Damk.Core;

namespace Damk.Infrastructure;

public class DriverRetriever : IDriverRetriever
{
    private readonly IPathResolver _pathResolver;

    public DriverRetriever(
        IPathResolver pathResolver)
    {
        _pathResolver = pathResolver;
    }

    public IEnumerable<Driver> GetAllArticles()
    {
        foreach (string filename in Directory.GetFiles(_pathResolver.GetArticlesSourcePath()))
        {
            yield return Get(filename, DriverKind.Article);
        }
    }

    public IEnumerable<Driver> GetAllPages()
    {
        foreach (string filename in Directory.GetFiles(_pathResolver.GetPagesSourcePath()))
        {
            yield return Get(filename, DriverKind.Page);
        }
    }

    public Driver Get(
        string filename,
        DriverKind kind)
    {
        IDictionary<string, string> driverSource = ReadDriverSource(filename);
        return new Driver(driverSource, filename, kind);
    }

    private IDictionary<string, string> ReadDriverSource(
        string filename)
    {
        IEnumerable<string> lines = File.ReadLines(filename);
        if (lines.First() != "---")
        {
            throw new InvalidOperationException($"file driver missing in {filename}");
        }

        Dictionary<string, string> result = new();
        foreach (string line in lines.Skip(1).TakeWhile(x => x != "---"))
        {
            string[] keyValueArray = line.Split(':');
            if (keyValueArray.Length != 2)
            {
                throw new InvalidOperationException($"Error parsing {line} in {filename}");
            }

            result[keyValueArray[0]] = keyValueArray[1].Trim()[1..^1];
        }

        return result;
    }
}
