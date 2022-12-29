namespace MathProg;

public readonly struct Data4
{
    // data
    readonly Opt<double[][][][]> Val;
    readonly Opt<Func<int, int, int, int, double>> GetVal;


    // implicit
    Data4(Opt<double[][][][]> val, Opt<Func<int, int, int, int, double>> getVal)
    {
        Val = val;
        GetVal = getVal;
    }
    public static implicit operator Data4(double[][][][] val)
        => new(val, default);
    public static implicit operator Data4(Func<int, int, int, int, double> getVal)
        => new(default, getVal);


    // value
    public double this[int i, int j, int k, int l]
        => Val.IsSome ? Val.Unwrap()[i][j][k][l] : GetVal.Unwrap()(i, j, k, l);
}
