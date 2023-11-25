using System;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Environments;
using BenchmarkDotNet.Jobs;
using Perfolizer.Horology;

namespace Benchmark
{
    [RankColumn]
    [MemoryDiagnoser(true)]
    [Config(typeof(BigStructVsClass.Config))]
    public class BigStructVsClass
    {
        private class Config : ManualConfig
        {
            public Config()
            {
                AddJob(Job.Default
                       .WithPlatform(Platform.X64)
                       .WithRuntime(ClrRuntime.Net48)
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
        public long Estimate_Big_Struct_Directly()
        {
            var target = new BigStruct();
            target.value = _targetValue;
            target = SetValue(target);
            return target.value;
        }

        [Benchmark]
        public long Estimate_Big_Struct_By_Ref1()
        {
            var target = new BigStruct();
            target.value = _targetValue;
            target = SetValueRef1(ref target);
            return target.value;
        }

        [Benchmark]
        public long Estimate_Big_Struct_By_Ref2()
        {
            var target = new BigStruct();
            target.value = _targetValue;
            target = SetValueRef2(ref target);
            return target.value;
        }

        [Benchmark]
        public long Estimate_Big_Struct_By_Ref3()
        {
            var target = new BigStruct();
            target.value = _targetValue;
            SetValueRef3(ref target);
            return target.value;
        }

        [Benchmark]
        public long Estimate_Big_Struct_By_In()
        {
            var target = new BigStruct();
            target.value = _targetValue;
            target = SetValueByIn1(in target);
            return target.value;
        }

        
        
        [Benchmark]
        public long Estimate_Big_RefStruct_Directly()
        {
            var target = new BigRefStruct();
            target.value = _targetValue;
            target = SetValue(target);
            return target.value;
        }

        [Benchmark]
        public long Estimate_Big_RefStruct_By_Ref1()
        {
            var target = new BigRefStruct();
            target.value = _targetValue;
            var result = SetValueRef1(ref target);
            return result.value;
        }

        [Benchmark]
        public long Estimate_Big_RefStruct_By_Ref2()
        {
            var target = new BigRefStruct();
            target.value = _targetValue;
            ref BigRefStruct t = ref SetValueRef2(ref target);
            return t.value;
        }

        [Benchmark]
        public long Estimate_Big_RefStruct_By_Ref3()
        {
            var target = new BigRefStruct();
            target.value = _targetValue;
            SetValueRef3(ref target);
            return target.value;
        }

        [Benchmark]
        public long Estimate_Big_RefStruct_By_In1()
        {
            var target = new BigRefStruct();
            target.value = _targetValue;
            var result = SetValueByIn1(in target);
            return result.value;
        }

        [Benchmark]
        public long Estimate_Big_RefStruct_By_In2()
        {
            var target = new BigRefStruct();
            target.value = _targetValue;
            var result = SetValueByIn2(in target);
            return result.value;
        }
        
        
        
        
        [Benchmark]
        public long Estimate_Big_Class()
        {
            var target = new BigClass();
            target.value = _targetValue;
            target = SetValue(target);
            return target.value;
        }

        private BigClass SetValue(BigClass input)
        {
            input.value *= 2;

            return input;
        }

        private BigStruct SetValue(BigStruct input)
        {
            input.value *= 2;

            return input;
        }

        private BigStruct SetValueRef1(ref BigStruct input)
        {
            input.value *= 2;

            return input;
        }

        private ref BigStruct SetValueRef2(ref BigStruct input)
        {
            input.value *= 2;

            return ref input;
        }
        private void SetValueRef3(ref BigStruct input)
        {
            input.value *= 2;
        }

        private BigStruct SetValueByIn1(in BigStruct input)
        {
            return input with {value = input.value * 2};
        }

        private BigRefStruct SetValue(BigRefStruct input)
        {
            input.value *= 2;

            return input;
        }

        private BigRefStruct SetValueRef1(ref BigRefStruct input)
        {
            input.value *= 2;

            return input;
        }

        private ref BigRefStruct SetValueRef2(ref BigRefStruct input)
        {
            input.value *= 2;

            return ref input;
        }

        private void SetValueRef3(ref BigRefStruct input)
        {
            input.value *= 2;
        }

        private BigRefStruct SetValueByIn1(in BigRefStruct input)
        {
            return input with {value = input.value * 2};
        }

        private BigRefStruct SetValueByIn2(in BigRefStruct input)
        {
            var temp = input;
            temp.value *= 2;
            return temp;
        }

        private struct BigStruct
        {
            public double value0;
            public long value;
            public long value2;
            public long value3;
            public long value4;
            public long value5;
            public long value6;
            public long value7;
            public long value8;
            public long value9;
            public long value10;
            public long value11;
            public long value12;
            public long value13;
            public long value14;
            public long value15;
            public long value16;
            public long value18;
            public long value19;
            public long value20;
            public long value21;
            public long value22;
            public long value23;
            public long value24;
            public long value25;
            public long value26;
            public long value27;
            public long value28;
            public long value29;
            public long value30;
        }

        private ref struct BigRefStruct
        {
            public double value0;
            public long value;
            public long value2;
            public long value3;
            public long value4;
            public long value5;
            public long value6;
            public long value7;
            public long value8;
            public long value9;
            public long value10;
            public long value11;
            public long value12;
            public long value13;
            public long value14;
            public long value15;
            public long value16;
            public long value18;
            public long value19;
            public long value20;
            public long value21;
            public long value22;
            public long value23;
            public long value24;
            public long value25;
            public long value26;
            public long value27;
            public long value28;
            public long value29;
            public long value30;
        }

        private sealed class BigClass
        {
            public double value0;
            public long value;
            public long value2;
            public long value3;
            public long value4;
            public long value5;
            public long value6;
            public long value7;
            public long value8;
            public long value9;
            public long value10;
            public long value11;
            public long value12;
            public long value13;
            public long value14;
            public long value15;
            public long value16;
            public long value18;
            public long value19;
            public long value20;
            public long value21;
            public long value22;
            public long value23;
            public long value24;
            public long value25;
            public long value26;
            public long value27;
            public long value28;
            public long value29;
            public long value30;
        }
    }
}