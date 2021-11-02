namespace Damk.Core;

public class Template
{
    public TableOfContentEntryTemplate TableOfContentEntryTemplate { get; }
    public Layout Layout { get; }

    public Template(
        string layout,
        string toCEntry)
    {
        TableOfContentEntryTemplate = new (toCEntry);
        Layout = new (layout);
    }}


