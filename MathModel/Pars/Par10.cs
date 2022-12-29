using MathProg.DefaultKeys;

namespace MathProg;

public record Par10(string Key, Data10 Data) : IPar
{
    // method
    public int Dim => 10;
    public Par this[Sca i, Sca j, Sca k, Sca l, Sca m, Sca n, Sca o, Sca p, Sca q, Sca r]
        => new(this, new(new List<Sca>() { i, j, k, l, m, n, o, p, q, r }));


    // ctor
    public Par10(string key, double[][][][][][][][][][] val)
        : this(key, (Data10)val) { }
    public Par10(string key, Func<int, int, int, int, int, int, int, int, int, int, double> getVal)
        : this(key, (Data10)getVal) { }
    public Par10(string key, Func<int, int, int, int, int, int, int, int, int, int, int> getVal)
        : this(key, (Data10)((i, j, k, l, m, n, o, p, q, r) => getVal(i, j, k, l, m, n, o, p, q, r))) { }

    // ctor - default
    public Par10(Data10 data)
        : this(DefaultParKeys.Get(), data)
    {
    }
    public Par10(double[][][][][][][][][][] val)
        : this(DefaultParKeys.Get(), val) { }
    public Par10(Func<int, int, int, int, int, int, int, int, int, int, double> getVal)
        : this(DefaultParKeys.Get(), getVal) { }
    public Par10(Func<int, int, int, int, int, int, int, int, int, int, int> getVal)
        : this(DefaultParKeys.Get(), (Data10)((i, j, k, l, m, n, o, p, q, r) => getVal(i, j, k, l, m, n, o, p, q, r))) { }


    // implicit
    public static implicit operator Par10(Data10 data)
        => new(data);
    public static implicit operator Par10(double[][][][][][][][][][] val)
        => new(val);
    public static implicit operator Par10(Func<int, int, int, int, int, int, int, int, int, int, double> getVal)
        => new(getVal);
}
