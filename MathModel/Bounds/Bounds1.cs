namespace MathProg;

public record struct Bounds1(Lim1 Lower, Lim1 Upper) : IBounds
{
    // ctor
    public static Bounds1 New(Lim1 lower, Lim1 upper)
        => new(lower, upper);
    public static Bounds1 New(Func<int, double> lower, Lim1 upper)
        => new(lower, upper);
    public static Bounds1 New(Lim1 lower, Func<int, double> upper)
        => new(lower, upper);
    public static Bounds1 New(Func<int, double> lower, Func<int, double> upper)
        => new(lower, upper);
    public static Bounds1 New(Func<int, int> lower, Lim1 upper)
        => New(i => (double)lower(i), upper);
    public static Bounds1 New(Lim1 lower, Func<int, int> upper)
        => New(lower, i => (double)upper(i));
    public static Bounds1 New(Func<int, int> lower, Func<int, int> upper)
        => New(i => (double)lower(i), i => upper(i));


    // implicit
    public static implicit operator Bounds1((Lim1 lower, Lim1 upper) bounds)
        => New(bounds.lower, bounds.upper);
    public static implicit operator Bounds1((Func<int, double> lower, Lim1 upper) bounds)
        => New(bounds.lower, bounds.upper);
    public static implicit operator Bounds1((Lim1 lower, Func<int, double> upper) bounds)
        => New(bounds.lower, bounds.upper);
    public static implicit operator Bounds1((Func<int, double> lower, Func<int, double> upper) bounds)
        => New(bounds.lower, bounds.upper);
    public static implicit operator Bounds1((Func<int, int> lower, Lim1 upper) bounds)
        => New(bounds.lower, bounds.upper);
    public static implicit operator Bounds1((Lim1 lower, Func<int, int> upper) bounds)
        => New(bounds.lower, bounds.upper);
    public static implicit operator Bounds1((Func<int, int> lower, Func<int, int> upper) bounds)
        => New(bounds.lower, bounds.upper);


    // const
    public static Bounds1 None
        => New(double.NegativeInfinity, double.PositiveInfinity);
    public static Bounds1 Nonneg
        => New(0.0, double.PositiveInfinity);
    public static Bounds1 Nonpos
        => New(double.NegativeInfinity, 0.0);
    public static Bounds1 ZeroOne
        => New(0.0, 1.0);


    // method
    internal bool IsContant
        => Lower.IsContant && Upper.IsContant;
    internal bool IsConstantlyNonneg
        => Lower.ConstantlyEqualTo(0.0) && Upper.IsConstantlyPosInf();
}
