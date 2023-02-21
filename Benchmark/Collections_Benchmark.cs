using System;
using System.Collections.Generic;
using System.Linq;
using BenchmarkDotNet.Attributes;

namespace Benchmark
{
    [MemoryDiagnoser]
    [RankColumn]
    public class Collections_Benchmark
    {
        private static int _collectionCapacity = 1000;
        public static Dictionary<int, int> _dictionary = FillDictionary(_collectionCapacity);
        public static HashSet<int> _hashSet = FillHashSet(_collectionCapacity);
        public static List<int> _list = FillList(_collectionCapacity);
        public static int[] _array = FillArray(_collectionCapacity);
        public static IEnumerable<int> _enumerable = FillArray(_collectionCapacity).AsEnumerable();
        
        private static int Buffer;
        private static Random _random = new Random();
        private static int RandomInt => _random.Next(_collectionCapacity);

        [Benchmark]
        public void Estimate_Dictionary()
        {
            Buffer += _dictionary[RandomInt];
        }

        [Benchmark]
        public void Estimate_HashSet()
        {
            Buffer += _hashSet.Contains(RandomInt) ? 1 : -1;
        }

        [Benchmark]
        public void Estimate_List()
        {
            Buffer += _list[RandomInt];
        }

        [Benchmark]
        public void Estimate_Array()
        {
            Buffer += _array[RandomInt];
        }

        [Benchmark]
        public void Estimate_Enumerable()
        {
            Buffer += _enumerable.ElementAt(RandomInt);
        }

        private static List<int> FillList(int count)
        {
            var list = new List<int>(count);

            for (int i = 0; i < count; i++)
            {
                list.Add(i);
            }

            return list;
        }

        private static Dictionary<int, int> FillDictionary(int count)
        {
            var dictionary = new Dictionary<int, int>(count);

            for (int i = 0; i < count; i++)
            {
                dictionary.Add(i, i);
            }

            return dictionary;
        }

        private static HashSet<int> FillHashSet(int count)
        {
            var hashSet = new HashSet<int>(count);

            for (int i = 0; i < count; i++)
            {
                hashSet.Add(i);
            }

            return hashSet;
        }

        private static int[] FillArray(int count)
        {
            var array = new int[count];

            for (int i = 0; i < count; i++)
            {
                array[i] = count;
            }

            return array;
        }
    }
}