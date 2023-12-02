using System;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Order;

namespace Benchmark
{
    [MemoryDiagnoser]
    [RankColumn]
    [CategoriesColumn]
    [GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByMethod)]
    [Orderer(SummaryOrderPolicy.FastestToSlowest)]
    public class SmallStructVsClass
    {
        private const string Struct = "Struct";
        private const string RefStruct = "Ref Struct";
        private const string Class = "Class";
        private Random _random;
        private static int _targetValue;

        [GlobalSetup]
        public void Setup()
        {
            _random = new Random((int)DateTime.UtcNow.Ticks);
            _targetValue = _random.Next();
        }

        [Benchmark]
        [BenchmarkCategory(Struct)]
        public long Estimate_Small_Struct_Directly()
        {
            var target = new SmallStruct();
            target.value = _targetValue;
            target = SetValue(target);
            return target.value;
        }

        [Benchmark]
        [BenchmarkCategory(Struct)]
        public long Estimate_Small_Struct_By_Ref1()
        {
            var target = new SmallStruct();
            target.value = _targetValue;
            target = SetValueRef1(ref target);
            return target.value;
        }

        [Benchmark]
        [BenchmarkCategory(Struct)]
        public long Estimate_Small_Struct_By_Ref2()
        {
            var target = new SmallStruct();
            target.value = _targetValue;
            target = SetValueRef2(ref target);
            return target.value;
        }

        [Benchmark]
        [BenchmarkCategory(Struct)]
        public long Estimate_Small_Struct_By_Ref3()
        {
            var target = new SmallStruct();
            target.value = _targetValue;
            SetValueRef3(ref target);
            return target.value;
        }

        [Benchmark]
        [BenchmarkCategory(Struct)]
        public long Estimate_Small_Struct_By_In()
        {
            var target = new SmallStruct();
            target.value = _targetValue;
            target = SetValueByIn(in target);
            return target.value;
        }


        [Benchmark]
        [BenchmarkCategory(RefStruct)]
        public long Estimate_Small_RefStruct_Directly()
        {
            var target = new SmallRefStruct();
            target.value = _targetValue;
            target = SetValue(target);
            return target.value;
        }

        [Benchmark]
        [BenchmarkCategory(RefStruct)]
        public long Estimate_Small_RefStruct_By_Ref1()
        {
            var target = new SmallRefStruct();
            target.value = _targetValue;
            var result = SetValueRef1(ref target);
            return result.value;
        }

        [Benchmark]
        [BenchmarkCategory(RefStruct)]
        public long Estimate_Small_RefStruct_By_Ref2()
        {
            var target = new SmallRefStruct();
            target.value = _targetValue;
            target = SetValueRef2(ref target);
            return target.value;
        }

        [Benchmark]
        [BenchmarkCategory(RefStruct)]
        public long Estimate_Small_RefStruct_By_Ref3()
        {
            var target = new SmallRefStruct();
            target.value = _targetValue;
            SetValueRef3(ref target);
            return target.value;
        }

        [Benchmark]
        [BenchmarkCategory(RefStruct)]
        public long Estimate_Small_RefStruct_By_In1()
        {
            var target = new SmallRefStruct();
            target.value = _targetValue;
            SmallRefStruct result = SetValueByIn1(in target);
            return result.value;
        }


        [Benchmark]
        [BenchmarkCategory(Class)]
        public long Estimate_Small_Class()
        {
            var target = new SmallClass();
            target.value = _targetValue;
            target = SetValue(target);
            return target.value;
        }


        private static SmallClass SetValue(SmallClass input)
        {
            input.value *= 2;

            return input;
        }

        private static SmallStruct SetValue(SmallStruct input)
        {
            input.value *= 2;

            return input;
        }

        private static SmallStruct SetValueRef1(ref SmallStruct input)
        {
            input.value *= 2;

            return input;
        }

        private static ref SmallStruct SetValueRef2(ref SmallStruct input)
        {
            input.value *= 2;

            return ref input;
        }

        private static void SetValueRef3(ref SmallStruct input)
        {
            input.value *= 2;
        }

        private static SmallStruct SetValueByIn(in SmallStruct input)
        {
            var temp = input;
            temp.value = input.value * 2;
            return temp;
        }

        private static SmallRefStruct SetValue(SmallRefStruct input)
        {
            input.value *= 2;

            return input;
        }

        private static SmallRefStruct SetValueRef1(ref SmallRefStruct input)
        {
            input.value *= 2;

            return input;
        }

        private static ref SmallRefStruct SetValueRef2(ref SmallRefStruct input)
        {
            input.value *= 2;

            return ref input;
        }

        private static void SetValueRef3(ref SmallRefStruct input)
        {
            input.value *= 2;
        }

        private static SmallRefStruct SetValueByIn1(in SmallRefStruct input)
        {
            var temp = input;
            temp.value = input.value * 2;
            return temp;
        }

        private struct SmallStruct
        {
            public double value0;
            public long value;
        }

        private ref struct SmallRefStruct
        {
            public double value0;
            public long value;
        }

        private sealed class SmallClass
        {
            public double value0;
            public long value;
        }
    }
}