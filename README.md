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
|              Method |      Mean |     Error |    StdDev | Rank | Allocated |
|-------------------- |----------:|----------:|----------:|-----:|----------:|
| Estimate_Dictionary | 14.278 ns | 0.2804 ns | 0.3444 ns |    4 |         - |
|    Estimate_HashSet | 13.848 ns | 0.1783 ns | 0.1668 ns |    3 |         - |
|       Estimate_List |  9.442 ns | 0.1212 ns | 0.1133 ns |    2 |         - |
|      Estimate_Array |  9.002 ns | 0.0535 ns | 0.0475 ns |    1 |         - |
| Estimate_Enumerable | 30.243 ns | 0.2254 ns | 0.1998 ns |    5 |         - |  
```


### Math Operations
<details>
<summary>Code</summary

_
```cs
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
```

</details>
    
```
|              Method |      Mean |     Error |    StdDev | Rank | Allocated |
|-------------------- |----------:|----------:|----------:|-----:|----------:|
|   Estimate_Multiply |  9.657 ns | 0.2104 ns | 0.2735 ns |    1 |         - |
|   Estimate_Division |  9.514 ns | 0.2063 ns | 0.2609 ns |    1 |         - |
|        Estimate_Mod | 15.332 ns | 0.0953 ns | 0.0891 ns |    2 |         - |
| Estimate_Math_Round | 16.406 ns | 0.1322 ns | 0.1236 ns |    3 |         - |
```
