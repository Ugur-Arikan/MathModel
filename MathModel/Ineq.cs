namespace MathProg;

public record struct Ineq(ConstrRelation Relation, Expr Lhs, Expr Rhs, Expr LhsMinRhs)
{
    // ctor
    public Ineq(ConstrRelation relation, Expr lhs, Expr rhs)
        : this(relation, lhs, rhs, lhs - rhs)
    {
    }


    // method
    internal Indices SetIndices(OptList<Set> forallSets, string exprStr)
    {
        Indices allIndices = new(forallSets);
        LhsMinRhs.SetIndices(allIndices, allIndices.Clone(), exprStr);
        return allIndices;
    }


    // ops - constr
    public static Constr operator |(Set i, Ineq ineq)
        => new(ineq, i);
    public static Constr operator |((Set i, Set j) sets, Ineq ineq)
        => new(ineq, new(sets.i, sets.j));
    public static Constr operator |((Set i, Set j, Set k) sets, Ineq ineq)
        => new(ineq, new OptList<Set>(new List<Set>() { sets.i, sets.j, sets.k }));
    public static Constr operator |((Set i, Set j, Set k, Set l) sets, Ineq ineq)
        => new(ineq, new OptList<Set>(new List<Set>() { sets.i, sets.j, sets.k, sets.l }));


    // common
    public override string ToString()
        => T.Ineq(this);
}
