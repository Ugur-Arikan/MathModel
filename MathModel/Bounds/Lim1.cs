namespace MathProg;

public readonly record struct Lim1 : ILim
{
    // data
    readonly Opt<double> Lim;
    readonly Opt<Func<int, double>> GetLim;


    // implicit
    Lim1(Opt<double> lim, Opt<Func<int, double>> getLim)
    {
        Lim = lim;
        GetLim = getLim;
    }
    public static implicit operator Lim1(double lim)
        => new(lim, default);
    public static implicit operator Lim1(Func<int, double> getLim)
        => new(default, getLim);


    // method
    public double this[int i]
        => Lim.IsSome ? Lim.Unwrap() : GetLim.Unwrap()(i);
    internal bool IsContant
        => Lim.IsSome;
    internal bool ConstantlyEqualTo(double val)
        => Lim.IsSome && Math.Abs(Lim.Unwrap() - val) <= 1e-15;
    internal bool IsConstantlyPosInf()
        => Lim.IsSome && Lim.Unwrap() == double.PositiveInfinity;
}
