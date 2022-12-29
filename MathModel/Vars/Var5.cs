using MathProg.DefaultKeys;

namespace MathProg;

public record Var5(
    string Key,
    VarType VarType,
    (Set I1, Set I2, Set I3, Set I4, Set I5) Indices,
    Bounds5 Bounds) : IVar
{
    // ctor
    public Var5(VarType varType, (Set I1, Set I2, Set I3, Set I4, Set I5) indices, Bounds5 bounds5)
        : this(DefaultVarKeys.Get(), varType, indices, bounds5)
    {
    }


    // ctor - key
    public static Var5 Bin(string key, (Set I1, Set I2, Set I3, Set I4, Set I5) indices)
        => new(key, VarType.Binary, indices, Bounds5.ZeroOne);
    public static Var5 Cont(string key, (Set I1, Set I2, Set I3, Set I4, Set I5) indices, Bounds5 bounds)
        => new(key, VarType.Continuous, indices, bounds);
    public static Var5 Ubdd(string key, (Set I1, Set I2, Set I3, Set I4, Set I5) indices)
        => new(key, VarType.Continuous, indices, Bounds5.None);
    public static Var5 Nonneg(string key, (Set I1, Set I2, Set I3, Set I4, Set I5) indices)
        => new(key, VarType.Continuous, indices, Bounds5.Nonneg);
    public static Var5 Nonpos(string key, (Set I1, Set I2, Set I3, Set I4, Set I5) indices)
        => new(key, VarType.Continuous, indices, Bounds5.Nonpos);
    public static Var5 Disc(string key, (Set I1, Set I2, Set I3, Set I4, Set I5) indices, Bounds5 bounds)
        => new(key, VarType.Integer, indices, bounds);
    public static Var5 DiscUbdd(string key, (Set I1, Set I2, Set I3, Set I4, Set I5) indices)
            => new(key, VarType.Integer, indices, Bounds5.None);
    public static Var5 DiscNonneg(string key, (Set I1, Set I2, Set I3, Set I4, Set I5) indices)
        => new(key, VarType.Integer, indices, Bounds5.Nonneg);
    public static Var5 DiscNonpos(string key, (Set I1, Set I2, Set I3, Set I4, Set I5) indices)
        => new(key, VarType.Integer, indices, Bounds5.Nonpos);

    // ctor - default
    public static Var5 Bin((Set I1, Set I2, Set I3, Set I4, Set I5) indices)
        => Bin(DefaultVarKeys.Get(), indices);
    public static Var5 Cont((Set I1, Set I2, Set I3, Set I4, Set I5) indices, Bounds5 bounds)
        => Cont(DefaultVarKeys.Get(), indices, bounds);
    public static Var5 Ubdd((Set I1, Set I2, Set I3, Set I4, Set I5) indices)
        => Ubdd(DefaultVarKeys.Get(), indices);
    public static Var5 Nonneg((Set I1, Set I2, Set I3, Set I4, Set I5) indices)
        => Nonneg(DefaultVarKeys.Get(), indices);
    public static Var5 Nonpos((Set I1, Set I2, Set I3, Set I4, Set I5) indices)
        => Nonpos(DefaultVarKeys.Get(), indices);
    public static Var5 Disc((Set I1, Set I2, Set I3, Set I4, Set I5) indices, Bounds5 bounds)
        => Disc(DefaultVarKeys.Get(), indices, bounds);
    public static Var5 DiscUbdd((Set I1, Set I2, Set I3, Set I4, Set I5) indices)
        => DiscUbdd(DefaultVarKeys.Get(), indices);
    public static Var5 DiscNonneg((Set I1, Set I2, Set I3, Set I4, Set I5) indices)
        => DiscNonneg(DefaultVarKeys.Get(), indices);
    public static Var5 DiscNonpos((Set I1, Set I2, Set I3, Set I4, Set I5) indices)
        => DiscNonpos(DefaultVarKeys.Get(), indices);


    // method
    public Var this[Sca i, Sca j, Sca k, Sca l, Sca m]
        => new(this, new OptList<Sca>(new List<Sca>(5) { i, j, k, l, m }));
    public int Dim => 5;
    bool IVar.HasContantBounds
        => Bounds.IsContant;
    bool IVar.IsConstantlyNonneg
        => Bounds.IsConstantlyNonneg;
}
