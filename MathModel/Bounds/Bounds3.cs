namespace MathProg;

public record struct Bounds3(Lim3 Lower, Lim3 Upper) : IBounds
{
    // ctor
    public static Bounds3 New(Lim3 lower, Lim3 upper)
        => new(lower, upper);
    public static Bounds3 New(Func<int, int, int, double> lower, Lim3 upper)
        => new(lower, upper);
    public static Bounds3 New(Lim3 lower, Func<int, int, int, double> upper)
        => new(lower, upper);
    public static Bounds3 New(Func<int, int, int, double> lower, Func<int, int, int, double> upper)
        => new(lower, upper);
    public static Bounds3 New(Func<int, int, int, int> lower, Lim3 upper)
        => New((i, j, k) => (double)lower(i, j, k), upper);
    public static Bounds3 New(Lim3 lower, Func<int, int, int, int> upper)
        => New(lower, (i, j, k) => (double)upper(i, j, k));
    public static Bounds3 New(Func<int, int, int, int> lower, Func<int, int, int, int> upper)
        => New((i, j, k) => (double)lower(i, j, k), (i, j, k) => upper(i, j, k));


    // implicit
    public static implicit operator Bounds3((Lim3 lower, Lim3 upper) bounds)
        => New(bounds.lower, bounds.upper);
    public static implicit operator Bounds3((Func<int, int, int, double> lower, Lim3 upper) bounds)
        => New(bounds.lower, bounds.upper);
    public static implicit operator Bounds3((Lim3 lower, Func<int, int, int, double> upper) bounds)
        => New(bounds.lower, bounds.upper);
    public static implicit operator Bounds3((Func<int, int, int, double> lower, Func<int, int, int, double> upper) bounds)
        => New(bounds.lower, bounds.upper);
    public static implicit operator Bounds3((Func<int, int, int, int> lower, Lim3 upper) bounds)
        => New(bounds.lower, bounds.upper);
    public static implicit operator Bounds3((Lim3 lower, Func<int, int, int, int> upper) bounds)
        => New(bounds.lower, bounds.upper);
    public static implicit operator Bounds3((Func<int, int, int, int> lower, Func<int, int, int, int> upper) bounds)
        => New(bounds.lower, bounds.upper);


    // const
    public static Bounds3 None
        => New(double.NegativeInfinity, double.PositiveInfinity);
    public static Bounds3 Nonneg
        => New(0.0, double.PositiveInfinity);
    public static Bounds3 Nonpos
        => New(double.NegativeInfinity, 0.0);
    public static Bounds3 ZeroOne
        => New(0.0, 1.0);


    // method
    internal bool IsContant
        => Lower.IsContant && Upper.IsContant;
    internal bool IsConstantlyNonneg
        => Lower.ConstantlyEqualTo(0.0) && Upper.IsConstantlyPosInf();
}
