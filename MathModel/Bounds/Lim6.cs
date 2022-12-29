namespace MathProg;

public readonly record struct Lim6 : ILim
{
    // data
    readonly Opt<double> Lim;
    readonly Opt<Func<int, int, int, int, int, int, double>> GetLim;


    // implicit
    Lim6(Opt<double> lim, Opt<Func<int, int, int, int, int, int, double>> getLim)
    {
        Lim = lim;
        GetLim = getLim;
    }
    public static implicit operator Lim6(double lim)
        => new(lim, default);
    public static implicit operator Lim6(Func<int, int, int, int, int, int, double> getLim)
        => new(default, getLim);


    // method
    public double this[int i, int j, int k, int l, int m, int n]
        => Lim.IsSome ? Lim.Unwrap() : GetLim.Unwrap()(i, j, k, l, m, n);
    internal bool IsContant
        => Lim.IsSome;
    internal bool ConstantlyEqualTo(double val)
        => Lim.IsSome && Math.Abs(Lim.Unwrap() - val) <= 1e-15;
    internal bool IsConstantlyPosInf()
        => Lim.IsSome && Lim.Unwrap() == double.PositiveInfinity;
}
