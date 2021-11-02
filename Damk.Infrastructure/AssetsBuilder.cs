using Damk.Core;
using Kaskada.Minify;
using Kaskada.Minify.Extensions;

namespace Damk.Infrastructure;

public class AssetsBuilder : IAssetsBuilder
{
    private readonly IPathResolver _pathResolver;

    public AssetsBuilder(IPathResolver pathResolver)
    {
        _pathResolver = pathResolver;
    }

    public void BuildStyles()
    {
        foreach (string inputFilename in Directory.GetFiles(_pathResolver.GetStylesSourcePath()))
        {
            string outputFilename = Path.Combine(
                _pathResolver.GetStylesOutputPath(),
                Path.GetFileName(inputFilename));

            MinifyCss(
                inputFilename,
                outputFilename);
        }
    }

    private void MinifyCss(
        string inputFilename,
        string outputFilename) =>
        Minifier.FromFile(inputFilename)
            .ToFile(outputFilename);
}
