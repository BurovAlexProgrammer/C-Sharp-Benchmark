using System;
using BenchmarkDotNet.Running;

namespace Benchmark {
    internal class Program {
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
            BenchmarkRunner.Run<Struct_vs_Class>();
            Console.ReadKey();
        }
    }
}
