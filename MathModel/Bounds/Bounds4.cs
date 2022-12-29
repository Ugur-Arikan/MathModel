namespace MathProg;

public record struct Bounds4(Lim4 Lower, Lim4 Upper) : IBounds
{
    // ctor
    public static Bounds4 New(Lim4 lower, Lim4 upper)
        => new(lower, upper);
    public static Bounds4 New(Func<int, int, int, int, double> lower, Lim4 upper)
        => new(lower, upper);
    public static Bounds4 New(Lim4 lower, Func<int, int, int, int, double> upper)
        => new(lower, upper);
    public static Bounds4 New(Func<int, int, int, int, double> lower, Func<int, int, int, int, double> upper)
        => new(lower, upper);
    public static Bounds4 New(Func<int, int, int, int, int> lower, Lim4 upper)
        => New((i, j, k, l) => (double)lower(i, j, k, l), upper);
    public static Bounds4 New(Lim4 lower, Func<int, int, int, int, int> upper)
        => New(lower, (i, j, k, l) => (double)upper(i, j, k, l));
    public static Bounds4 New(Func<int, int, int, int, int> lower, Func<int, int, int, int, int> upper)
        => New((i, j, k, l) => (double)lower(i, j, k, l), (i, j, k, l) => upper(i, j, k, l));


    // implicit
    public static implicit operator Bounds4((Lim4 lower, Lim4 upper) bounds)
        => New(bounds.lower, bounds.upper);
    public static implicit operator Bounds4((Func<int, int, int, int, double> lower, Lim4 upper) bounds)
        => New(bounds.lower, bounds.upper);
    public static implicit operator Bounds4((Lim4 lower, Func<int, int, int, int, double> upper) bounds)
        => New(bounds.lower, bounds.upper);
    public static implicit operator Bounds4((Func<int, int, int, int, double> lower, Func<int, int, int, int, double> upper) bounds)
        => New(bounds.lower, bounds.upper);
    public static implicit operator Bounds4((Func<int, int, int, int, int> lower, Lim4 upper) bounds)
        => New(bounds.lower, bounds.upper);
    public static implicit operator Bounds4((Lim4 lower, Func<int, int, int, int, int> upper) bounds)
        => New(bounds.lower, bounds.upper);
    public static implicit operator Bounds4((Func<int, int, int, int, int> lower, Func<int, int, int, int, int> upper) bounds)
        => New(bounds.lower, bounds.upper);


    // const
    public static Bounds4 None
        => New(double.NegativeInfinity, double.PositiveInfinity);
    public static Bounds4 Nonneg
        => New(0.0, double.PositiveInfinity);
    public static Bounds4 Nonpos
        => New(double.NegativeInfinity, 0.0);
    public static Bounds4 ZeroOne
        => New(0.0, 1.0);


    // method
    internal bool IsContant
        => Lower.IsContant && Upper.IsContant;
    internal bool IsConstantlyNonneg
        => Lower.ConstantlyEqualTo(0.0) && Upper.IsConstantlyPosInf();
}
