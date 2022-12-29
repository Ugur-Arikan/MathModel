namespace MathProg;

public readonly struct Data5
{
    // data
    readonly Opt<double[][][][][]> Val;
    readonly Opt<Func<int, int, int, int, int, double>> GetVal;


    // implicit
    Data5(Opt<double[][][][][]> val, Opt<Func<int, int, int, int, int, double>> getVal)
    {
        Val = val;
        GetVal = getVal;
    }
    public static implicit operator Data5(double[][][][][] val)
        => new(val, default);
    public static implicit operator Data5(Func<int, int, int, int, int, double> getVal)
        => new(default, getVal);


    // value
    public double this[int i, int j, int k, int l, int m]
        => Val.IsSome ? Val.Unwrap()[i][j][k][l][m] : GetVal.Unwrap()(i, j, k, l, m);
}
