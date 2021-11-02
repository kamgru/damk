using Damk.Core;

namespace Damk.Infrastructure;

public class PathResolver : IPathResolver
{
    public string GetArticlesSourcePath() =>
        "content/articles";

    public string GetPagesSourcePath() =>
        "content/pages";

    public string GetStylesSourcePath() =>
        "template/css";

    public string GetStylesOutputPath() =>
        "publish/css";

    public string GetArticlesOutputPath() =>
        "publish/blog";

    public string GetPagesOutputPath() =>
        "publish";
}
