using Damk.Core;
using Damk.Infrastructure;

namespace Damk.App;

public class BlogBuilder
{
    private readonly IAssetsBuilder _assetsBuilder;
    private readonly IDriverRetriever _driverRetriever;
    private readonly IndexPageOutputFactory _indexPageOutputFactory;
    private readonly PageOutputFactory _pageOutputFactory;
    private readonly IPageWriter _pageWriter;
    private readonly ITemplateRetriever _templateRetriever;

    public BlogBuilder(
        IAssetsBuilder assetsBuilder,
        IDriverRetriever driverRetriever,
        IndexPageOutputFactory indexPageOutputFactory,
        PageOutputFactory pageOutputFactory,
        IPageWriter pageWriter,
        ITemplateRetriever templateRetriever)
    {
        _assetsBuilder = assetsBuilder;
        _driverRetriever = driverRetriever;
        _indexPageOutputFactory = indexPageOutputFactory;
        _pageOutputFactory = pageOutputFactory;
        _pageWriter = pageWriter;
        _templateRetriever = templateRetriever;
    }

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
