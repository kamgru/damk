namespace Damk.Core;

public class TableOfContentEntryTemplate
{
    private readonly string _tableOfContentEntryTemplate;

    public TableOfContentEntryTemplate(
        string tableOfContentEntryTemplate) =>
        _tableOfContentEntryTemplate = tableOfContentEntryTemplate;

    public string BuildContentString(
        string title,
        string lead,
        string slug,
        DateTime published) =>
        _tableOfContentEntryTemplate
            .Replace("{{title}}", title)
            .Replace("{{lead}}", lead)
            .Replace("{{slug}}", slug)
            .Replace("{{published}}", published.ToShortDateString());
}