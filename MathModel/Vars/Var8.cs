using MathProg.DefaultKeys;

namespace MathProg;

public record Var8(
    string Key,
    VarType VarType,
    (Set I1, Set I2, Set I3, Set I4, Set I5, Set I6, Set I7, Set I8) Indices,
    Bounds8 Bounds) : IVar
{
    // ctor
    public Var8(VarType varType, (Set I1, Set I2, Set I3, Set I4, Set I5, Set I6, Set I7, Set I8) indices, Bounds8 bounds8)
        : this(DefaultVarKeys.Get(), varType, indices, bounds8)
    {
    }


    // ctor - key
    public static Var8 Bin(string key, (Set I1, Set I2, Set I3, Set I4, Set I5, Set I6, Set I7, Set I8) indices)
        => new(key, VarType.Binary, indices, Bounds8.ZeroOne);
    public static Var8 Cont(string key, (Set I1, Set I2, Set I3, Set I4, Set I5, Set I6, Set I7, Set I8) indices, Bounds8 bounds)
        => new(key, VarType.Continuous, indices, bounds);
    public static Var8 Ubdd(string key, (Set I1, Set I2, Set I3, Set I4, Set I5, Set I6, Set I7, Set I8) indices)
        => new(key, VarType.Continuous, indices, Bounds8.None);
    public static Var8 Nonneg(string key, (Set I1, Set I2, Set I3, Set I4, Set I5, Set I6, Set I7, Set I8) indices)
        => new(key, VarType.Continuous, indices, Bounds8.Nonneg);
    public static Var8 Nonpos(string key, (Set I1, Set I2, Set I3, Set I4, Set I5, Set I6, Set I7, Set I8) indices)
        => new(key, VarType.Continuous, indices, Bounds8.Nonpos);
    public static Var8 Disc(string key, (Set I1, Set I2, Set I3, Set I4, Set I5, Set I6, Set I7, Set I8) indices, Bounds8 bounds)
        => new(key, VarType.Integer, indices, bounds);
    public static Var8 DiscUbdd(string key, (Set I1, Set I2, Set I3, Set I4, Set I5, Set I6, Set I7, Set I8) indices)
            => new(key, VarType.Integer, indices, Bounds8.None);
    public static Var8 DiscNonneg(string key, (Set I1, Set I2, Set I3, Set I4, Set I5, Set I6, Set I7, Set I8) indices)
        => new(key, VarType.Integer, indices, Bounds8.Nonneg);
    public static Var8 DiscNonpos(string key, (Set I1, Set I2, Set I3, Set I4, Set I5, Set I6, Set I7, Set I8) indices)
        => new(key, VarType.Integer, indices, Bounds8.Nonpos);

    // ctor - default
    public static Var8 Bin((Set I1, Set I2, Set I3, Set I4, Set I5, Set I6, Set I7, Set I8) indices)
        => Bin(DefaultVarKeys.Get(), indices);
    public static Var8 Cont((Set I1, Set I2, Set I3, Set I4, Set I5, Set I6, Set I7, Set I8) indices, Bounds8 bounds)
        => Cont(DefaultVarKeys.Get(), indices, bounds);
    public static Var8 Ubdd((Set I1, Set I2, Set I3, Set I4, Set I5, Set I6, Set I7, Set I8) indices)
        => Ubdd(DefaultVarKeys.Get(), indices);
    public static Var8 Nonneg((Set I1, Set I2, Set I3, Set I4, Set I5, Set I6, Set I7, Set I8) indices)
        => Nonneg(DefaultVarKeys.Get(), indices);
    public static Var8 Nonpos((Set I1, Set I2, Set I3, Set I4, Set I5, Set I6, Set I7, Set I8) indices)
        => Nonpos(DefaultVarKeys.Get(), indices);
    public static Var8 Disc((Set I1, Set I2, Set I3, Set I4, Set I5, Set I6, Set I7, Set I8) indices, Bounds8 bounds)
        => Disc(DefaultVarKeys.Get(), indices, bounds);
    public static Var8 DiscUbdd((Set I1, Set I2, Set I3, Set I4, Set I5, Set I6, Set I7, Set I8) indices)
        => DiscUbdd(DefaultVarKeys.Get(), indices);
    public static Var8 DiscNonneg((Set I1, Set I2, Set I3, Set I4, Set I5, Set I6, Set I7, Set I8) indices)
        => DiscNonneg(DefaultVarKeys.Get(), indices);
    public static Var8 DiscNonpos((Set I1, Set I2, Set I3, Set I4, Set I5, Set I6, Set I7, Set I8) indices)
        => DiscNonpos(DefaultVarKeys.Get(), indices);


    // method
    public Var this[Sca i, Sca j, Sca k, Sca l, Sca m, Sca n, Sca o, Sca p]
        => new(this, new OptList<Sca>(new List<Sca>(8) { i, j, k, l, m, n, o, p }));
    public int Dim => 8;
    bool IVar.HasContantBounds
        => Bounds.IsContant;
    bool IVar.IsConstantlyNonneg
        => Bounds.IsConstantlyNonneg;
}
