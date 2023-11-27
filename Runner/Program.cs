using System;
using Benchmark;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Filters;
using BenchmarkDotNet.Loggers;
using BenchmarkDotNet.Running;

namespace Runner
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // var config = new ManualConfig()
            //     // .WithOptions(ConfigOptions.DisableOptimizationsValidator)
            //     .AddValidator(JitOptimizationsValidator.DontFailOnError)
            //     .AddLogger(ConsoleLogger.Default)
            //     .AddColumnProvider(DefaultColumnProviders.Instance);


            // BenchmarkRunner.Run<Field_vs_Property>();
            // BenchmarkRunner.Run<Collections_Benchmark>();
            // BenchmarkRunner.Run<Operation_Benchmark>();
            // BenchmarkSwitcher.FromTypes(new[] {typeof(SmallStructVsClass), typeof(BigStructVsClass)});

            BenchmarkRunner.Run<SmallStructVsClass>();
            Console.ReadKey();
        }
    }
}