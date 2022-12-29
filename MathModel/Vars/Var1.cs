using MathProg.DefaultKeys;

namespace MathProg;

public record Var1(
    string Key,
    VarType VarType,
    Set I1,
    Bounds1 Bounds) : IVar
{
    // ctor
    public Var1(VarType varType, Set i1, Bounds1 bounds)
        : this(DefaultVarKeys.Get(), varType, i1, bounds)
    {
    }


    // ctor - key
    public static Var1 Bin(string key, Set i1)
        => new(key, VarType.Binary, i1, Bounds1.ZeroOne);
    public static Var1 Cont(string key, Set i1, Bounds1 bounds)
        => new(key, VarType.Continuous, i1, bounds);
    public static Var1 Ubdd(string key, Set i1)
        => new(key, VarType.Continuous, i1, Bounds1.None);
    public static Var1 Nonneg(string key, Set i1)
        => new(key, VarType.Continuous, i1, Bounds1.Nonneg);
    public static Var1 Nonpos(string key, Set i1)
        => new(key, VarType.Continuous, i1, Bounds1.Nonpos);
    public static Var1 Disc(string key, Set i1, Bounds1 bounds)
        => new(key, VarType.Integer, i1, bounds);
    public static Var1 DiscUbdd(string key, Set i1)
            => new(key, VarType.Integer, i1, Bounds1.None);
    public static Var1 DiscNonneg(string key, Set i1)
        => new(key, VarType.Integer, i1, Bounds1.Nonneg);
    public static Var1 DiscNonpos(string key, Set i1)
        => new(key, VarType.Integer, i1, Bounds1.Nonpos);

    // ctor - default
    public static Var1 Bin(Set i1)
        => Bin(DefaultVarKeys.Get(), i1);
    public static Var1 Cont(Set i1, Bounds1 bounds)
        => Cont(DefaultVarKeys.Get(), i1, bounds);
    public static Var1 Ubdd(Set i1)
        => Ubdd(DefaultVarKeys.Get(), i1);
    public static Var1 Nonneg(Set i1)
        => Nonneg(DefaultVarKeys.Get(), i1);
    public static Var1 Nonpos(Set i1)
        => Nonpos(DefaultVarKeys.Get(), i1);
    public static Var1 Disc(Set i1, Bounds1 bounds)
        => Disc(DefaultVarKeys.Get(), i1, bounds);
    public static Var1 DiscUbdd(Set i1)
        => DiscUbdd(DefaultVarKeys.Get(), i1);
    public static Var1 DiscNonneg(Set i1)
        => DiscNonneg(DefaultVarKeys.Get(), i1);
    public static Var1 DiscNonpos(Set i1)
        => DiscNonpos(DefaultVarKeys.Get(), i1);


    // method
    public Var this[Sca i]
        => new(this, i);
    public int Dim => 1;
    bool IVar.HasContantBounds
        => Bounds.IsContant;
    bool IVar.IsConstantlyNonneg
        => Bounds.IsConstantlyNonneg;


    // soln
    internal double[] EmptySoln()
        => new double[I1.GetGen()(Array.Empty<int>()).Count()];
}
