# C# Benchmark

### Field vs Property (Get/Set)
<details>
<summary>Code</summary

_
```cs

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

public class TestClass {
    public int ValueField;

    public int ValueProp { get => ValueField; set => ValueField = value;}
}
```

</details>

```
|                 Method |      Mean |     Error |    StdDev |    Median | Rank | Allocated |
|----------------------- |----------:|----------:|----------:|----------:|-----:|----------:|
|       EstimateGetField | 0.8183 ns | 0.0387 ns | 0.0833 ns | 0.8143 ns |    4 |         - |
|    EstimateGetProperty | 0.0776 ns | 0.0425 ns | 0.0756 ns | 0.0512 ns |    2 |         - |
|    EstimateGetSetField | 0.0339 ns | 0.0369 ns | 0.0308 ns | 0.0259 ns |    1 |         - |
| EstimateGetSetProperty | 0.5735 ns | 0.0268 ns | 0.0263 ns | 0.5639 ns |    3 |         - |
```


### Collections
<details>
<summary>Code</summary

_
```cs

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
```

</details>
    
```
|              Method |         Mean |      Error |     StdDev | Rank |   Gen0 | Allocated |
|-------------------- |-------------:|-----------:|-----------:|-----:|-------:|----------:|
| Estimate_Dictionary |    14.467 ns |  0.2713 ns |  0.3015 ns |    3 |      - |         - |
|    Estimate_HashSet | 1,262.601 ns | 24.9249 ns | 28.7035 ns |    5 | 0.0038 |      24 B |
|       Estimate_List |    10.142 ns |  0.1715 ns |  0.1605 ns |    2 |      - |         - |
|      Estimate_Array |     9.617 ns |  0.1951 ns |  0.1825 ns |    1 |      - |         - |
| Estimate_Enumerable |    31.159 ns |  0.2338 ns |  0.2187 ns |    4 |      - |         - |    
```

