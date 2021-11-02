namespace Damk.Core;

public class Layout
{
    private readonly string _layout;

    public Layout(
        string layout) =>
        _layout = layout;

    public string BuildContentString(
        string content) =>
        _layout.Replace(
            "{{MAIN_CONTENT}}",
            content);
}
