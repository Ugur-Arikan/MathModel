using MathProg.DefaultKeys;

namespace MathProg;

public record Par8(string Key, Data8 Data) : IPar
{
    // method
    public int Dim => 8;
    public Par this[Sca i, Sca j, Sca k, Sca l, Sca m, Sca n, Sca o, Sca p]
        => new(this, new(new List<Sca>() { i, j, k, l, m, n, o, p }));


    // ctor
    public Par8(string key, double[][][][][][][][] val)
        : this(key, (Data8)val) { }
    public Par8(string key, Func<int, int, int, int, int, int, int, int, double> getVal)
        : this(key, (Data8)getVal) { }
    public Par8(string key, Func<int, int, int, int, int, int, int, int, int> getVal)
        : this(key, (Data8)((i, j, k, l, m, n, o, p) => getVal(i, j, k, l, m, n, o, p))) { }

    // ctor - default
    public Par8(Data8 data)
        : this(DefaultParKeys.Get(), data)
    {
    }
    public Par8(double[][][][][][][][] val)
        : this(DefaultParKeys.Get(), val) { }
    public Par8(Func<int, int, int, int, int, int, int, int, double> getVal)
        : this(DefaultParKeys.Get(), getVal) { }
    public Par8(Func<int, int, int, int, int, int, int, int, int> getVal)
        : this(DefaultParKeys.Get(), (Data8)((i, j, k, l, m, n, o, p) => getVal(i, j, k, l, m, n, o, p))) { }


    // implicit
    public static implicit operator Par8(Data8 data)
        => new(data);
    public static implicit operator Par8(double[][][][][][][][] val)
        => new(val);
    public static implicit operator Par8(Func<int, int, int, int, int, int, int, int, double> getVal)
        => new(getVal);
}
