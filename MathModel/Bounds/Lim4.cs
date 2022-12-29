namespace MathProg;

public readonly record struct Lim4 : ILim
{
    // data
    readonly Opt<double> Lim;
    readonly Opt<Func<int, int, int, int, double>> GetLim;


    // implicit
    Lim4(Opt<double> lim, Opt<Func<int, int, int, int, double>> getLim)
    {
        Lim = lim;
        GetLim = getLim;
    }
    public static implicit operator Lim4(double lim)
        => new(lim, default);
    public static implicit operator Lim4(Func<int, int, int, int, double> getLim)
        => new(default, getLim);


    // method
    public double this[int i, int j, int k, int l]
        => Lim.IsSome ? Lim.Unwrap() : GetLim.Unwrap()(i, j, k, l);
    internal bool IsContant
        => Lim.IsSome;
    internal bool ConstantlyEqualTo(double val)
        => Lim.IsSome && Math.Abs(Lim.Unwrap() - val) <= 1e-15;
    internal bool IsConstantlyPosInf()
        => Lim.IsSome && Lim.Unwrap() == double.PositiveInfinity;
}
