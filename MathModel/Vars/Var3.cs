using MathProg.DefaultKeys;

namespace MathProg;

public record Var3(
    string Key,
    VarType VarType,
    (Set I1, Set I2, Set I3) Indices,
    Bounds3 Bounds) : IVar
{
    // ctor
    public Var3(VarType varType, (Set I1, Set I2, Set I3) indices, Bounds3 bounds3)
        : this(DefaultVarKeys.Get(), varType, indices, bounds3)
    {
    }


    // ctor - key
    public static Var3 Bin(string key, (Set I1, Set I2, Set I3) indices)
        => new(key, VarType.Binary, indices, Bounds3.ZeroOne);
    public static Var3 Cont(string key, (Set I1, Set I2, Set I3) indices, Bounds3 bounds)
        => new(key, VarType.Continuous, indices, bounds);
    public static Var3 Ubdd(string key, (Set I1, Set I2, Set I3) indices)
        => new(key, VarType.Continuous, indices, Bounds3.None);
    public static Var3 Nonneg(string key, (Set I1, Set I2, Set I3) indices)
        => new(key, VarType.Continuous, indices, Bounds3.Nonneg);
    public static Var3 Nonpos(string key, (Set I1, Set I2, Set I3) indices)
        => new(key, VarType.Continuous, indices, Bounds3.Nonpos);
    public static Var3 Disc(string key, (Set I1, Set I2, Set I3) indices, Bounds3 bounds)
        => new(key, VarType.Integer, indices, bounds);
    public static Var3 DiscUbdd(string key, (Set I1, Set I2, Set I3) indices)
            => new(key, VarType.Integer, indices, Bounds3.None);
    public static Var3 DiscNonneg(string key, (Set I1, Set I2, Set I3) indices)
        => new(key, VarType.Integer, indices, Bounds3.Nonneg);
    public static Var3 DiscNonpos(string key, (Set I1, Set I2, Set I3) indices)
        => new(key, VarType.Integer, indices, Bounds3.Nonpos);

    // ctor - default
    public static Var3 Bin((Set I1, Set I2, Set I3) indices)
        => Bin(DefaultVarKeys.Get(), indices);
    public static Var3 Cont((Set I1, Set I2, Set I3) indices, Bounds3 bounds)
        => Cont(DefaultVarKeys.Get(), indices, bounds);
    public static Var3 Ubdd((Set I1, Set I2, Set I3) indices)
        => Ubdd(DefaultVarKeys.Get(), indices);
    public static Var3 Nonneg((Set I1, Set I2, Set I3) indices)
        => Nonneg(DefaultVarKeys.Get(), indices);
    public static Var3 Nonpos((Set I1, Set I2, Set I3) indices)
        => Nonpos(DefaultVarKeys.Get(), indices);
    public static Var3 Disc((Set I1, Set I2, Set I3) indices, Bounds3 bounds)
        => Disc(DefaultVarKeys.Get(), indices, bounds);
    public static Var3 DiscUbdd((Set I1, Set I2, Set I3) indices)
        => DiscUbdd(DefaultVarKeys.Get(), indices);
    public static Var3 DiscNonneg((Set I1, Set I2, Set I3) indices)
        => DiscNonneg(DefaultVarKeys.Get(), indices);
    public static Var3 DiscNonpos((Set I1, Set I2, Set I3) indices)
        => DiscNonpos(DefaultVarKeys.Get(), indices);


    // method
    public Var this[Sca i, Sca j, Sca k]
        => new(this, new OptList<Sca>(new List<Sca>(3) { i, j, k }));
    public int Dim => 3;
    bool IVar.HasContantBounds
        => Bounds.IsContant;
    bool IVar.IsConstantlyNonneg
        => Bounds.IsConstantlyNonneg;


    // soln
    internal double[][][] EmptySoln()
    {
        Indices indices = new(new OptList<Set>(new List<Set>() { Indices.I1, Indices.I2, Indices.I3 }));
        var state = new int[indices.Length];

        var gen1 = Indices.I1.GetGen()(Array.Empty<int>());
        int l1 = gen1.Count();
        var soln = new double[l1][][];
        int ind1 = 0;
        foreach (var i1 in gen1)
        {
            state[0] = i1;
            Indices.I2.SetIndices(indices);
            var gen2 = Indices.I2.GetGen()(state);
            int l2 = gen2.Count();
            soln[ind1] = new double[l2][];
            int ind2 = 0;
            foreach (var i2 in gen2)
            {
                state[1] = i2;
                Indices.I3.SetIndices(indices);
                var gen3 = Indices.I2.GetGen()(state);
                int l3 = gen3.Count();
                soln[ind1][ind2] = new double[l3];
                ind2++;
            }
            ind1++;
        }

        return soln;
    }
}
