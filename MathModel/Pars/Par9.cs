using MathProg.DefaultKeys;

namespace MathProg;

public record Par9(string Key, Data9 Data) : IPar
{
    // method
    public int Dim => 9;
    public Par this[Sca i, Sca j, Sca k, Sca l, Sca m, Sca n, Sca o, Sca p, Sca q]
        => new(this, new(new List<Sca>() { i, j, k, l, m, n, o, p, q }));


    // ctor
    public Par9(string key, double[][][][][][][][][] val)
        : this(key, (Data9)val) { }
    public Par9(string key, Func<int, int, int, int, int, int, int, int, int, double> getVal)
        : this(key, (Data9)getVal) { }
    public Par9(string key, Func<int, int, int, int, int, int, int, int, int, int> getVal)
        : this(key, (Data9)((i, j, k, l, m, n, o, p, q) => getVal(i, j, k, l, m, n, o, p, q))) { }

    // ctor - default
    public Par9(Data9 data)
        : this(DefaultParKeys.Get(), data)
    {
    }
    public Par9(double[][][][][][][][][] val)
        : this(DefaultParKeys.Get(), val) { }
    public Par9(Func<int, int, int, int, int, int, int, int, int, double> getVal)
        : this(DefaultParKeys.Get(), getVal) { }
    public Par9(Func<int, int, int, int, int, int, int, int, int, int> getVal)
        : this(DefaultParKeys.Get(), (Data9)((i, j, k, l, m, n, o, p, q) => getVal(i, j, k, l, m, n, o, p, q))) { }


    // implicit
    public static implicit operator Par9(Data9 data)
        => new(data);
    public static implicit operator Par9(double[][][][][][][][][] val)
        => new(val);
    public static implicit operator Par9(Func<int, int, int, int, int, int, int, int, int, double> getVal)
        => new(getVal);
}
