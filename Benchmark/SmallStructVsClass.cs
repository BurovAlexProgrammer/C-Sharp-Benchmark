using System;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Environments;
using BenchmarkDotNet.Jobs;

namespace Benchmark
{
    [RankColumn]
    [MemoryDiagnoser(true)]
    [Config(typeof(SmallStructVsClass.Config))]
    public class SmallStructVsClass
    {
        private class Config : ManualConfig
        {
            public Config()
            {
                AddJob(Job.Default
                       .WithPlatform(Platform.X64)
                       .WithRuntime(ClrRuntime.Net481)
                       .WithId("Net 4.8.1"));
                AddJob(Job.Default
                       .WithPlatform(Platform.X64)
                       .WithRuntime(CoreRuntime.Core60)
                       .WithId("Net 6"));
                AddJob(Job.Default
                       .WithPlatform(Platform.X86)
                       .WithRuntime(MonoRuntime.Default)
                       .WithId("Mono"));
            }
        }

        private Random _random;
        private int _targetValue;

        [GlobalSetup]
        public void Setup()
        {
            _random = new Random((int)DateTime.UtcNow.Ticks);
            _targetValue = _random.Next();
        }

        [Benchmark]
        public long Estimate_Small_Struct_Directly()
        {
            var target = new SmallStruct();
            target.value = _targetValue;
            target = SetValue(target);
            return target.value;
        }

        [Benchmark]
        public long Estimate_Small_Struct_By_Ref1()
        {
            var target = new SmallStruct();
            target.value = _targetValue;
            target = SetValueRef1(ref target);
            return target.value;
        }

        [Benchmark]
        public long Estimate_Small_Struct_By_Ref2()
        {
            var target = new SmallStruct();
            target.value = _targetValue;
            target = SetValueRef2(ref target);
            return target.value;
        }

        [Benchmark]
        public long Estimate_Small_Struct_By_Ref3()
        {
            var target = new SmallStruct();
            target.value = _targetValue;
            SetValueRef3(ref target);
            return target.value;
        }

        [Benchmark]
        public long Estimate_Small_Struct_By_In()
        {
            var target = new SmallStruct();
            target.value = _targetValue;
            target = SetValueByIn(in target);
            return target.value;
        }
        
        
        
        [Benchmark]
        public long Estimate_Small_RefStruct_Directly()
        {
            var target = new SmallRefStruct();
            target.value = _targetValue;
            target = SetValue(target);
            return target.value;
        }

        [Benchmark]
        public long Estimate_Small_RefStruct_By_Ref1()
        {
            var target = new SmallRefStruct();
            target.value = _targetValue;
            var result = SetValueRef1(ref target);
            return result.value;
        }

        [Benchmark]
        public long Estimate_Small_RefStruct_By_Ref2()
        {
            var target = new SmallRefStruct();
            target.value = _targetValue;
            target = SetValueRef2(ref target);
            return target.value;
        }

        [Benchmark]
        public long Estimate_Small_RefStruct_By_Ref3()
        {
            var target = new SmallRefStruct();
            target.value = _targetValue;
            SetValueRef3(ref target);
            return target.value;
        }

        [Benchmark]
        public long Estimate_Small_RefStruct_By_In1()
        {
            var target = new SmallRefStruct();
            target.value = _targetValue;
            SmallRefStruct result = SetValueByIn1(in target);
            return result.value;
        }

        [Benchmark]
        public long Estimate_Small_RefStruct_By_In2()
        {
            var target = new SmallRefStruct();
            target.value = _targetValue;
            SmallRefStruct result = SetValueByIn2(in target);
            return result.value;
        }
        
        
        
        [Benchmark]
        public long Estimate_Small_Class()
        {
            var target = new SmallClass();
            target.value = _targetValue;
            target = SetValue(target);
            return target.value;
        }

        private SmallClass SetValue(SmallClass input)
        {
            input.value *= 2;

            return input;
        }

        private SmallStruct SetValue(SmallStruct input)
        {
            input.value *= 2;

            return input;
        }

        private SmallStruct SetValueRef1(ref SmallStruct input)
        {
            input.value *= 2;

            return input;
        }

        private ref SmallStruct SetValueRef2(ref SmallStruct input)
        {
            input.value *= 2;

            return ref input;
        }
        private void SetValueRef3(ref SmallStruct input)
        {
            input.value *= 2;
        }

        private SmallStruct SetValueByIn(in SmallStruct input)
        {
            return input with {value = input.value * 2};
        }

        private SmallRefStruct SetValue(SmallRefStruct input)
        {
            input.value *= 2;

            return input;
        }

        private SmallRefStruct SetValueRef1(ref SmallRefStruct input)
        {
            input.value *= 2;

            return input;
        }

        private ref SmallRefStruct SetValueRef2(ref SmallRefStruct input)
        {
            input.value *= 2;

            return ref input;
        }

        private void SetValueRef3(ref SmallRefStruct input)
        {
            input.value *= 2;
        }

        private SmallRefStruct SetValueByIn1(in SmallRefStruct input)
        {
            return input with {value = input.value * 2};
        }
        
        private SmallRefStruct SetValueByIn2(in SmallRefStruct input)
        {
            var temp = input;
            temp.value *= 2;
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