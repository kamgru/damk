namespace Damk.Core;

public interface IMarkdownConverter
{
    string ToHtml(string source);
}