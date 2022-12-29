using MathProg.DefaultKeys;

namespace MathProg;

public record Var7(
    string Key,
    VarType VarType,
    (Set I1, Set I2, Set I3, Set I4, Set I5, Set I6, Set I7) Indices,
    Bounds7 Bounds) : IVar
{
    // ctor
    public Var7(VarType varType, (Set I1, Set I2, Set I3, Set I4, Set I5, Set I6, Set I7) indices, Bounds7 bounds7)
        : this(DefaultVarKeys.Get(), varType, indices, bounds7)
    {
    }


    // ctor - key
    public static Var7 Bin(string key, (Set I1, Set I2, Set I3, Set I4, Set I5, Set I6, Set I7) indices)
        => new(key, VarType.Binary, indices, Bounds7.ZeroOne);
    public static Var7 Cont(string key, (Set I1, Set I2, Set I3, Set I4, Set I5, Set I6, Set I7) indices, Bounds7 bounds)
        => new(key, VarType.Continuous, indices, bounds);
    public static Var7 Ubdd(string key, (Set I1, Set I2, Set I3, Set I4, Set I5, Set I6, Set I7) indices)
        => new(key, VarType.Continuous, indices, Bounds7.None);
    public static Var7 Nonneg(string key, (Set I1, Set I2, Set I3, Set I4, Set I5, Set I6, Set I7) indices)
        => new(key, VarType.Continuous, indices, Bounds7.Nonneg);
    public static Var7 Nonpos(string key, (Set I1, Set I2, Set I3, Set I4, Set I5, Set I6, Set I7) indices)
        => new(key, VarType.Continuous, indices, Bounds7.Nonpos);
    public static Var7 Disc(string key, (Set I1, Set I2, Set I3, Set I4, Set I5, Set I6, Set I7) indices, Bounds7 bounds)
        => new(key, VarType.Integer, indices, bounds);
    public static Var7 DiscUbdd(string key, (Set I1, Set I2, Set I3, Set I4, Set I5, Set I6, Set I7) indices)
            => new(key, VarType.Integer, indices, Bounds7.None);
    public static Var7 DiscNonneg(string key, (Set I1, Set I2, Set I3, Set I4, Set I5, Set I6, Set I7) indices)
        => new(key, VarType.Integer, indices, Bounds7.Nonneg);
    public static Var7 DiscNonpos(string key, (Set I1, Set I2, Set I3, Set I4, Set I5, Set I6, Set I7) indices)
        => new(key, VarType.Integer, indices, Bounds7.Nonpos);

    // ctor - default
    public static Var7 Bin((Set I1, Set I2, Set I3, Set I4, Set I5, Set I6, Set I7) indices)
        => Bin(DefaultVarKeys.Get(), indices);
    public static Var7 Cont((Set I1, Set I2, Set I3, Set I4, Set I5, Set I6, Set I7) indices, Bounds7 bounds)
        => Cont(DefaultVarKeys.Get(), indices, bounds);
    public static Var7 Ubdd((Set I1, Set I2, Set I3, Set I4, Set I5, Set I6, Set I7) indices)
        => Ubdd(DefaultVarKeys.Get(), indices);
    public static Var7 Nonneg((Set I1, Set I2, Set I3, Set I4, Set I5, Set I6, Set I7) indices)
        => Nonneg(DefaultVarKeys.Get(), indices);
    public static Var7 Nonpos((Set I1, Set I2, Set I3, Set I4, Set I5, Set I6, Set I7) indices)
        => Nonpos(DefaultVarKeys.Get(), indices);
    public static Var7 Disc((Set I1, Set I2, Set I3, Set I4, Set I5, Set I6, Set I7) indices, Bounds7 bounds)
        => Disc(DefaultVarKeys.Get(), indices, bounds);
    public static Var7 DiscUbdd((Set I1, Set I2, Set I3, Set I4, Set I5, Set I6, Set I7) indices)
        => DiscUbdd(DefaultVarKeys.Get(), indices);
    public static Var7 DiscNonneg((Set I1, Set I2, Set I3, Set I4, Set I5, Set I6, Set I7) indices)
        => DiscNonneg(DefaultVarKeys.Get(), indices);
    public static Var7 DiscNonpos((Set I1, Set I2, Set I3, Set I4, Set I5, Set I6, Set I7) indices)
        => DiscNonpos(DefaultVarKeys.Get(), indices);


    // method
    public Var this[Sca i, Sca j, Sca k, Sca l, Sca m, Sca n, Sca o]
        => new(this, new OptList<Sca>(new List<Sca>(7) { i, j, k, l, m, n, o }));
    public int Dim => 7;
    bool IVar.HasContantBounds
        => Bounds.IsContant;
    bool IVar.IsConstantlyNonneg
        => Bounds.IsConstantlyNonneg;
}
