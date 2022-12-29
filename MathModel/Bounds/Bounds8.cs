namespace MathProg;

public record struct Bounds8(Lim8 Lower, Lim8 Upper) : IBounds
{
    // ctor
    public static Bounds8 New(Lim8 lower, Lim8 upper)
        => new(lower, upper);
    public static Bounds8 New(Func<int, int, int, int, int, int, int, int, double> lower, Lim8 upper)
        => new(lower, upper);
    public static Bounds8 New(Lim8 lower, Func<int, int, int, int, int, int, int, int, double> upper)
        => new(lower, upper);
    public static Bounds8 New(Func<int, int, int, int, int, int, int, int, double> lower, Func<int, int, int, int, int, int, int, int, double> upper)
        => new(lower, upper);
    public static Bounds8 New(Func<int, int, int, int, int, int, int, int, int> lower, Lim8 upper)
        => New((i, j, k, l, m, n, o, p) => (double)lower(i, j, k, l, m, n, o, p), upper);
    public static Bounds8 New(Lim8 lower, Func<int, int, int, int, int, int, int, int, int> upper)
        => New(lower, (i, j, k, l, m, n, o, p) => (double)upper(i, j, k, l, m, n, o, p));
    public static Bounds8 New(Func<int, int, int, int, int, int, int, int, int> lower, Func<int, int, int, int, int, int, int, int, int> upper)
        => New((i, j, k, l, m, n, o, p) => (double)lower(i, j, k, l, m, n, o, p), (i, j, k, l, m, n, o, p) => upper(i, j, k, l, m, n, o, p));


    // implicit
    public static implicit operator Bounds8((Lim8 lower, Lim8 upper) bounds)
        => New(bounds.lower, bounds.upper);
    public static implicit operator Bounds8((Func<int, int, int, int, int, int, int, int, double> lower, Lim8 upper) bounds)
        => New(bounds.lower, bounds.upper);
    public static implicit operator Bounds8((Lim8 lower, Func<int, int, int, int, int, int, int, int, double> upper) bounds)
        => New(bounds.lower, bounds.upper);
    public static implicit operator Bounds8((Func<int, int, int, int, int, int, int, int, double> lower, Func<int, int, int, int, int, int, int, int, double> upper) bounds)
        => New(bounds.lower, bounds.upper);
    public static implicit operator Bounds8((Func<int, int, int, int, int, int, int, int, int> lower, Lim8 upper) bounds)
        => New(bounds.lower, bounds.upper);
    public static implicit operator Bounds8((Lim8 lower, Func<int, int, int, int, int, int, int, int, int> upper) bounds)
        => New(bounds.lower, bounds.upper);
    public static implicit operator Bounds8((Func<int, int, int, int, int, int, int, int, int> lower, Func<int, int, int, int, int, int, int, int, int> upper) bounds)
        => New(bounds.lower, bounds.upper);


    // const
    public static Bounds8 None
        => New(double.NegativeInfinity, double.PositiveInfinity);
    public static Bounds8 Nonneg
        => New(0.0, double.PositiveInfinity);
    public static Bounds8 Nonpos
        => New(double.NegativeInfinity, 0.0);
    public static Bounds8 ZeroOne
        => New(0.0, 1.0);


    // method
    internal bool IsContant
        => Lower.IsContant && Upper.IsContant;
    internal bool IsConstantlyNonneg
        => Lower.ConstantlyEqualTo(0.0) && Upper.IsConstantlyPosInf();
}
