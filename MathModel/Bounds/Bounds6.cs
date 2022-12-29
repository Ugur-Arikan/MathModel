namespace MathProg;

public record struct Bounds6(Lim6 Lower, Lim6 Upper) : IBounds
{
    // ctor
    public static Bounds6 New(Lim6 lower, Lim6 upper)
        => new(lower, upper);
    public static Bounds6 New(Func<int, int, int, int, int, int, double> lower, Lim6 upper)
        => new(lower, upper);
    public static Bounds6 New(Lim6 lower, Func<int, int, int, int, int, int, double> upper)
        => new(lower, upper);
    public static Bounds6 New(Func<int, int, int, int, int, int, double> lower, Func<int, int, int, int, int, int, double> upper)
        => new(lower, upper);
    public static Bounds6 New(Func<int, int, int, int, int, int, int> lower, Lim6 upper)
        => New((i, j, k, l, m, n) => (double)lower(i, j, k, l, m, n), upper);
    public static Bounds6 New(Lim6 lower, Func<int, int, int, int, int, int, int> upper)
        => New(lower, (i, j, k, l, m, n) => (double)upper(i, j, k, l, m, n));
    public static Bounds6 New(Func<int, int, int, int, int, int, int> lower, Func<int, int, int, int, int, int, int> upper)
        => New((i, j, k, l, m, n) => (double)lower(i, j, k, l, m, n), (i, j, k, l, m, n) => upper(i, j, k, l, m, n));


    // implicit
    public static implicit operator Bounds6((Lim6 lower, Lim6 upper) bounds)
        => New(bounds.lower, bounds.upper);
    public static implicit operator Bounds6((Func<int, int, int, int, int, int, double> lower, Lim6 upper) bounds)
        => New(bounds.lower, bounds.upper);
    public static implicit operator Bounds6((Lim6 lower, Func<int, int, int, int, int, int, double> upper) bounds)
        => New(bounds.lower, bounds.upper);
    public static implicit operator Bounds6((Func<int, int, int, int, int, int, double> lower, Func<int, int, int, int, int, int, double> upper) bounds)
        => New(bounds.lower, bounds.upper);
    public static implicit operator Bounds6((Func<int, int, int, int, int, int, int> lower, Lim6 upper) bounds)
        => New(bounds.lower, bounds.upper);
    public static implicit operator Bounds6((Lim6 lower, Func<int, int, int, int, int, int, int> upper) bounds)
        => New(bounds.lower, bounds.upper);
    public static implicit operator Bounds6((Func<int, int, int, int, int, int, int> lower, Func<int, int, int, int, int, int, int> upper) bounds)
        => New(bounds.lower, bounds.upper);


    // const
    public static Bounds6 None
        => New(double.NegativeInfinity, double.PositiveInfinity);
    public static Bounds6 Nonneg
        => New(0.0, double.PositiveInfinity);
    public static Bounds6 Nonpos
        => New(double.NegativeInfinity, 0.0);
    public static Bounds6 ZeroOne
        => New(0.0, 1.0);


    // method
    internal bool IsContant
        => Lower.IsContant && Upper.IsContant;
    internal bool IsConstantlyNonneg
        => Lower.ConstantlyEqualTo(0.0) && Upper.IsConstantlyPosInf();
}
