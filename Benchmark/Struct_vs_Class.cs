using System;
using BenchmarkDotNet.Attributes;

namespace Benchmark
{
    [MemoryDiagnoser(true)]
    [RankColumn]
    public class Struct_vs_Class
    {
        [Benchmark]
        public long Estimate_Struct_Directly()
        {
            var target = new SomeStruct();
            target.val1 = 1;
            target = SetStructResult(target);
            return target.val1;
        }

        [Benchmark]
        public long Estimate_Struct_By_Ref()
        {
            var target = new SomeStruct();
            target.val1 = 1;
            SetStructResultByRef(ref target);
            return target.val1;
        }

        [Benchmark]
        public long Estimate_Class()
        {
            var target = new SomeClass();
            target.val1 = 1;
            target = SetClassResult(target);
            return target.val1;
        }

        private SomeStruct SetStructResult(SomeStruct input)
        {
            input.val1 *= 2;

            return input;
        }

        private SomeClass SetClassResult(SomeClass input)
        {
            input.val1 *= 2;

            return input;
        }

        private void SetStructResultByRef(ref SomeStruct input)
        {
            input.val1 *= 2;
        }

        public struct SomeStruct
        {
            public long val1;
            public long val2;
            public long val3;
            public long val4;
            public long val5;
            public long val6;
            public long val7;
            public long val8;
            public long val9;
            public long val10;
            public long val11;
            public long val12;
            public long val13;
            public long val14;
            public long val15;
            public long val16;
            public long val18;
            public long val19;
            public long val20;
            public long val21;
            public long val22;
            public long val23;
            public long val24;
            public long val25;
            public long val26;
            public long val27;
            public long val28;
            public long val29;
            public long val30;
        }

        private class SomeClass
        {
            public long val1;
            public long val2;
            public long val3;
            public long val4;
            public long val5;
            public long val6;
            public long val7;
            public long val8;
            public long val9;
            public long val10;
            public long val11;
            public long val12;
            public long val13;
            public long val14;
            public long val15;
            public long val16;
            public long val18;
            public long val19;
            public long val20;
            public long val21;
            public long val22;
            public long val23;
            public long val24;
            public long val25;
            public long val26;
            public long val27;
            public long val28;
            public long val29;
            public long val30;
        }
    }
}