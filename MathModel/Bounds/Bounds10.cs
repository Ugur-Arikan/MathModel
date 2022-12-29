namespace MathProg;

public record struct Bounds10(Lim10 Lower, Lim10 Upper) : IBounds
{
    // ctor
    public static Bounds10 New(Lim10 lower, Lim10 upper)
        => new(lower, upper);
    public static Bounds10 New(Func<int, int, int, int, int, int, int, int, int, int, double> lower, Lim10 upper)
        => new(lower, upper);
    public static Bounds10 New(Lim10 lower, Func<int, int, int, int, int, int, int, int, int, int, double> upper)
        => new(lower, upper);
    public static Bounds10 New(Func<int, int, int, int, int, int, int, int, int, int, double> lower, Func<int, int, int, int, int, int, int, int, int, int, double> upper)
        => new(lower, upper);
    public static Bounds10 New(Func<int, int, int, int, int, int, int, int, int, int, int> lower, Lim10 upper)
        => New((i, j, k, l, m, n, o, p, q, r) => (double)lower(i, j, k, l, m, n, o, p, q, r), upper);
    public static Bounds10 New(Lim10 lower, Func<int, int, int, int, int, int, int, int, int, int, int> upper)
        => New(lower, (i, j, k, l, m, n, o, p, q, r) => (double)upper(i, j, k, l, m, n, o, p, q, r));
    public static Bounds10 New(Func<int, int, int, int, int, int, int, int, int, int, int> lower, Func<int, int, int, int, int, int, int, int, int, int, int> upper)
        => New((i, j, k, l, m, n, o, p, q, r) => (double)lower(i, j, k, l, m, n, o, p, q, r), (i, j, k, l, m, n, o, p, q, r) => upper(i, j, k, l, m, n, o, p, q, r));


    // implicit
    public static implicit operator Bounds10((Lim10 lower, Lim10 upper) bounds)
        => New(bounds.lower, bounds.upper);
    public static implicit operator Bounds10((Func<int, int, int, int, int, int, int, int, int, int, double> lower, Lim10 upper) bounds)
        => New(bounds.lower, bounds.upper);
    public static implicit operator Bounds10((Lim10 lower, Func<int, int, int, int, int, int, int, int, int, int, double> upper) bounds)
        => New(bounds.lower, bounds.upper);
    public static implicit operator Bounds10((Func<int, int, int, int, int, int, int, int, int, int, double> lower, Func<int, int, int, int, int, int, int, int, int, int, double> upper) bounds)
        => New(bounds.lower, bounds.upper);
    public static implicit operator Bounds10((Func<int, int, int, int, int, int, int, int, int, int, int> lower, Lim10 upper) bounds)
        => New(bounds.lower, bounds.upper);
    public static implicit operator Bounds10((Lim10 lower, Func<int, int, int, int, int, int, int, int, int, int, int> upper) bounds)
        => New(bounds.lower, bounds.upper);
    public static implicit operator Bounds10((Func<int, int, int, int, int, int, int, int, int, int, int> lower, Func<int, int, int, int, int, int, int, int, int, int, int> upper) bounds)
        => New(bounds.lower, bounds.upper);


    // const
    public static Bounds10 None
        => New(double.NegativeInfinity, double.PositiveInfinity);
    public static Bounds10 Nonneg
        => New(0.0, double.PositiveInfinity);
    public static Bounds10 Nonpos
        => New(double.NegativeInfinity, 0.0);
    public static Bounds10 ZeroOne
        => New(0.0, 1.0);


    // method
    internal bool IsContant
        => Lower.IsContant && Upper.IsContant;
    internal bool IsConstantlyNonneg
        => Lower.ConstantlyEqualTo(0.0) && Upper.IsConstantlyPosInf();
}
