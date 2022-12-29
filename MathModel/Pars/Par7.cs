using MathProg.DefaultKeys;

namespace MathProg;

public record Par7(string Key, Data7 Data) : IPar
{
    // method
    public int Dim => 7;
    public Par this[Sca i, Sca j, Sca k, Sca l, Sca m, Sca n, Sca o]
        => new(this, new(new List<Sca>() { i, j, k, l, m, n, o }));


    // ctor
    public Par7(string key, double[][][][][][][] val)
        : this(key, (Data7)val) { }
    public Par7(string key, Func<int, int, int, int, int, int, int, double> getVal)
        : this(key, (Data7)getVal) { }
    public Par7(string key, Func<int, int, int, int, int, int, int, int> getVal)
        : this(key, (Data7)((i, j, k, l, m, n, o) => getVal(i, j, k, l, m, n, o))) { }

    // ctor - default
    public Par7(Data7 data)
        : this(DefaultParKeys.Get(), data)
    {
    }
    public Par7(double[][][][][][][] val)
        : this(DefaultParKeys.Get(), val) { }
    public Par7(Func<int, int, int, int, int, int, int, double> getVal)
        : this(DefaultParKeys.Get(), getVal) { }
    public Par7(Func<int, int, int, int, int, int, int, int> getVal)
        : this(DefaultParKeys.Get(), (Data7)((i, j, k, l, m, n, o) => getVal(i, j, k, l, m, n, o))) { }


    // implicit
    public static implicit operator Par7(Data7 data)
        => new(data);
    public static implicit operator Par7(double[][][][][][][] val)
        => new(val);
    public static implicit operator Par7(Func<int, int, int, int, int, int, int, double> getVal)
        => new(getVal);
}
