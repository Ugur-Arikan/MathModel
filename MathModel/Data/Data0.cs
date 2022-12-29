namespace MathProg;

public readonly struct Data0 : ILim
{
    // data
    readonly Opt<double> Val;
    readonly Opt<Func<double>> GetVal;


    // implicit
    Data0(Opt<double> val, Opt<Func<double>> getVal)
    {
        Val = val;
        GetVal = getVal;
    }
    public static implicit operator Data0(double val)
        => new(val, default);
    public static implicit operator Data0(Func<double> getVal)
        => new(default, getVal);


    // value
    public double Value
        => Val.IsSome ? Val.Unwrap() : GetVal.Unwrap()();
    public static implicit operator double(Data0 data)
        => data.Value;
    internal bool IsContant
        => Val.IsSome;
    internal bool ConstantlyEqualTo(double val)
        => Val.IsSome && Math.Abs(Val.Unwrap() - val) <= 1e-15;
    internal bool IsConstantlyPosInf()
        => Val.IsSome && Val.Unwrap() == double.PositiveInfinity;
}
