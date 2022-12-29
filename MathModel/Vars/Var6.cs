using MathProg.DefaultKeys;

namespace MathProg;

public record Var6(
    string Key,
    VarType VarType,
    (Set I1, Set I2, Set I3, Set I4, Set I5, Set I6) Indices,
    Bounds6 Bounds) : IVar
{
    // ctor
    public Var6(VarType varType, (Set I1, Set I2, Set I3, Set I4, Set I5, Set I6) indices, Bounds6 bounds6)
        : this(DefaultVarKeys.Get(), varType, indices, bounds6)
    {
    }


    // ctor - key
    public static Var6 Bin(string key, (Set I1, Set I2, Set I3, Set I4, Set I5, Set I6) indices)
        => new(key, VarType.Binary, indices, Bounds6.ZeroOne);
    public static Var6 Cont(string key, (Set I1, Set I2, Set I3, Set I4, Set I5, Set I6) indices, Bounds6 bounds)
        => new(key, VarType.Continuous, indices, bounds);
    public static Var6 Ubdd(string key, (Set I1, Set I2, Set I3, Set I4, Set I5, Set I6) indices)
        => new(key, VarType.Continuous, indices, Bounds6.None);
    public static Var6 Nonneg(string key, (Set I1, Set I2, Set I3, Set I4, Set I5, Set I6) indices)
        => new(key, VarType.Continuous, indices, Bounds6.Nonneg);
    public static Var6 Nonpos(string key, (Set I1, Set I2, Set I3, Set I4, Set I5, Set I6) indices)
        => new(key, VarType.Continuous, indices, Bounds6.Nonpos);
    public static Var6 Disc(string key, (Set I1, Set I2, Set I3, Set I4, Set I5, Set I6) indices, Bounds6 bounds)
        => new(key, VarType.Integer, indices, bounds);
    public static Var6 DiscUbdd(string key, (Set I1, Set I2, Set I3, Set I4, Set I5, Set I6) indices)
            => new(key, VarType.Integer, indices, Bounds6.None);
    public static Var6 DiscNonneg(string key, (Set I1, Set I2, Set I3, Set I4, Set I5, Set I6) indices)
        => new(key, VarType.Integer, indices, Bounds6.Nonneg);
    public static Var6 DiscNonpos(string key, (Set I1, Set I2, Set I3, Set I4, Set I5, Set I6) indices)
        => new(key, VarType.Integer, indices, Bounds6.Nonpos);

    // ctor - default
    public static Var6 Bin((Set I1, Set I2, Set I3, Set I4, Set I5, Set I6) indices)
        => Bin(DefaultVarKeys.Get(), indices);
    public static Var6 Cont((Set I1, Set I2, Set I3, Set I4, Set I5, Set I6) indices, Bounds6 bounds)
        => Cont(DefaultVarKeys.Get(), indices, bounds);
    public static Var6 Ubdd((Set I1, Set I2, Set I3, Set I4, Set I5, Set I6) indices)
        => Ubdd(DefaultVarKeys.Get(), indices);
    public static Var6 Nonneg((Set I1, Set I2, Set I3, Set I4, Set I5, Set I6) indices)
        => Nonneg(DefaultVarKeys.Get(), indices);
    public static Var6 Nonpos((Set I1, Set I2, Set I3, Set I4, Set I5, Set I6) indices)
        => Nonpos(DefaultVarKeys.Get(), indices);
    public static Var6 Disc((Set I1, Set I2, Set I3, Set I4, Set I5, Set I6) indices, Bounds6 bounds)
        => Disc(DefaultVarKeys.Get(), indices, bounds);
    public static Var6 DiscUbdd((Set I1, Set I2, Set I3, Set I4, Set I5, Set I6) indices)
        => DiscUbdd(DefaultVarKeys.Get(), indices);
    public static Var6 DiscNonneg((Set I1, Set I2, Set I3, Set I4, Set I5, Set I6) indices)
        => DiscNonneg(DefaultVarKeys.Get(), indices);
    public static Var6 DiscNonpos((Set I1, Set I2, Set I3, Set I4, Set I5, Set I6) indices)
        => DiscNonpos(DefaultVarKeys.Get(), indices);


    // method
    public Var this[Sca i, Sca j, Sca k, Sca l, Sca m, Sca n]
        => new(this, new OptList<Sca>(new List<Sca>(6) { i, j, k, l, m, n }));
    public int Dim => 6;
    bool IVar.HasContantBounds
        => Bounds.IsContant;
    bool IVar.IsConstantlyNonneg
        => Bounds.IsConstantlyNonneg;
}
