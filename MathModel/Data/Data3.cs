namespace MathProg;

public readonly struct Data3
{
    // data
    readonly Opt<double[][][]> Val;
    readonly Opt<Func<int, int, int, double>> GetVal;


    // implicit
    Data3(Opt<double[][][]> val, Opt<Func<int, int, int, double>> getVal)
    {
        Val = val;
        GetVal = getVal;
    }
    public static implicit operator Data3(double[][][] val)
        => new(val, default);
    public static implicit operator Data3(Func<int, int, int, double> getVal)
        => new(default, getVal);


    // value
    public double this[int i, int j, int k]
        => Val.IsSome ? Val.Unwrap()[i][j][k] : GetVal.Unwrap()(i, j, k);
}
