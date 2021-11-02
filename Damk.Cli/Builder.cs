using Damk.Core;
using Damk.Infrastructure;

class Builder
{
    private readonly ITemplateRetriever _templateRetriever = new TemplateRetriever();

    private readonly IDriverRetriever _driverRetriever = new DriverRetriever(
        new PathResolver());

    private readonly IPageWriter _pageWriter = new PageWriter();

    private readonly PageOutputFactory _pageOutputFactory = new(
        new ContentRetriever(),
        new MarkdownConverter(),
        new OutputFilenameBuilder(
            new PathResolver()));

    private readonly IndexPageOutputFactory _indexPageOutputFactory = new(new PathResolver());

    private readonly IAssetsBuilder _assetsBuilder = new AssetsBuilder(
        new PathResolver());
    
    public void Build()
    {
        IEnumerable<Driver> articlesDrivers = _driverRetriever.GetAllArticles();
        IEnumerable<Driver> pageDrivers = _driverRetriever.GetAllPages();


        Directory.CreateDirectory("publish");
        Directory.CreateDirectory("publish/css");
        Directory.CreateDirectory("publish/blog");

        Template template = _templateRetriever.Get();
        foreach (Driver pageDriver in pageDrivers)
        {
            PageOutput pageOutput = _pageOutputFactory.Create(pageDriver, template);
            _pageWriter.Save(pageOutput);
        }

        foreach (Driver articleDriver in articlesDrivers)
        {
            PageOutput pageOutput = _pageOutputFactory.Create(articleDriver, template);
            _pageWriter.Save(pageOutput);
        }

        IndexPageOutput indexPageOutput = _indexPageOutputFactory.Create(articlesDrivers, template);
        _pageWriter.Save(indexPageOutput);

        _assetsBuilder.BuildStyles();
    }
}
