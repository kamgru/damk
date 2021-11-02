using Damk.Core;
using Markdig;

namespace Damk.Infrastructure;

public class MarkdownConverter : IMarkdownConverter
{
    private readonly MarkdownPipeline _markdownPipeline;

    public MarkdownConverter() =>
        _markdownPipeline = new MarkdownPipelineBuilder()
            .Build();

    public string ToHtml(string source) =>
        Markdown.ToHtml(source, _markdownPipeline);
}
