namespace Damk.Core;

public class PageOutputFactory
{
    private readonly IContentRetriever _contentRetriever;
    private readonly IMarkdownConverter _markdownConverter;
    private readonly IOutputFilenameBuilder _outputFilenameBuilder;

    public PageOutputFactory(
        IContentRetriever contentRetriever,
        IMarkdownConverter markdownConverter,
        IOutputFilenameBuilder outputFilenameBuilder)
    {
        _contentRetriever = contentRetriever;
        _markdownConverter = markdownConverter;
        _outputFilenameBuilder = outputFilenameBuilder;
    }

    public PageOutput Create(
        Driver driver,
        Template template)
    {
        string source = _contentRetriever.Get(driver.SourceFilename);
        string content = template.Layout.BuildContentString(_markdownConverter.ToHtml(source));
        string outputFilename = _outputFilenameBuilder.Build(driver);

        return new PageOutput(content, outputFilename, driver.Published);
    }
}
