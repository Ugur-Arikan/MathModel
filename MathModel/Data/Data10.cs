namespace MathProg;

public readonly struct Data10
{
    // data
    readonly Opt<double[][][][][][][][][][]> Val;
    readonly Opt<Func<int, int, int, int, int, int, int, int, int, int, double>> GetVal;


    // implicit
    Data10(Opt<double[][][][][][][][][][]> val, Opt<Func<int, int, int, int, int, int, int, int, int, int, double>> getVal)
    {
        Val = val;
        GetVal = getVal;
    }
    public static implicit operator Data10(double[][][][][][][][][][] val)
        => new(val, default);
    public static implicit operator Data10(Func<int, int, int, int, int, int, int, int, int, int, double> getVal)
        => new(default, getVal);


    // value
    public double this[int i, int j, int k, int l, int m, int n, int o, int p, int q, int r]
        => Val.IsSome ? Val.Unwrap()[i][j][k][l][m][n][o][p][q][r] : GetVal.Unwrap()(i, j, k, l, m, n, o, p, q, r);
}
