using Damk.Core;
using Damk.Infrastructure;
using Microsoft.Extensions.DependencyInjection;

namespace Damk.App;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApp(this IServiceCollection services)
    {
        services.AddTransient<BlogBuilder>();
        services.AddTransient<IndexPageOutputFactory>();
        services.AddTransient<PageOutputFactory>();
        services.AddTransient<IAssetsBuilder, AssetsBuilder>();
        services.AddTransient<IDriverRetriever, DriverRetriever>();
        services.AddTransient<IContentRetriever, ContentRetriever>();
        services.AddTransient<IMarkdownConverter, MarkdownConverter>();
        services.AddTransient<IOutputFilenameBuilder, OutputFilenameBuilder>();
        services.AddTransient<IPageWriter, PageWriter>();
        services.AddTransient<IPathResolver, PathResolver>();
        services.AddTransient<ITemplateRetriever, TemplateRetriever>();

        return services;
    }
}
