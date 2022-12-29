namespace MathProg;

public readonly struct Data7
{
    // data
    readonly Opt<double[][][][][][][]> Val;
    readonly Opt<Func<int, int, int, int, int, int, int, double>> GetVal;


    // implicit
    Data7(Opt<double[][][][][][][]> val, Opt<Func<int, int, int, int, int, int, int, double>> getVal)
    {
        Val = val;
        GetVal = getVal;
    }
    public static implicit operator Data7(double[][][][][][][] val)
        => new(val, default);
    public static implicit operator Data7(Func<int, int, int, int, int, int, int, double> getVal)
        => new(default, getVal);


    // value
    public double this[int i, int j, int k, int l, int m, int n, int o]
        => Val.IsSome ? Val.Unwrap()[i][j][k][l][m][n][o] : GetVal.Unwrap()(i, j, k, l, m, n, o);
}
