namespace MathProg;

public readonly struct Data2
{
    // data
    readonly Opt<double[][]> Val;
    readonly Opt<Func<int, int, double>> GetVal;


    // implicit
    Data2(Opt<double[][]> val, Opt<Func<int, int, double>> getVal)
    {
        Val = val;
        GetVal = getVal;
    }
    public static implicit operator Data2(double[][] val)
        => new(val, default);
    public static implicit operator Data2(Func<int, int, double> getVal)
        => new(default, getVal);


    // value
    public double this[int i, int j]
        => Val.IsSome ? Val.Unwrap()[i][j] : GetVal.Unwrap()(i, j);
}
