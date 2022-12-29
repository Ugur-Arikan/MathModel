using MathProg.DefaultKeys;

namespace MathProg;

public record Par0(string Key, Data0 Data) : IPar
{
    // method
    public int Dim => 0;


    // ctor
    public Par0(Data0 data)
        : this(DefaultParKeys.Get(), data)
    {
    }


    // implicit
    public static implicit operator Par0(Data0 data)
        => new(data);
    public static implicit operator Par0(double val)
        => new(val);
    public static implicit operator Par0(Func<double> getVal)
        => new(getVal);
}
