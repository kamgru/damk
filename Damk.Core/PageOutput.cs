namespace Damk.Core;

public class PageOutput
{
    public PageOutput(
        string content,
        string filename,
        DateTime? published)
    {
        Content = content;
        Filename = filename;
        Published = published;
    }

    public string Content { get; }
    public string Filename { get; }
    public DateTime? Published { get; }
}

public class IndexPageOutput : PageOutput
{
    public IndexPageOutput(
        string content,
        string filename,
        DateTime? published)
        : base(
            content,
            filename,
            published)
    {
    }
}
