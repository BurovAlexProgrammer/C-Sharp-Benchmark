using System;
using System.Diagnostics;
using BenchmarkDotNet.Attributes;

namespace Benchmark
{
    [MemoryDiagnoser]
    [RankColumn]
    public class Operation_Benchmark
    {
        private static float a = 10f, buffer;
        
        private static Random _random = new Random();
        private static Stopwatch _stopwatch = new Stopwatch();
        private static int RandomInt => _random.Next(10);
        
        [Benchmark]
        public void Estimate_Multiply()
        {
            a += RandomInt;
            buffer += a * 0.033333f;
        }

        [Benchmark]
        public void Estimate_Division()
        {
            a += RandomInt;
            buffer += a / 30f;
        }

        [Benchmark]
        public void Estimate_Mod()
        {
            a += RandomInt;
            buffer += a - a % 100;
        }

        [Benchmark]
        public void Estimate_Math_Round()
        {
            a += RandomInt;
            buffer += (float)Math.Round(a, 2);
        }
    }
}