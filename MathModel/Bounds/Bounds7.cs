namespace MathProg;

public record struct Bounds7(Lim7 Lower, Lim7 Upper) : IBounds
{
    // ctor
    public static Bounds7 New(Lim7 lower, Lim7 upper)
        => new(lower, upper);
    public static Bounds7 New(Func<int, int, int, int, int, int, int, double> lower, Lim7 upper)
        => new(lower, upper);
    public static Bounds7 New(Lim7 lower, Func<int, int, int, int, int, int, int, double> upper)
        => new(lower, upper);
    public static Bounds7 New(Func<int, int, int, int, int, int, int, double> lower, Func<int, int, int, int, int, int, int, double> upper)
        => new(lower, upper);
    public static Bounds7 New(Func<int, int, int, int, int, int, int, int> lower, Lim7 upper)
        => New((i, j, k, l, m, n, o) => (double)lower(i, j, k, l, m, n, o), upper);
    public static Bounds7 New(Lim7 lower, Func<int, int, int, int, int, int, int, int> upper)
        => New(lower, (i, j, k, l, m, n, o) => (double)upper(i, j, k, l, m, n, o));
    public static Bounds7 New(Func<int, int, int, int, int, int, int, int> lower, Func<int, int, int, int, int, int, int, int> upper)
        => New((i, j, k, l, m, n, o) => (double)lower(i, j, k, l, m, n, o), (i, j, k, l, m, n, o) => upper(i, j, k, l, m, n, o));


    // implicit
    public static implicit operator Bounds7((Lim7 lower, Lim7 upper) bounds)
        => New(bounds.lower, bounds.upper);
    public static implicit operator Bounds7((Func<int, int, int, int, int, int, int, double> lower, Lim7 upper) bounds)
        => New(bounds.lower, bounds.upper);
    public static implicit operator Bounds7((Lim7 lower, Func<int, int, int, int, int, int, int, double> upper) bounds)
        => New(bounds.lower, bounds.upper);
    public static implicit operator Bounds7((Func<int, int, int, int, int, int, int, double> lower, Func<int, int, int, int, int, int, int, double> upper) bounds)
        => New(bounds.lower, bounds.upper);
    public static implicit operator Bounds7((Func<int, int, int, int, int, int, int, int> lower, Lim7 upper) bounds)
        => New(bounds.lower, bounds.upper);
    public static implicit operator Bounds7((Lim7 lower, Func<int, int, int, int, int, int, int, int> upper) bounds)
        => New(bounds.lower, bounds.upper);
    public static implicit operator Bounds7((Func<int, int, int, int, int, int, int, int> lower, Func<int, int, int, int, int, int, int, int> upper) bounds)
        => New(bounds.lower, bounds.upper);


    // const
    public static Bounds7 None
        => New(double.NegativeInfinity, double.PositiveInfinity);
    public static Bounds7 Nonneg
        => New(0.0, double.PositiveInfinity);
    public static Bounds7 Nonpos
        => New(double.NegativeInfinity, 0.0);
    public static Bounds7 ZeroOne
        => New(0.0, 1.0);


    // method
    internal bool IsContant
        => Lower.IsContant && Upper.IsContant;
    internal bool IsConstantlyNonneg
        => Lower.ConstantlyEqualTo(0.0) && Upper.IsConstantlyPosInf();
}
