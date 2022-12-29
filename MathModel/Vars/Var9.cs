using MathProg.DefaultKeys;

namespace MathProg;

public record Var9(
    string Key,
    VarType VarType,
    (Set I1, Set I2, Set I3, Set I4, Set I5, Set I6, Set I7, Set I8, Set I9) Indices,
    Bounds9 Bounds) : IVar
{
    // ctor
    public Var9(VarType varType, (Set I1, Set I2, Set I3, Set I4, Set I5, Set I6, Set I7, Set I8, Set I9) indices, Bounds9 bounds9)
        : this(DefaultVarKeys.Get(), varType, indices, bounds9)
    {
    }


    // ctor - key
    public static Var9 Bin(string key, (Set I1, Set I2, Set I3, Set I4, Set I5, Set I6, Set I7, Set I8, Set I9) indices)
        => new(key, VarType.Binary, indices, Bounds9.ZeroOne);
    public static Var9 Cont(string key, (Set I1, Set I2, Set I3, Set I4, Set I5, Set I6, Set I7, Set I8, Set I9) indices, Bounds9 bounds)
        => new(key, VarType.Continuous, indices, bounds);
    public static Var9 Ubdd(string key, (Set I1, Set I2, Set I3, Set I4, Set I5, Set I6, Set I7, Set I8, Set I9) indices)
        => new(key, VarType.Continuous, indices, Bounds9.None);
    public static Var9 Nonneg(string key, (Set I1, Set I2, Set I3, Set I4, Set I5, Set I6, Set I7, Set I8, Set I9) indices)
        => new(key, VarType.Continuous, indices, Bounds9.Nonneg);
    public static Var9 Nonpos(string key, (Set I1, Set I2, Set I3, Set I4, Set I5, Set I6, Set I7, Set I8, Set I9) indices)
        => new(key, VarType.Continuous, indices, Bounds9.Nonpos);
    public static Var9 Disc(string key, (Set I1, Set I2, Set I3, Set I4, Set I5, Set I6, Set I7, Set I8, Set I9) indices, Bounds9 bounds)
        => new(key, VarType.Integer, indices, bounds);
    public static Var9 DiscUbdd(string key, (Set I1, Set I2, Set I3, Set I4, Set I5, Set I6, Set I7, Set I8, Set I9) indices)
            => new(key, VarType.Integer, indices, Bounds9.None);
    public static Var9 DiscNonneg(string key, (Set I1, Set I2, Set I3, Set I4, Set I5, Set I6, Set I7, Set I8, Set I9) indices)
        => new(key, VarType.Integer, indices, Bounds9.Nonneg);
    public static Var9 DiscNonpos(string key, (Set I1, Set I2, Set I3, Set I4, Set I5, Set I6, Set I7, Set I8, Set I9) indices)
        => new(key, VarType.Integer, indices, Bounds9.Nonpos);


    // ctor - default
    public static Var9 Bin((Set I1, Set I2, Set I3, Set I4, Set I5, Set I6, Set I7, Set I8, Set I9) indices)
        => Bin(DefaultVarKeys.Get(), indices);
    public static Var9 Cont((Set I1, Set I2, Set I3, Set I4, Set I5, Set I6, Set I7, Set I8, Set I9) indices, Bounds9 bounds)
        => Cont(DefaultVarKeys.Get(), indices, bounds);
    public static Var9 Ubdd((Set I1, Set I2, Set I3, Set I4, Set I5, Set I6, Set I7, Set I8, Set I9) indices)
        => Ubdd(DefaultVarKeys.Get(), indices);
    public static Var9 Nonneg((Set I1, Set I2, Set I3, Set I4, Set I5, Set I6, Set I7, Set I8, Set I9) indices)
        => Nonneg(DefaultVarKeys.Get(), indices);
    public static Var9 Nonpos((Set I1, Set I2, Set I3, Set I4, Set I5, Set I6, Set I7, Set I8, Set I9) indices)
        => Nonpos(DefaultVarKeys.Get(), indices);
    public static Var9 Disc((Set I1, Set I2, Set I3, Set I4, Set I5, Set I6, Set I7, Set I8, Set I9) indices, Bounds9 bounds)
        => Disc(DefaultVarKeys.Get(), indices, bounds);
    public static Var9 DiscUbdd((Set I1, Set I2, Set I3, Set I4, Set I5, Set I6, Set I7, Set I8, Set I9) indices)
        => DiscUbdd(DefaultVarKeys.Get(), indices);
    public static Var9 DiscNonneg((Set I1, Set I2, Set I3, Set I4, Set I5, Set I6, Set I7, Set I8, Set I9) indices)
        => DiscNonneg(DefaultVarKeys.Get(), indices);
    public static Var9 DiscNonpos((Set I1, Set I2, Set I3, Set I4, Set I5, Set I6, Set I7, Set I8, Set I9) indices)
        => DiscNonpos(DefaultVarKeys.Get(), indices);


    // method
    public Var this[Sca i, Sca j, Sca k, Sca l, Sca m, Sca n, Sca o, Sca p, Sca q]
        => new(this, new OptList<Sca>(new List<Sca>(9) { i, j, k, l, m, n, o, p, q }));
    public int Dim => 9;
    bool IVar.HasContantBounds
        => Bounds.IsContant;
    bool IVar.IsConstantlyNonneg
        => Bounds.IsConstantlyNonneg;
}
