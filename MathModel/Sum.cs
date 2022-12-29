namespace MathProg;

public record struct Sum(Expr Expr, OptList<Set> Sets)
{
    // data
    internal Opt<int[]> IndIndices = default;


    // method
    internal Sum SetIndices(Indices allIndices, Indices runningIndices, string exprStr)
    {
        var (newRunning, indIndices) = allIndices.AddGetNewRunning(runningIndices, Sets);
        return new(Expr.SetIndices(allIndices, newRunning, exprStr), Sets) { IndIndices = Some(indIndices) };
    }


    // ops - Sum
    public static Sum operator -(Sum s)
        => new(-s.Expr, s.Sets);
    public static Expr operator +(Sum s, Sum t)
        => new(default, default, new(s, t));
    public static Expr operator -(Sum s, Sum t)
        => new(default, default, new(s, -t));


    // ops - Sca
    public static Expr operator +(Sum s, Sca n)
        => new(n, default, s);
    public static Expr operator +(Sca n, Sum s)
        => s + n;
    public static Expr operator -(Sum s, Sca n)
        => new(-n, default, s);
    public static Expr operator -(Sca n, Sum s)
        => new(n, default, -s);
    public static Sum operator *(Sum s, Sca n)
        => new(n * s.Expr, s.Sets);
    public static Sum operator *(Sca n, Sum s)
        => s * n;
    public static Sum operator /(Sum s, Sca n)
        => new(s.Expr / n, s.Sets);
    // ops - double
    public static Expr operator +(Sum s, double n)
        => new((Sca)n, default, s);
    public static Expr operator +(double n, Sum s)
        => s + n;
    public static Expr operator -(Sum s, double n)
        => new((Sca)(-n), default, s);
    public static Expr operator -(double n, Sum s)
        => new((Sca)n, default, -s);
    public static Sum operator *(Sum s, double n)
        => new(n * s.Expr, s.Sets);
    public static Sum operator *(double n, Sum s)
        => s * n;
    public static Sum operator /(Sum s, double n)
        => new(s.Expr / n, s.Sets);
    // ops - int
    public static Expr operator +(Sum s, int n)
        => new((Sca)n, default, s);
    public static Expr operator +(int n, Sum s)
        => s + n;
    public static Expr operator -(Sum s, int n)
        => new((Sca)(-n), default, s);
    public static Expr operator -(int n, Sum s)
        => new((Sca)n, default, -s);
    public static Sum operator *(Sum s, int n)
        => new(n * s.Expr, s.Sets);
    public static Sum operator *(int n, Sum s)
        => s * n;
    public static Sum operator /(Sum s, int n)
        => new(s.Expr / n, s.Sets);


    // ops - var
    public static Expr operator +(Sum s, Var v)
        => new(default, (Term)v, s);
    public static Expr operator +(Var v, Sum s)
        => s + v;
    public static Expr operator -(Sum s, Var v)
        => new(default, new Term(Sca.MinOne(), v), s);
    public static Expr operator -(Var v, Sum s)
        => new(default, (Term)v, -s);


    // ops - term
    public static Expr operator +(Sum s, Term t)
        => new(default, t, s);
    public static Expr operator +(Term t, Sum s)
        => s + t;
    public static Expr operator -(Sum s, Term t)
        => new(default, -t, s);
    public static Expr operator -(Term t, Sum s)
        => new(default, t, -s);


    // ops - Constr - double
    public static Ineq operator <=(double lhs, Sum rhs)
        => lhs <= (Expr)rhs;
    public static Ineq operator >=(double lhs, Sum rhs)
        => lhs >= (Expr)rhs;
    public static Ineq operator ==(double lhs, Sum rhs)
        => lhs == (Expr)rhs;
    public static Ineq operator !=(double lhs, Sum rhs)
        => lhs != (Expr)rhs;
    public static Ineq operator <=(Sum lhs, double rhs)
        => (Expr)lhs <= rhs;
    public static Ineq operator >=(Sum lhs, double rhs)
        => (Expr)lhs >= rhs;
    public static Ineq operator ==(Sum lhs, double rhs)
        => (Expr)lhs == rhs;
    public static Ineq operator !=(Sum lhs, double rhs)
        => (Expr)lhs != rhs;
    // ops - Constr - int
    public static Ineq operator <=(int lhs, Sum rhs)
        => lhs <= (Expr)rhs;
    public static Ineq operator >=(int lhs, Sum rhs)
        => lhs >= (Expr)rhs;
    public static Ineq operator ==(int lhs, Sum rhs)
        => lhs == (Expr)rhs;
    public static Ineq operator !=(int lhs, Sum rhs)
        => lhs != (Expr)rhs;
    public static Ineq operator <=(Sum lhs, int rhs)
        => (Expr)lhs <= rhs;
    public static Ineq operator >=(Sum lhs, int rhs)
        => (Expr)lhs >= rhs;
    public static Ineq operator ==(Sum lhs, int rhs)
        => (Expr)lhs == rhs;
    public static Ineq operator !=(Sum lhs, int rhs)
        => (Expr)lhs != rhs;
    // ops - Constr - Sca
    public static Ineq operator <=(Sca lhs, Sum rhs)
        => lhs <= (Expr)rhs;
    public static Ineq operator >=(Sca lhs, Sum rhs)
        => lhs >= (Expr)rhs;
    public static Ineq operator ==(Sca lhs, Sum rhs)
        => lhs == (Expr)rhs;
    public static Ineq operator !=(Sca lhs, Sum rhs)
        => lhs != (Expr)rhs;
    public static Ineq operator <=(Sum lhs, Sca rhs)
        => (Expr)lhs <= rhs;
    public static Ineq operator >=(Sum lhs, Sca rhs)
        => (Expr)lhs >= rhs;
    public static Ineq operator ==(Sum lhs, Sca rhs)
        => (Expr)lhs == rhs;
    public static Ineq operator !=(Sum lhs, Sca rhs)
        => (Expr)lhs != rhs;


    // ops - Constr - Var
    public static Ineq operator <=(Var lhs, Sum rhs)
        => lhs <= (Expr)rhs;
    public static Ineq operator >=(Var lhs, Sum rhs)
        => lhs >= (Expr)rhs;
    public static Ineq operator ==(Var lhs, Sum rhs)
        => lhs == (Expr)rhs;
    public static Ineq operator !=(Var lhs, Sum rhs)
        => lhs != (Expr)rhs;
    public static Ineq operator <=(Sum lhs, Var rhs)
        => (Expr)lhs <= rhs;
    public static Ineq operator >=(Sum lhs, Var rhs)
        => (Expr)lhs >= rhs;
    public static Ineq operator ==(Sum lhs, Var rhs)
        => (Expr)lhs == rhs;
    public static Ineq operator !=(Sum lhs, Var rhs)
        => (Expr)lhs != rhs;
    // ops - Constr - Term
    public static Ineq operator <=(Term lhs, Sum rhs)
        => lhs <= (Expr)rhs;
    public static Ineq operator >=(Term lhs, Sum rhs)
        => lhs >= (Expr)rhs;
    public static Ineq operator ==(Term lhs, Sum rhs)
        => lhs == (Expr)rhs;
    public static Ineq operator !=(Term lhs, Sum rhs)
        => lhs != (Expr)rhs;
    public static Ineq operator <=(Sum lhs, Term rhs)
        => (Expr)lhs <= rhs;
    public static Ineq operator >=(Sum lhs, Term rhs)
        => (Expr)lhs >= rhs;
    public static Ineq operator ==(Sum lhs, Term rhs)
        => (Expr)lhs == rhs;
    public static Ineq operator !=(Sum lhs, Term rhs)
        => (Expr)lhs != rhs;


    // op - obj
    public static ObjFun operator |(ObjDir direction, Sum s)
        => new(direction, s);


    // common
    public override string ToString()
        => T.Sum(this);
}
