namespace Damk.Core;

public class Driver
{
    public string Title { get; }
    public string? Lead { get; }
    public DateTime? Published { get; }
    public string SourceFilename { get; }
    public DriverKind Kind { get; }

    public Driver(
        IDictionary<string, string> source,
        string sourceFilename,
        DriverKind driverKind)
    {
        if (!source.TryGetValue("title", out string? title))
        {
            throw new ArgumentException($"Missing title in driver source file {sourceFilename}");
        }

        Title = title;
        Lead = source.TryGetValue("lead", out string? lead)
            ? lead
            : null;
        string? publishedDateString = source.TryGetValue("published", out string? publishedDate)
            ? publishedDate
            : null;

        if (publishedDateString is not null)
        {
            Published = DateTime.TryParse(publishedDateString, out DateTime published)
                ? published
                : null;
        }

        SourceFilename = sourceFilename;
        Kind = driverKind;
    }
}
