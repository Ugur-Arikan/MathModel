using MathProg.DefaultKeys;

namespace MathProg;

public record Par4(string Key, Data4 Data) : IPar
{
    // method
    public int Dim => 4;
    public Par this[Sca i, Sca j, Sca k, Sca l]
        => new(this, new(new List<Sca>() { i, j, k, l }));


    // ctor
    public Par4(string key, double[][][][] val)
        : this(key, (Data4)val) { }
    public Par4(string key, Func<int, int, int, int, double> getVal)
        : this(key, (Data4)getVal) { }
    public Par4(string key, Func<int, int, int, int, int> getVal)
        : this(key, (Data4)((i, j, k, l) => getVal(i, j, k, l))) { }

    // ctor - default
    public Par4(Data4 data)
        : this(DefaultParKeys.Get(), data)
    {
    }
    public Par4(double[][][][] val)
        : this(DefaultParKeys.Get(), val) { }
    public Par4(Func<int, int, int, int, double> getVal)
        : this(DefaultParKeys.Get(), getVal) { }
    public Par4(Func<int, int, int, int, int> getVal)
        : this(DefaultParKeys.Get(), (Data4)((i, j, k, l) => getVal(i, j, k, l))) { }


    // implicit
    public static implicit operator Par4(Data4 data)
        => new(data);
    public static implicit operator Par4(double[][][][] val)
        => new(val);
    public static implicit operator Par4(Func<int, int, int, int, double> getVal)
        => new(getVal);
}
