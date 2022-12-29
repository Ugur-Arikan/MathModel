using MathProg.DefaultKeys;

namespace MathProg;

public record Var2(
    string Key,
    VarType VarType,
    (Set I1, Set I2) Indices,
    Bounds2 Bounds) : IVar
{
    // ctor
    public Var2(VarType varType, (Set I1, Set I2) indices, Bounds2 bounds2)
        : this(DefaultVarKeys.Get(), varType, indices, bounds2)
    {
    }


    // ctor - key
    public static Var2 Bin(string key, (Set I1, Set I2) indices)
        => new(key, VarType.Binary, indices, Bounds2.ZeroOne);
    public static Var2 Cont(string key, (Set I1, Set I2) indices, Bounds2 bounds)
        => new(key, VarType.Continuous, indices, bounds);
    public static Var2 Ubdd(string key, (Set I1, Set I2) indices)
        => new(key, VarType.Continuous, indices, Bounds2.None);
    public static Var2 Nonneg(string key, (Set I1, Set I2) indices)
        => new(key, VarType.Continuous, indices, Bounds2.Nonneg);
    public static Var2 Nonpos(string key, (Set I1, Set I2) indices)
        => new(key, VarType.Continuous, indices, Bounds2.Nonpos);
    public static Var2 Disc(string key, (Set I1, Set I2) indices, Bounds2 bounds)
        => new(key, VarType.Integer, indices, bounds);
    public static Var2 DiscUbdd(string key, (Set I1, Set I2) indices)
            => new(key, VarType.Integer, indices, Bounds2.None);
    public static Var2 DiscNonneg(string key, (Set I1, Set I2) indices)
        => new(key, VarType.Integer, indices, Bounds2.Nonneg);
    public static Var2 DiscNonpos(string key, (Set I1, Set I2) indices)
        => new(key, VarType.Integer, indices, Bounds2.Nonpos);
    // ctor - default
    public static Var2 Bin((Set I1, Set I2) indices)
        => Bin(DefaultVarKeys.Get(), indices);
    public static Var2 Cont((Set I1, Set I2) indices, Bounds2 bounds)
        => Cont(DefaultVarKeys.Get(), indices, bounds);
    public static Var2 Ubdd((Set I1, Set I2) indices)
        => Ubdd(DefaultVarKeys.Get(), indices);
    public static Var2 Nonneg((Set I1, Set I2) indices)
        => Nonneg(DefaultVarKeys.Get(), indices);
    public static Var2 Nonpos((Set I1, Set I2) indices)
        => Nonpos(DefaultVarKeys.Get(), indices);
    public static Var2 Disc((Set I1, Set I2) indices, Bounds2 bounds)
        => Disc(DefaultVarKeys.Get(), indices, bounds);
    public static Var2 DiscUbdd((Set I1, Set I2) indices)
        => DiscUbdd(DefaultVarKeys.Get(), indices);
    public static Var2 DiscNonneg((Set I1, Set I2) indices)
        => DiscNonneg(DefaultVarKeys.Get(), indices);
    public static Var2 DiscNonpos((Set I1, Set I2) indices)
        => DiscNonpos(DefaultVarKeys.Get(), indices);


    // method
    public Var this[Sca i, Sca j]
        => new(this, new(i, j));
    public int Dim => 2;
    bool IVar.HasContantBounds
        => Bounds.IsContant;
    bool IVar.IsConstantlyNonneg
        => Bounds.IsConstantlyNonneg;


    // soln
    internal double[][] EmptySoln()
    {
        Indices indices = new(new OptList<Set>(Indices.I1, Indices.I2));
        var state = new int[indices.Length];
        
        var gen1 = Indices.I1.GetGen()(Array.Empty<int>());
        int l1 = gen1.Count();
        var soln = new double[l1][];
        int ind1 = 0;
        foreach (var i1 in gen1)
        {
            state[0] = i1;
            Indices.I2.SetIndices(indices);
            var gen2 = Indices.I2.GetGen()(state);
            int l2 = gen2.Count();
            soln[ind1++] = new double[l2];
        }

        return soln;
    }
}
