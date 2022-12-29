namespace MathProg;

public readonly struct Data9
{
    // data
    readonly Opt<double[][][][][][][][][]> Val;
    readonly Opt<Func<int, int, int, int, int, int, int, int, int, double>> GetVal;


    // implicit
    Data9(Opt<double[][][][][][][][][]> val, Opt<Func<int, int, int, int, int, int, int, int, int, double>> getVal)
    {
        Val = val;
        GetVal = getVal;
    }
    public static implicit operator Data9(double[][][][][][][][][] val)
        => new(val, default);
    public static implicit operator Data9(Func<int, int, int, int, int, int, int, int, int, double> getVal)
        => new(default, getVal);


    // value
    public double this[int i, int j, int k, int l, int m, int n, int o, int p, int q]
        => Val.IsSome ? Val.Unwrap()[i][j][k][l][m][n][o][p][q] : GetVal.Unwrap()(i, j, k, l, m, n, o, p, q);
}
