using MathProg.DefaultKeys;

namespace MathProg;

public record Var4(
    string Key,
    VarType VarType,
    (Set I1, Set I2, Set I3, Set I4) Indices,
    Bounds4 Bounds) : IVar
{
    // ctor
    public Var4(VarType varType, (Set I1, Set I2, Set I3, Set I4) indices, Bounds4 bounds4)
        : this(DefaultVarKeys.Get(), varType, indices, bounds4)
    {
    }


    // ctor - key
    public static Var4 Bin(string key, (Set I1, Set I2, Set I3, Set I4) indices)
        => new(key, VarType.Binary, indices, Bounds4.ZeroOne);
    public static Var4 Cont(string key, (Set I1, Set I2, Set I3, Set I4) indices, Bounds4 bounds)
        => new(key, VarType.Continuous, indices, bounds);
    public static Var4 Ubdd(string key, (Set I1, Set I2, Set I3, Set I4) indices)
        => new(key, VarType.Continuous, indices, Bounds4.None);
    public static Var4 Nonneg(string key, (Set I1, Set I2, Set I3, Set I4) indices)
        => new(key, VarType.Continuous, indices, Bounds4.Nonneg);
    public static Var4 Nonpos(string key, (Set I1, Set I2, Set I3, Set I4) indices)
        => new(key, VarType.Continuous, indices, Bounds4.Nonpos);
    public static Var4 Disc(string key, (Set I1, Set I2, Set I3, Set I4) indices, Bounds4 bounds)
        => new(key, VarType.Integer, indices, bounds);
    public static Var4 DiscUbdd(string key, (Set I1, Set I2, Set I3, Set I4) indices)
            => new(key, VarType.Integer, indices, Bounds4.None);
    public static Var4 DiscNonneg(string key, (Set I1, Set I2, Set I3, Set I4) indices)
        => new(key, VarType.Integer, indices, Bounds4.Nonneg);
    public static Var4 DiscNonpos(string key, (Set I1, Set I2, Set I3, Set I4) indices)
        => new(key, VarType.Integer, indices, Bounds4.Nonpos);

    // ctor - default
    public static Var4 Bin((Set I1, Set I2, Set I3, Set I4) indices)
        => Bin(DefaultVarKeys.Get(), indices);
    public static Var4 Cont((Set I1, Set I2, Set I3, Set I4) indices, Bounds4 bounds)
        => Cont(DefaultVarKeys.Get(), indices, bounds);
    public static Var4 Ubdd((Set I1, Set I2, Set I3, Set I4) indices)
        => Ubdd(DefaultVarKeys.Get(), indices);
    public static Var4 Nonneg((Set I1, Set I2, Set I3, Set I4) indices)
        => Nonneg(DefaultVarKeys.Get(), indices);
    public static Var4 Nonpos((Set I1, Set I2, Set I3, Set I4) indices)
        => Nonpos(DefaultVarKeys.Get(), indices);
    public static Var4 Disc((Set I1, Set I2, Set I3, Set I4) indices, Bounds4 bounds)
        => Disc(DefaultVarKeys.Get(), indices, bounds);
    public static Var4 DiscUbdd((Set I1, Set I2, Set I3, Set I4) indices)
        => DiscUbdd(DefaultVarKeys.Get(), indices);
    public static Var4 DiscNonneg((Set I1, Set I2, Set I3, Set I4) indices)
        => DiscNonneg(DefaultVarKeys.Get(), indices);
    public static Var4 DiscNonpos((Set I1, Set I2, Set I3, Set I4) indices)
        => DiscNonpos(DefaultVarKeys.Get(), indices);


    // method
    public Var this[Sca i, Sca j, Sca k, Sca l]
        => new(this, new OptList<Sca>(new List<Sca>(4) { i, j, k, l }));
    public int Dim => 4;
    bool IVar.HasContantBounds
        => Bounds.IsContant;
    bool IVar.IsConstantlyNonneg
        => Bounds.IsConstantlyNonneg;
}
