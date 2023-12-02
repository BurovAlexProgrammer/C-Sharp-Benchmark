using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Exporters;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Loggers;
using BenchmarkDotNet.Toolchains.CsProj;
using BenchmarkDotNet.Toolchains.Mono;

namespace Runner
{
    public static class Configs
    {
        public static readonly IConfig ThreeFrameworks = ConstructThreeFrameworks();

        private static IConfig ConstructThreeFrameworks()
        {
            return new ManualConfig()
               .AddJob(Job.Default
                       .WithToolchain(CsProjClassicNetToolchain.Net481)
                       .WithId("Net 4.8.1"))
               .AddJob(Job.Default
                       .WithToolchain(CsProjCoreToolchain.NetCoreApp60)
                       .WithId("Net 6"))
               .AddJob(Job.Default
                       .WithToolchain(MonoToolchain.Mono60)
                       .WithId("Mono 6"))
               .AddLogger(ConsoleLogger.Unicode)
               .AddExporter(MarkdownExporter.GitHub)
               .AddExporter(HtmlExporter.Default);
        }
    }
}