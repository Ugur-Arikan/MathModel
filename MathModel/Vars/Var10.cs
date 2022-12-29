using MathProg.DefaultKeys;

namespace MathProg;

public record Var10(
    string Key,
    VarType VarType,
    (Set I1, Set I2, Set I3, Set I4, Set I5, Set I6, Set I7, Set I8, Set I9, Set I10) Indices,
    Bounds10 Bounds) : IVar
{
    // ctor
    public Var10(VarType varType, (Set I1, Set I2, Set I3, Set I4, Set I5, Set I6, Set I7, Set I8, Set I9, Set I10) indices, Bounds10 bounds10)
        : this(DefaultVarKeys.Get(), varType, indices, bounds10)
    {
    }


    // ctor - key
    public static Var10 Bin(string key, (Set I1, Set I2, Set I3, Set I4, Set I5, Set I6, Set I7, Set I8, Set I9, Set I10) indices)
        => new(key, VarType.Binary, indices, Bounds10.ZeroOne);
    public static Var10 Cont(string key, (Set I1, Set I2, Set I3, Set I4, Set I5, Set I6, Set I7, Set I8, Set I9, Set I10) indices, Bounds10 bounds)
        => new(key, VarType.Continuous, indices, bounds);
    public static Var10 Ubdd(string key, (Set I1, Set I2, Set I3, Set I4, Set I5, Set I6, Set I7, Set I8, Set I9, Set I10) indices)
        => new(key, VarType.Continuous, indices, Bounds10.None);
    public static Var10 Nonneg(string key, (Set I1, Set I2, Set I3, Set I4, Set I5, Set I6, Set I7, Set I8, Set I9, Set I10) indices)
        => new(key, VarType.Continuous, indices, Bounds10.Nonneg);
    public static Var10 Nonpos(string key, (Set I1, Set I2, Set I3, Set I4, Set I5, Set I6, Set I7, Set I8, Set I9, Set I10) indices)
        => new(key, VarType.Continuous, indices, Bounds10.Nonpos);
    public static Var10 Disc(string key, (Set I1, Set I2, Set I3, Set I4, Set I5, Set I6, Set I7, Set I8, Set I9, Set I10) indices, Bounds10 bounds)
        => new(key, VarType.Integer, indices, bounds);
    public static Var10 DiscUbdd(string key, (Set I1, Set I2, Set I3, Set I4, Set I5, Set I6, Set I7, Set I8, Set I9, Set I10) indices)
            => new(key, VarType.Integer, indices, Bounds10.None);
    public static Var10 DiscNonneg(string key, (Set I1, Set I2, Set I3, Set I4, Set I5, Set I6, Set I7, Set I8, Set I9, Set I10) indices)
        => new(key, VarType.Integer, indices, Bounds10.Nonneg);
    public static Var10 DiscNonpos(string key, (Set I1, Set I2, Set I3, Set I4, Set I5, Set I6, Set I7, Set I8, Set I9, Set I10) indices)
        => new(key, VarType.Integer, indices, Bounds10.Nonpos);

    // ctor - default
    public static Var10 Bin((Set I1, Set I2, Set I3, Set I4, Set I5, Set I6, Set I7, Set I8, Set I9, Set I10) indices)
        => Bin(DefaultVarKeys.Get(), indices);
    public static Var10 Cont(Bounds10 bounds, (Set I1, Set I2, Set I3, Set I4, Set I5, Set I6, Set I7, Set I8, Set I9, Set I10) indices)
        => Cont(DefaultVarKeys.Get(), indices, bounds);
    public static Var10 Ubdd((Set I1, Set I2, Set I3, Set I4, Set I5, Set I6, Set I7, Set I8, Set I9, Set I10) indices)
        => Ubdd(DefaultVarKeys.Get(), indices);
    public static Var10 Nonneg((Set I1, Set I2, Set I3, Set I4, Set I5, Set I6, Set I7, Set I8, Set I9, Set I10) indices)
        => Nonneg(DefaultVarKeys.Get(), indices);
    public static Var10 Nonpos((Set I1, Set I2, Set I3, Set I4, Set I5, Set I6, Set I7, Set I8, Set I9, Set I10) indices)
        => Nonpos(DefaultVarKeys.Get(), indices);
    public static Var10 Disc(Bounds10 bounds, (Set I1, Set I2, Set I3, Set I4, Set I5, Set I6, Set I7, Set I8, Set I9, Set I10) indices)
        => Disc(DefaultVarKeys.Get(), indices, bounds);
    public static Var10 DiscUbdd((Set I1, Set I2, Set I3, Set I4, Set I5, Set I6, Set I7, Set I8, Set I9, Set I10) indices)
        => DiscUbdd(DefaultVarKeys.Get(), indices);
    public static Var10 DiscNonneg((Set I1, Set I2, Set I3, Set I4, Set I5, Set I6, Set I7, Set I8, Set I9, Set I10) indices)
        => DiscNonneg(DefaultVarKeys.Get(), indices);
    public static Var10 DiscNonpos((Set I1, Set I2, Set I3, Set I4, Set I5, Set I6, Set I7, Set I8, Set I9, Set I10) indices)
        => DiscNonpos(DefaultVarKeys.Get(), indices);


    // method
    public Var this[Sca i, Sca j, Sca k, Sca l, Sca m, Sca n, Sca o, Sca p, Sca q, Sca r]
        => new(this, new OptList<Sca>(new List<Sca>(10) { i, j, k, l, m, n, o, p, q, r }));
    public int Dim => 10;
    bool IVar.HasContantBounds
        => Bounds.IsContant;
    bool IVar.IsConstantlyNonneg
        => Bounds.IsConstantlyNonneg;
}
