using Damk.App;
using Microsoft.Extensions.DependencyInjection;

namespace Damk.Cli;

internal static class Program
{
    private static void Main()
    {
        BlogBuilder blogBuilder = new ServiceCollection()
            .AddApp()
            .BuildServiceProvider()
            .GetRequiredService<BlogBuilder>();

        blogBuilder.Build();
    }
}
