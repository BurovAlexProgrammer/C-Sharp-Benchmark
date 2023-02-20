using BenchmarkDotNet.Running;
using System;

namespace Benchmark {
    internal class Program {
        static void Main(string[] args) {
            //BenchmarkRunner.Run<Field_vs_Property>();
            BenchmarkRunner.Run<Collections_Benchmark>();
            Console.ReadKey();
        }
    }
}
