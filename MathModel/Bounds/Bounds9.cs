namespace MathProg;

public record struct Bounds9(Lim9 Lower, Lim9 Upper) : IBounds
{
    // ctor
    public static Bounds9 New(Lim9 lower, Lim9 upper)
        => new(lower, upper);
    public static Bounds9 New(Func<int, int, int, int, int, int, int, int, int, double> lower, Lim9 upper)
        => new(lower, upper);
    public static Bounds9 New(Lim9 lower, Func<int, int, int, int, int, int, int, int, int, double> upper)
        => new(lower, upper);
    public static Bounds9 New(Func<int, int, int, int, int, int, int, int, int, double> lower, Func<int, int, int, int, int, int, int, int, int, double> upper)
        => new(lower, upper);
    public static Bounds9 New(Func<int, int, int, int, int, int, int, int, int, int> lower, Lim9 upper)
        => New((i, j, k, l, m, n, o, p, q) => (double)lower(i, j, k, l, m, n, o, p, q), upper);
    public static Bounds9 New(Lim9 lower, Func<int, int, int, int, int, int, int, int, int, int> upper)
        => New(lower, (i, j, k, l, m, n, o, p, q) => (double)upper(i, j, k, l, m, n, o, p, q));
    public static Bounds9 New(Func<int, int, int, int, int, int, int, int, int, int> lower, Func<int, int, int, int, int, int, int, int, int, int> upper)
        => New((i, j, k, l, m, n, o, p, q) => (double)lower(i, j, k, l, m, n, o, p, q), (i, j, k, l, m, n, o, p, q) => upper(i, j, k, l, m, n, o, p, q));


    // implicit
    public static implicit operator Bounds9((Lim9 lower, Lim9 upper) bounds)
        => New(bounds.lower, bounds.upper);
    public static implicit operator Bounds9((Func<int, int, int, int, int, int, int, int, int, double> lower, Lim9 upper) bounds)
        => New(bounds.lower, bounds.upper);
    public static implicit operator Bounds9((Lim9 lower, Func<int, int, int, int, int, int, int, int, int, double> upper) bounds)
        => New(bounds.lower, bounds.upper);
    public static implicit operator Bounds9((Func<int, int, int, int, int, int, int, int, int, double> lower, Func<int, int, int, int, int, int, int, int, int, double> upper) bounds)
        => New(bounds.lower, bounds.upper);
    public static implicit operator Bounds9((Func<int, int, int, int, int, int, int, int, int, int> lower, Lim9 upper) bounds)
        => New(bounds.lower, bounds.upper);
    public static implicit operator Bounds9((Lim9 lower, Func<int, int, int, int, int, int, int, int, int, int> upper) bounds)
        => New(bounds.lower, bounds.upper);
    public static implicit operator Bounds9((Func<int, int, int, int, int, int, int, int, int, int> lower, Func<int, int, int, int, int, int, int, int, int, int> upper) bounds)
        => New(bounds.lower, bounds.upper);


    // const
    public static Bounds9 None
        => New(double.NegativeInfinity, double.PositiveInfinity);
    public static Bounds9 Nonneg
        => New(0.0, double.PositiveInfinity);
    public static Bounds9 Nonpos
        => New(double.NegativeInfinity, 0.0);
    public static Bounds9 ZeroOne
        => New(0.0, 1.0);


    // method
    internal bool IsContant
        => Lower.IsContant && Upper.IsContant;
    internal bool IsConstantlyNonneg
        => Lower.ConstantlyEqualTo(0.0) && Upper.IsConstantlyPosInf();
}
