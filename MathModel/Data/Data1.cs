namespace MathProg;

public readonly record struct Data1
{
    // data
    readonly Opt<double[]> Val;
    readonly Opt<Func<int, double>> GetVal;


    // implicit
    Data1(Opt<double[]> val, Opt<Func<int, double>> getVal)
    {
        Val = val;
        GetVal = getVal;
    }
    public static implicit operator Data1(double[] val)
        => new(val, default);
    public static implicit operator Data1(Func<int, double> getVal)
        => new(default, getVal);


    // value
    public double this[int i]
        => Val.IsSome ? Val.Unwrap()[i] : GetVal.Unwrap()(i);
}
