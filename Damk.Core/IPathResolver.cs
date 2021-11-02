namespace Damk.Core;

public interface IPathResolver
{
    string GetArticlesSourcePath();
    string GetPagesSourcePath();
    string GetArticlesOutputPath();
    string GetPagesOutputPath();
    string GetStylesSourcePath();
    string GetStylesOutputPath();
}