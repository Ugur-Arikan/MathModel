using MathProg.DefaultKeys;

namespace MathProg;

public record Par5(string Key, Data5 Data) : IPar
{
    // method
    public int Dim => 5;
    public Par this[Sca i, Sca j, Sca k, Sca l, Sca m]
        => new(this, new(new List<Sca>() { i, j, k, l, m }));


    // ctor
    public Par5(string key, double[][][][][] val)
        : this(key, (Data5)val) { }
    public Par5(string key, Func<int, int, int, int, int, double> getVal)
        : this(key, (Data5)getVal) { }
    public Par5(string key, Func<int, int, int, int, int, int> getVal)
        : this(key, (Data5)((i, j, k, l, m) => getVal(i, j, k, l, m))) { }

    // ctor - default
    public Par5(Data5 data)
        : this(DefaultParKeys.Get(), data)
    {
    }
    public Par5(double[][][][][] val)
        : this(DefaultParKeys.Get(), val) { }
    public Par5(Func<int, int, int, int, int, double> getVal)
        : this(DefaultParKeys.Get(), getVal) { }
    public Par5(Func<int, int, int, int, int, int> getVal)
        : this(DefaultParKeys.Get(), (Data5)((i, j, k, l, m) => getVal(i, j, k, l, m))) { }


    // implicit
    public static implicit operator Par5(Data5 data)
        => new(data);
    public static implicit operator Par5(double[][][][][] val)
        => new(val);
    public static implicit operator Par5(Func<int, int, int, int, int, double> getVal)
        => new(getVal);
}
