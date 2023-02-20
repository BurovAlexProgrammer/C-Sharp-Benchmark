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

![image](https://user-images.githubusercontent.com/7298288/220064034-a5b7218b-5cf1-4663-a07b-e14f1f805331.png)
