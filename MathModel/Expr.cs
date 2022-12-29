namespace MathProg;

public class Expr
{
    // data
    public Opt<Sca> Constant;
    public OptList<Term> Terms;
    public OptList<Sum> Sums;


    // ctor
    public Expr(Opt<Sca> constant, OptList<Term> terms, OptList<Sum> sums)
    {
        Constant = constant;
        Terms = terms;
        Sums = sums;
    }
    

    // method
    internal Expr SetIndices(Indices allIndices, Indices runningIndices, string exprStr)
    {
        if (Constant.IsSome)
            Constant = Some(Constant.Unwrap().SetIndices(runningIndices, exprStr));

        for (int i = 0; i < Terms.Length; i++)
            Terms[i] = Terms[i].SetIndices(runningIndices, exprStr);

        for (int i = 0; i < Sums.Length; i++)
            Sums[i] = Sums[i].SetIndices(allIndices, runningIndices, exprStr);

        return this;
    }


    // implicit
    public static implicit operator Expr(double num)
        => new((Sca)num, default, default);
    public static implicit operator Expr(int num)
        => new((Sca)num, default, default);
    public static implicit operator Expr(Sca s)
        => new(s, default, default);
    public static implicit operator Expr(Par s)
        => new((Sca)s, default, default);
    public static implicit operator Expr(Var v)
        => new(default, (Term)v, default);
    public static implicit operator Expr(Term t)
        => new(default, t, default);
    public static implicit operator Expr(Sum s)
        => new(default, default, s);
    // static
    public static Expr Zero
        => (Expr)0.0;



    // ops - Expr
    public static Expr operator -(Expr e)
        => new(e.Constant.Neg(), e.Terms.Neg(), e.Sums.Neg());
    public static Expr operator +(Expr e1, Expr e2)
        => new(e1.Constant.Add(e2.Constant), e1.Terms + e2.Terms, e1.Sums + e2.Sums);
    public static Expr operator -(Expr e1, Expr e2)
        => new(e1.Constant.Add(e2.Constant.Neg()), e1.Terms + e2.Terms.Neg(), e1.Sums + e2.Sums.Neg());


    // ops - Sca
    public static Expr operator +(Expr e, Sca s)
        => new(e.Constant.Add(s), e.Terms, e.Sums);
    public static Expr operator +(Sca s, Expr e)
        => e + s;
    public static Expr operator -(Expr e, Sca s)
        => new(e.Constant.Add(-s), e.Terms, e.Sums);
    public static Expr operator -(Sca s, Expr e)
        => new(e.Constant.Neg().Add(s), e.Terms.Neg(), e.Sums.Neg());
    public static Expr operator *(Expr e, Sca s)
        => new(e.Constant.Mul(s), e.Terms.Mul(s), e.Sums.Mul(s));
    public static Expr operator *(Sca s, Expr e)
        => e * s;
    public static Expr operator /(Expr e, Sca s)
        => new(e.Constant.Div(s), e.Terms.Div(s), e.Sums.Div(s));
    // ops - double
    public static Expr operator +(Expr e, double s)
        => e + (Sca)s;
    public static Expr operator +(double s, Expr e)
        => e + s;
    public static Expr operator -(Expr e, double s)
        => e - (Sca)s;
    public static Expr operator -(double s, Expr e)
        => (Sca)s - e;
    public static Expr operator *(Expr e, double s)
        => e * (Sca)s;
    public static Expr operator *(double s, Expr e)
        => e * s;
    public static Expr operator /(Expr e, double s)
        => e / (Sca)s;
    // ops - int
    public static Expr operator +(Expr e, int s)
        => e + (Sca)s;
    public static Expr operator +(int s, Expr e)
        => e + s;
    public static Expr operator -(Expr e, int s)
        => e - (Sca)s;
    public static Expr operator -(int s, Expr e)
        => (Sca)s - e;
    public static Expr operator *(Expr e, int s)
        => e * (Sca)s;
    public static Expr operator *(int s, Expr e)
        => e * s;
    public static Expr operator /(Expr e, int s)
        => e / (Sca)s;


    // ops - var
    public static Expr operator +(Expr e, Var v)
        => new(e.Constant, e.Terms.Add(new Term(Sca.One(), v)), e.Sums);
    public static Expr operator +(Var v, Expr e)
        => e + v;
    public static Expr operator -(Expr e, Var v)
        => new(e.Constant, e.Terms.Add(new Term(Sca.MinOne(), v)), e.Sums);
    public static Expr operator -(Var v, Expr e)
        => new(e.Constant.Neg(), e.Terms.Neg().Add(new Term(Sca.One(), v)), e.Sums.Neg());


    // ops - term
    public static Expr operator +(Expr e, Term t)
        => new(e.Constant, e.Terms.Add(t), e.Sums);
    public static Expr operator +(Term t, Expr e)
        => e + t;
    public static Expr operator -(Expr e, Term t)
        => new(e.Constant, e.Terms.Add(-t), e.Sums);
    public static Expr operator -(Term t, Expr e)
        => new(e.Constant.Neg(), e.Terms.Neg().Add(t), e.Sums.Neg());


    // ops - sum
    public static Expr operator +(Expr e, Sum s)
        => new(e.Constant, e.Terms, e.Sums.Add(s));
    public static Expr operator +(Sum s, Expr e)
        => e + s;
    public static Expr operator -(Expr e, Sum s)
        => new(e.Constant, e.Terms, e.Sums.Add(-s));
    public static Expr operator -(Sum s, Expr e)
        => new(e.Constant.Neg(), e.Terms.Neg(), e.Sums.Neg().Add(s));


    // ops - Constr - expr*expr
    public static Ineq operator <=(Expr lhs, Expr rhs)
        => new(ConstrRelation.Leq, lhs, rhs);
    public static Ineq operator >=(Expr lhs, Expr rhs)
        => new(ConstrRelation.Geq, lhs, rhs);
    public static Ineq operator ==(Expr lhs, Expr rhs)
        => new(ConstrRelation.Eq, lhs, rhs);
    public static Ineq operator !=(Expr _lhs, Expr _rhs)
        => throw Exc.InvalidNotEq;
    // ops - Constr - double*expr
    public static Ineq operator <=(Expr lhs, double rhs)
        => lhs <= (Expr)rhs;
    public static Ineq operator >=(Expr lhs, double rhs)
        => lhs >= (Expr)rhs;
    public static Ineq operator ==(Expr lhs, double rhs)
        => lhs == (Expr)rhs;
    public static Ineq operator !=(Expr lhs, double rhs)
        => lhs != (Expr)rhs;
    public static Ineq operator <=(double lhs, Expr rhs)
        => (Expr)lhs <= rhs;
    public static Ineq operator >=(double lhs, Expr rhs)
        => (Expr)lhs >= rhs;
    public static Ineq operator ==(double lhs, Expr rhs)
        => (Expr)lhs == rhs;
    public static Ineq operator !=(double lhs, Expr rhs)
        => (Expr)lhs != rhs;
    // ops - Constr - int*expr
    public static Ineq operator <=(Expr lhs, int rhs)
        => lhs <= (Expr)rhs;
    public static Ineq operator >=(Expr lhs, int rhs)
        => lhs >= (Expr)rhs;
    public static Ineq operator ==(Expr lhs, int rhs)
        => lhs == (Expr)rhs;
    public static Ineq operator !=(Expr lhs, int rhs)
        => lhs != (Expr)rhs;
    public static Ineq operator <=(int lhs, Expr rhs)
        => (Expr)lhs <= rhs;
    public static Ineq operator >=(int lhs, Expr rhs)
        => (Expr)lhs >= rhs;
    public static Ineq operator ==(int lhs, Expr rhs)
        => (Expr)lhs == rhs;
    public static Ineq operator !=(int lhs, Expr rhs)
        => (Expr)lhs != rhs;
    // ops - Constr - Sca*expr
    public static Ineq operator <=(Expr lhs, Sca rhs)
        => lhs <= (Expr)rhs;
    public static Ineq operator >=(Expr lhs, Sca rhs)
        => lhs >= (Expr)rhs;
    public static Ineq operator ==(Expr lhs, Sca rhs)
        => lhs == (Expr)rhs;
    public static Ineq operator !=(Expr lhs, Sca rhs)
        => lhs != (Expr)rhs;
    public static Ineq operator <=(Sca lhs, Expr rhs)
        => (Expr)lhs <= rhs;
    public static Ineq operator >=(Sca lhs, Expr rhs)
        => (Expr)lhs >= rhs;
    public static Ineq operator ==(Sca lhs, Expr rhs)
        => (Expr)lhs == rhs;
    public static Ineq operator !=(Sca lhs, Expr rhs)
        => (Expr)lhs != rhs;
    // ops - Constr - Var*expr
    public static Ineq operator <=(Expr lhs, Var rhs)
        => lhs <= (Expr)rhs;
    public static Ineq operator >=(Expr lhs, Var rhs)
        => lhs >= (Expr)rhs;
    public static Ineq operator ==(Expr lhs, Var rhs)
        => lhs == (Expr)rhs;
    public static Ineq operator !=(Expr lhs, Var rhs)
        => lhs != (Expr)rhs;
    public static Ineq operator <=(Var lhs, Expr rhs)
        => (Expr)lhs <= rhs;
    public static Ineq operator >=(Var lhs, Expr rhs)
        => (Expr)lhs >= rhs;
    public static Ineq operator ==(Var lhs, Expr rhs)
        => (Expr)lhs == rhs;
    public static Ineq operator !=(Var lhs, Expr rhs)
        => (Expr)lhs != rhs;
    // ops - Constr - Term*expr
    public static Ineq operator <=(Expr lhs, Term rhs)
        => lhs <= (Expr)rhs;
    public static Ineq operator >=(Expr lhs, Term rhs)
        => lhs >= (Expr)rhs;
    public static Ineq operator ==(Expr lhs, Term rhs)
        => lhs == (Expr)rhs;
    public static Ineq operator !=(Expr lhs, Term rhs)
        => lhs != (Expr)rhs;
    public static Ineq operator <=(Term lhs, Expr rhs)
        => (Expr)lhs <= rhs;
    public static Ineq operator >=(Term lhs, Expr rhs)
        => (Expr)lhs >= rhs;
    public static Ineq operator ==(Term lhs, Expr rhs)
        => (Expr)lhs == rhs;
    public static Ineq operator !=(Term lhs, Expr rhs)
        => (Expr)lhs != rhs;
    // ops - Constr - Sum*expr
    public static Ineq operator <=(Expr lhs, Sum rhs)
        => lhs <= (Expr)rhs;
    public static Ineq operator >=(Expr lhs, Sum rhs)
        => lhs >= (Expr)rhs;
    public static Ineq operator ==(Expr lhs, Sum rhs)
        => lhs == (Expr)rhs;
    public static Ineq operator !=(Expr lhs, Sum rhs)
        => lhs != (Expr)rhs;
    public static Ineq operator <=(Sum lhs, Expr rhs)
        => (Expr)lhs <= rhs;
    public static Ineq operator >=(Sum lhs, Expr rhs)
        => (Expr)lhs >= rhs;
    public static Ineq operator ==(Sum lhs, Expr rhs)
        => (Expr)lhs == rhs;
    public static Ineq operator !=(Sum lhs, Expr rhs)
        => (Expr)lhs != rhs;


    // op - sum - Expr
    public static SumArg operator |(Set i, Expr expr)
        => new(new Sum(expr, new(i)));
    public static SumArg operator |((Set i, Set j) sets, Expr expr)
        => new(new Sum(expr, new(sets.i, sets.j)));
    public static SumArg operator |((Set i, Set j, Set k) sets, Expr expr)
        => new(new Sum(expr, new(new List<Set>() { sets.i, sets.j, sets.k })));


    // op - obj - Expr
    public static ObjFun operator |(ObjDir direction, Expr expr)
        => new(direction, expr);


    // common
    public override string ToString()
        => T.Expr(this);
    public override bool Equals(object? obj)
        => obj is Expr expr && expr.Equals(this);
    public override int GetHashCode()
        => HashCode.Combine(Constant, Terms, Sums);
}
