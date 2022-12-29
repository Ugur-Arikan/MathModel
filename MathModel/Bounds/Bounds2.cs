namespace MathProg;

public record struct Bounds2(Lim2 Lower, Lim2 Upper) : IBounds
{
    // ctor
    public static Bounds2 New(Lim2 lower, Lim2 upper)
        => new(lower, upper);
    public static Bounds2 New(Func<int, int, double> lower, Lim2 upper)
        => new(lower, upper);
    public static Bounds2 New(Lim2 lower, Func<int, int, double> upper)
        => new(lower, upper);
    public static Bounds2 New(Func<int, int, double> lower, Func<int, int, double> upper)
        => new(lower, upper);
    public static Bounds2 New(Func<int, int, int> lower, Lim2 upper)
        => New((i, j) => (double)lower(i, j), upper);
    public static Bounds2 New(Lim2 lower, Func<int, int, int> upper)
        => New(lower, (i, j) => (double)upper(i, j));
    public static Bounds2 New(Func<int, int, int> lower, Func<int, int, int> upper)
        => New((i, j) => (double)lower(i, j), (i, j) => upper(i, j));


    // implicit
    public static implicit operator Bounds2((Lim2 lower, Lim2 upper) bounds)
        => New(bounds.lower, bounds.upper);
    public static implicit operator Bounds2((Func<int, int, double> lower, Lim2 upper) bounds)
        => New(bounds.lower, bounds.upper);
    public static implicit operator Bounds2((Lim2 lower, Func<int, int, double> upper) bounds)
        => New(bounds.lower, bounds.upper);
    public static implicit operator Bounds2((Func<int, int, double> lower, Func<int, int, double> upper) bounds)
        => New(bounds.lower, bounds.upper);
    public static implicit operator Bounds2((Func<int, int, int> lower, Lim2 upper) bounds)
        => New(bounds.lower, bounds.upper);
    public static implicit operator Bounds2((Lim2 lower, Func<int, int, int> upper) bounds)
        => New(bounds.lower, bounds.upper);
    public static implicit operator Bounds2((Func<int, int, int> lower, Func<int, int, int> upper) bounds)
        => New(bounds.lower, bounds.upper);


    // const
    public static Bounds2 None
        => New(double.NegativeInfinity, double.PositiveInfinity);
    public static Bounds2 Nonneg
        => New(0.0, double.PositiveInfinity);
    public static Bounds2 Nonpos
        => New(double.NegativeInfinity, 0.0);
    public static Bounds2 ZeroOne
        => New(0.0, 1.0);


    // method
    internal bool IsContant
        => Lower.IsContant && Upper.IsContant;
    internal bool IsConstantlyNonneg
        => Lower.ConstantlyEqualTo(0.0) && Upper.IsConstantlyPosInf();
}
