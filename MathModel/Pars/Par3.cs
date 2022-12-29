using MathProg.DefaultKeys;

namespace MathProg;

public record Par3(string Key, Data3 Data) : IPar
{
    // method
    public int Dim => 3;
    public Par this[Sca i, Sca j, Sca k]
        => new(this, new(new List<Sca>() { i, j, k }));


    // ctor
    public Par3(string key, double[][][] val)
        : this(key, (Data3)val) { }
    public Par3(string key, Func<int, int, int, double> getVal)
        : this(key, (Data3)getVal) { }
    public Par3(string key, Func<int, int, int, int> getVal)
        : this(key, (Data3)((i, j, k) => getVal(i, j, k))) { }

    // ctor - default
    public Par3(Data3 data)
        : this(DefaultParKeys.Get(), data)
    {
    }
    public Par3(double[][][] val)
        : this(DefaultParKeys.Get(), val) { }
    public Par3(Func<int, int, int, double> getVal)
        : this(DefaultParKeys.Get(), getVal) { }
    public Par3(Func<int, int, int, int> getVal)
        : this(DefaultParKeys.Get(), (Data3)((i, j, k) => getVal(i, j, k))) { }


    // implicit
    public static implicit operator Par3(Data3 data)
        => new(data);
    public static implicit operator Par3(double[][][] val)
        => new(val);
    public static implicit operator Par3(Func<int, int, int, double> getVal)
        => new(getVal);
}
