using MathProg.DefaultKeys;

namespace MathProg;

public record Par1(string Key, Data1 Data) : IPar
{
    // method
    public int Dim => 1;
    public Par this[Sca i]
        => new(this, i);


    // ctor
    public Par1(string key, double[] val)
        : this(key, (Data1)val) { }
    public Par1(string key, Func<int, double> getVal)
        : this(key, (Data1)getVal) { }
    public Par1(string key, Func<int, int> getVal)
        : this(key, (Data1)(i => getVal(i))) { }

    // ctor - default
    public Par1(Data1 data)
        : this(DefaultParKeys.Get(), data)
    {
    }
    public Par1(double[] val)
        : this(DefaultParKeys.Get(), val) { }
    public Par1(Func<int, double> getVal)
        : this(DefaultParKeys.Get(), getVal) { }
    public Par1(Func<int, int> getVal)
        : this(DefaultParKeys.Get(), (Data1)(i => getVal(i))) { }


    // implicit
    public static implicit operator Par1(Data1 data)
        => new(data);
    public static implicit operator Par1(double[] val)
        => new(val);
    public static implicit operator Par1(Func<int, double> getVal)
        => new(getVal);
}
