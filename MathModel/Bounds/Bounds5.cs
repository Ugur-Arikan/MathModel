namespace MathProg;

public record struct Bounds5(Lim5 Lower, Lim5 Upper) : IBounds
{
    // ctor
    public static Bounds5 New(Lim5 lower, Lim5 upper)
        => new(lower, upper);
    public static Bounds5 New(Func<int, int, int, int, int, double> lower, Lim5 upper)
        => new(lower, upper);
    public static Bounds5 New(Lim5 lower, Func<int, int, int, int, int, double> upper)
        => new(lower, upper);
    public static Bounds5 New(Func<int, int, int, int, int, double> lower, Func<int, int, int, int, int, double> upper)
        => new(lower, upper);
    public static Bounds5 New(Func<int, int, int, int, int, int> lower, Lim5 upper)
        => New((i, j, k, l, m) => (double)lower(i, j, k, l, m), upper);
    public static Bounds5 New(Lim5 lower, Func<int, int, int, int, int, int> upper)
        => New(lower, (i, j, k, l, m) => (double)upper(i, j, k, l, m));
    public static Bounds5 New(Func<int, int, int, int, int, int> lower, Func<int, int, int, int, int, int> upper)
        => New((i, j, k, l, m) => (double)lower(i, j, k, l, m), (i, j, k, l, m) => upper(i, j, k, l, m));


    // implicit
    public static implicit operator Bounds5((Lim5 lower, Lim5 upper) bounds)
        => New(bounds.lower, bounds.upper);
    public static implicit operator Bounds5((Func<int, int, int, int, int, double> lower, Lim5 upper) bounds)
        => New(bounds.lower, bounds.upper);
    public static implicit operator Bounds5((Lim5 lower, Func<int, int, int, int, int, double> upper) bounds)
        => New(bounds.lower, bounds.upper);
    public static implicit operator Bounds5((Func<int, int, int, int, int, double> lower, Func<int, int, int, int, int, double> upper) bounds)
        => New(bounds.lower, bounds.upper);
    public static implicit operator Bounds5((Func<int, int, int, int, int, int> lower, Lim5 upper) bounds)
        => New(bounds.lower, bounds.upper);
    public static implicit operator Bounds5((Lim5 lower, Func<int, int, int, int, int, int> upper) bounds)
        => New(bounds.lower, bounds.upper);
    public static implicit operator Bounds5((Func<int, int, int, int, int, int> lower, Func<int, int, int, int, int, int> upper) bounds)
        => New(bounds.lower, bounds.upper);


    // const
    public static Bounds5 None
        => New(double.NegativeInfinity, double.PositiveInfinity);
    public static Bounds5 Nonneg
        => New(0.0, double.PositiveInfinity);
    public static Bounds5 Nonpos
        => New(double.NegativeInfinity, 0.0);
    public static Bounds5 ZeroOne
        => New(0.0, 1.0);


    // method
    internal bool IsContant
        => Lower.IsContant && Upper.IsContant;
    internal bool IsConstantlyNonneg
        => Lower.ConstantlyEqualTo(0.0) && Upper.IsConstantlyPosInf();
}
