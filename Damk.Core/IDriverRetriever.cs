namespace Damk.Core;

public interface IDriverRetriever
{
    IEnumerable<Driver> GetAllPages();
    IEnumerable<Driver> GetAllArticles();
}
