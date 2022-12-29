using MathProg.DefaultKeys;

namespace MathProg;

public record Par6(string Key, Data6 Data) : IPar
{
    // method
    public int Dim => 6;
    public Par this[Sca i, Sca j, Sca k, Sca l, Sca m, Sca n]
        => new(this, new(new List<Sca>() { i, j, k, l, m, n }));


    // ctor
    public Par6(string key, double[][][][][][] val)
        : this(key, (Data6)val) { }
    public Par6(string key, Func<int, int, int, int, int, int, double> getVal)
        : this(key, (Data6)getVal) { }
    public Par6(string key, Func<int, int, int, int, int, int, int> getVal)
        : this(key, (Data6)((i, j, k, l, m, n) => getVal(i, j, k, l, m, n))) { }

    // ctor - default
    public Par6(Data6 data)
        : this(DefaultParKeys.Get(), data)
    {
    }
    public Par6(double[][][][][][] val)
        : this(DefaultParKeys.Get(), val) { }
    public Par6(Func<int, int, int, int, int, int, double> getVal)
        : this(DefaultParKeys.Get(), getVal) { }
    public Par6(Func<int, int, int, int, int, int, int> getVal)
        : this(DefaultParKeys.Get(), (Data6)((i, j, k, l, m, n) => getVal(i, j, k, l, m, n))) { }


    // implicit
    public static implicit operator Par6(Data6 data)
        => new(data);
    public static implicit operator Par6(double[][][][][][] val)
        => new(val);
    public static implicit operator Par6(Func<int, int, int, int, int, int, double> getVal)
        => new(getVal);
}
