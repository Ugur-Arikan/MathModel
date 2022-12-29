namespace MathProg;

public record struct Bounds0(Data0 Lower, Data0 Upper) : IBounds
{
    // ctor
    public static Bounds0 New(Data0 lower, Data0 upper)
        => new(lower, upper);
    public static Bounds0 New(Func<double> lower, Data0 upper)
        => new(lower, upper);
    public static Bounds0 New(Data0 lower, Func<double> upper)
        => new(lower, upper);
    public static Bounds0 New(Func<double> lower, Func<double> upper)
        => new(lower, upper);
    public static Bounds0 New(Func<int> lower, Data0 upper)
            => new((Func<double>)(() => lower()), upper);
    public static Bounds0 New(Data0 lower, Func<int> upper)
        => new(lower, (Func<double>)(() => upper()));
    public static Bounds0 New(Func<int> lower, Func<int> upper)
        => new((Func<double>)(() => lower()), (Func<double>)(() => upper()));
    
    
    // implicit
    public static implicit operator Bounds0((Data0 lower, Data0 upper) bounds)
        => New(bounds.lower, bounds.upper);
    public static implicit operator Bounds0((Func<double> lower, Data0 upper) bounds)
        => New(bounds.lower, bounds.upper);
    public static implicit operator Bounds0((Data0 lower, Func<double> upper) bounds)
        => New(bounds.lower, bounds.upper);
    public static implicit operator Bounds0((Func<double> lower, Func<double> upper) bounds)
        => New(bounds.lower, bounds.upper);
    public static implicit operator Bounds0((Func<int> lower, Data0 upper) bounds)
        => New(bounds.lower, bounds.upper);
    public static implicit operator Bounds0((Data0 lower, Func<int> upper) bounds)
        => New(bounds.lower, bounds.upper);
    public static implicit operator Bounds0((Func<int> lower, Func<int> upper) bounds)
        => New(bounds.lower, bounds.upper);


    // const
    public static Bounds0 None
        => New(double.NegativeInfinity, double.PositiveInfinity);
    public static Bounds0 Nonneg
        => New(0.0, double.PositiveInfinity);
    public static Bounds0 Nonpos
        => New(double.NegativeInfinity, 0.0);
    public static Bounds0 ZeroOne
        => New(0.0, 1.0);


    // method
    internal bool IsContant
        => Lower.IsContant && Upper.IsContant;
    internal bool IsConstantlyNonneg
        => Lower.ConstantlyEqualTo(0.0) && Upper.IsConstantlyPosInf();
}
