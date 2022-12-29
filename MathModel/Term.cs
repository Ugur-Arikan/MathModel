namespace MathProg;

public record struct Term(Sca Sca, Var Var)
{
    // method
    internal Term SetIndices(Indices indices, string exprStr)
        => new(Sca.SetIndices(indices, exprStr), Var.SetIndices(indices, exprStr));


    // implicit
    public static implicit operator Term(Var var)
        => new(Sca.One(), var);


    // ops
    public static Term operator -(Term t)
        => new(-t.Sca, t.Var);


    //  ops - Sca
    public static Term operator *(Sca s, Term t)
        => new(s * t.Sca, t.Var);
    public static Term operator *(Term t, Sca s)
        => new(t.Sca * s, t.Var);
    public static Term operator /(Term t, Sca s)
        => new(t.Sca / s, t.Var);
    // ops - double
    public static Term operator *(double s, Term t)
        => new(s * t.Sca, t.Var);
    public static Term operator *(Term t, double s)
        => new(t.Sca * s, t.Var);
    public static Term operator /(Term t, double s)
        => new(t.Sca / s, t.Var);
    // ops - int
    public static Term operator *(int s, Term t)
        => new(s * t.Sca, t.Var);
    public static Term operator *(Term t, int s)
        => new(t.Sca * s, t.Var);
    public static Term operator /(Term t, int s)
        => new(t.Sca / s, t.Var);


    // ops - term
    public static Expr operator +(Term t, Term u)
        => new(default, new(t, u), default);
    public static Expr operator -(Term t, Term u)
        => new(default, new(t, -u), default);


    // op - sum - Term
    public static SumArg operator |(Set i, Term s)
        => new(new Sum(s, new(i)));
    public static SumArg operator |((Set i, Set j) sets, Term s)
        => new(new Sum(s, new(sets.i, sets.j)));
    public static SumArg operator |((Set i, Set j, Set k) sets, Term s)
        => new(new Sum(s, new(new List<Set>() { sets.i, sets.j, sets.k })));


    // ops - Constr - Term*Set
    public static Ineq operator ==(Term lhs, Set rhs)
        => (Expr)lhs == new Expr(Some((Sca)rhs), default, default);
    public static Ineq operator !=(Term lhs, Set rhs)
        => (Expr)lhs != new Expr(Some((Sca)rhs), default, default);
    public static Ineq operator ==(Set lhs, Term rhs)
        => new Expr(Some((Sca)lhs), default, default) == (Expr)rhs;
    public static Ineq operator !=(Set lhs, Term rhs)
        => new Expr(Some((Sca)lhs), default, default) != (Expr)rhs;
    public static Ineq operator <=(Term lhs, Set rhs)
        => (Expr)lhs <= new Expr(Some((Sca)rhs), default, default);
    public static Ineq operator >=(Term lhs, Set rhs)
        => (Expr)lhs >= new Expr(Some((Sca)rhs), default, default);
    public static Ineq operator <=(Set lhs, Term rhs)
        => new Expr(Some((Sca)lhs), default, default) <= (Expr)rhs;
    public static Ineq operator >=(Set lhs, Term rhs)
        => new Expr(Some((Sca)lhs), default, default) >= (Expr)rhs;
    // ops - Constr - Term*Var
    public static Ineq operator ==(Term lhs, Var rhs)
        => (Expr)lhs == (Expr)rhs;
    public static Ineq operator !=(Term lhs, Var rhs)
        => (Expr)lhs != (Expr)rhs;
    public static Ineq operator ==(Var lhs, Term rhs)
        => (Expr)lhs == (Expr)rhs;
    public static Ineq operator !=(Var lhs, Term rhs)
        => (Expr)lhs != (Expr)rhs;
    public static Ineq operator <=(Term lhs, Var rhs)
        => (Expr)lhs <= (Expr)rhs;
    public static Ineq operator >=(Term lhs, Var rhs)
        => (Expr)lhs >= (Expr)rhs;
    public static Ineq operator <=(Var lhs, Term rhs)
        => (Expr)lhs <= (Expr)rhs;
    public static Ineq operator >=(Var lhs, Term rhs)
        => (Expr)lhs >= (Expr)rhs;



    // op - obj
    public static ObjFun operator |(ObjDir direction, Term s)
        => new(direction, s);


    // common
    public override string ToString()
        => Sca.IsNum(1) ? Var.ToString() : T.Term(Sca, Var);
}
