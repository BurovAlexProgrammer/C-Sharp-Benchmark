using System;
using BenchmarkDotNet.Attributes;
using Main;

namespace Benchmark {
    [MemoryDiagnoser]
    [RankColumn]
    public class Field_vs_Property {
        public TestClass TestClass = new TestClass();
        private int buffer;

        [Benchmark]
        public void EstimateGetField() {
            var t = TestClass.ValueField;
            buffer += t;
        }

        [Benchmark]
        public void EstimateGetProperty()
        {
            var t = TestClass.ValueProp;
            buffer += t;
        }
        
        [Benchmark]
        public void EstimateGetSetField() {
            var t = ++TestClass.ValueField;
            buffer += t;
        }

        [Benchmark]
        public void EstimateGetSetProperty() {
            var t = ++TestClass.ValueProp;
            buffer += t;
        }

        void Log()
        {
            Console.WriteLine(buffer);
        }
    }
}
