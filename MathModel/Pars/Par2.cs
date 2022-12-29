using MathProg.DefaultKeys;

namespace MathProg;

public record Par2(string Key, Data2 Data) : IPar
{
    // method
    public int Dim => 2;
    public Par this[Sca i, Sca j]
        => new(this, new(i, j));


    // ctor
    public Par2(string key, double[][] val)
        : this(key, (Data2)val) { }
    public Par2(string key, Func<int, int, double> getVal)
        : this(key, (Data2)getVal) { }
    public Par2(string key, Func<int, int, int> getVal)
        : this(key, (Data2)((i, j) => getVal(i, j))) { }

    // ctor - default
    public Par2(Data2 data)
        : this(DefaultParKeys.Get(), data)
    {
    }
    public Par2(double[][] val)
        : this(DefaultParKeys.Get(), val) { }
    public Par2(Func<int, int, double> getVal)
        : this(DefaultParKeys.Get(), getVal) { }
    public Par2(Func<int, int, int> getVal)
        : this(DefaultParKeys.Get(), (Data2)((i, j) => getVal(i, j))) { }


    // implicit
    public static implicit operator Par2(Data2 data)
        => new(data);
    public static implicit operator Par2(double[][] val)
        => new(val);
    public static implicit operator Par2(Func<int, int, double> getVal)
        => new(getVal);
}
