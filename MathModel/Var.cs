namespace MathProg;

public readonly struct Var
{
    // data
    public readonly IVar Variable;
    public readonly OptList<Sca> Indices;


    // ctor
    public Var(IVar variable, OptList<Sca> indices)
    {
        Variable = variable;
        Indices = indices;
    }


    // method
    internal Var SetIndices(Indices indices, string exprStr)
    {
        var newIndices = Indices;
        for (int i = 0; i < newIndices.Length; i++)
            newIndices[i] = newIndices[i].SetIndices(indices, exprStr);
        return new(Variable, newIndices);
    }


    // implicit
    public static implicit operator Var(Var0 var)
        => new(var, default);


    // ops
    public static Term operator -(Var v)
        => new(Sca.MinOne(), v);


    // ops - Sca
    public static Term operator *(Sca c, Var v)
        => new(c, v);
    public static Term operator *(Var v, Sca c)
        => new(c, v);
    public static Term operator /(Var v, Sca c)
        => new(1.0 / c, v);
    public static Expr operator +(Sca c, Var v)
        => new(c, (Term)v, default);
    public static Expr operator +(Var v, Sca c)
        => c + v;
    public static Expr operator -(Sca c, Var v)
        => new(c, -v, default);
    public static Expr operator -(Var v, Sca c)
        => new(-c, (Term)v, default);
    // ops - double
    public static Term operator *(double c, Var v)
        => new(c, v);
    public static Term operator *(Var v, double c)
        => new(c, v);
    public static Term operator /(Var v, double c)
        => new(1.0 / c, v);
    public static Expr operator +(double c, Var v)
        => new((Sca)c, (Term)v, default);
    public static Expr operator +(Var v, double c)
        => c + v;
    public static Expr operator -(double c, Var v)
        => new((Sca)c, -v, default);
    public static Expr operator -(Var v, double s)
        => new((Sca)(-s), (Term)v, default);
    // ops - int
    public static Term operator *(int c, Var v)
        => new(c, v);
    public static Term operator *(Var v, int c)
        => new(c, v);
    public static Term operator /(Var v, int c)
        => new(1.0 / c, v);
    public static Expr operator +(int c, Var v)
        => new((Sca)c, (Term)v, default);
    public static Expr operator +(Var v, int c)
        => c + v;
    public static Expr operator -(int c, Var v)
        => new((Sca)c, -v, default);
    public static Expr operator -(Var v, int s)
        => new((Sca)(-s), (Term)v, default);


    // ops - var
    public static Expr operator +(Var x, Var y)
        => new(default, new((Term)x, (Term)y), default);
    public static Expr operator -(Var x, Var y)
        => new(default, new((Term)x, -y), default);


    // op - sum - Var
    public static SumArg operator |(Set i, Var s)
        => new(new Sum(s, new(i)));
    public static SumArg operator |((Set i, Set j) sets, Var s)
        => new(new Sum(s, new(sets.i, sets.j)));
    public static SumArg operator |((Set i, Set j, Set k) sets, Var s)
        => new(new Sum(s, new(new List<Set>() { sets.i, sets.j, sets.k })));


    // ops - Constr - var*var
    public static Ineq operator ==(Var lhs, Var rhs)
        => (Expr)lhs == (Expr)rhs;
    public static Ineq operator !=(Var lhs, Var rhs)
        => (Expr)lhs != (Expr)rhs;
    public static Ineq operator <=(Var lhs, Var rhs)
        => (Expr)lhs <= (Expr)rhs;
    public static Ineq operator >=(Var lhs, Var rhs)
        => (Expr)lhs >= (Expr)rhs;


    // ops - Constr - var*Sca
    public static Ineq operator ==(Var lhs, Sca rhs)
        => (Expr)lhs == (Expr)rhs;
    public static Ineq operator !=(Var lhs, Sca rhs)
        => (Expr)lhs != (Expr)rhs;
    public static Ineq operator ==(Sca lhs, Var rhs)
        => (Expr)lhs == (Expr)rhs;
    public static Ineq operator !=(Sca lhs, Var rhs)
        => (Expr)lhs != (Expr)rhs;
    public static Ineq operator <=(Var lhs, Sca rhs)
        => (Expr)lhs <= (Expr)rhs;
    public static Ineq operator >=(Var lhs, Sca rhs)
        => (Expr)lhs >= (Expr)rhs;
    public static Ineq operator <=(Sca lhs, Var rhs)
        => (Expr)lhs <= (Expr)rhs;
    public static Ineq operator >=(Sca lhs, Var rhs)
        => (Expr)lhs >= (Expr)rhs;
    // ops - Constr - var*double
    public static Ineq operator ==(Var lhs, double rhs)
        => (Expr)lhs == (Expr)rhs;
    public static Ineq operator !=(Var lhs, double rhs)
        => (Expr)lhs != (Expr)rhs;
    public static Ineq operator ==(double lhs, Var rhs)
        => (Expr)lhs == (Expr)rhs;
    public static Ineq operator !=(double lhs, Var rhs)
        => (Expr)lhs != (Expr)rhs;
    public static Ineq operator <=(Var lhs, double rhs)
        => (Expr)lhs <= (Expr)rhs;
    public static Ineq operator >=(Var lhs, double rhs)
        => (Expr)lhs >= (Expr)rhs;
    public static Ineq operator <=(double lhs, Var rhs)
        => (Expr)lhs <= (Expr)rhs;
    public static Ineq operator >=(double lhs, Var rhs)
        => (Expr)lhs >= (Expr)rhs;
    // ops - Constr - var*int
    public static Ineq operator ==(Var lhs, int rhs)
        => (Expr)lhs == (Expr)rhs;
    public static Ineq operator !=(Var lhs, int rhs)
        => (Expr)lhs != (Expr)rhs;
    public static Ineq operator ==(int lhs, Var rhs)
        => (Expr)lhs == (Expr)rhs;
    public static Ineq operator !=(int lhs, Var rhs)
        => (Expr)lhs != (Expr)rhs;
    public static Ineq operator <=(Var lhs, int rhs)
        => (Expr)lhs <= (Expr)rhs;
    public static Ineq operator >=(Var lhs, int rhs)
        => (Expr)lhs >= (Expr)rhs;
    public static Ineq operator <=(int lhs, Var rhs)
        => (Expr)lhs <= (Expr)rhs;
    public static Ineq operator >=(int lhs, Var rhs)
        => (Expr)lhs >= (Expr)rhs;
    // ops - Constr - var*Set
    public static Ineq operator ==(Var lhs, Set rhs)
        => (Expr)lhs == (Expr)(Sca)rhs;
    public static Ineq operator !=(Var lhs, Set rhs)
        => (Expr)lhs != (Expr)(Sca)rhs;
    public static Ineq operator ==(Set lhs, Var rhs)
        => (Expr)(Sca)lhs == (Expr)rhs;
    public static Ineq operator !=(Set lhs, Var rhs)
        => (Expr)(Sca)lhs != (Expr)rhs;
    public static Ineq operator <=(Var lhs, Set rhs)
        => (Expr)lhs <= new Expr(Some((Sca)rhs), default, default);
    public static Ineq operator >=(Var lhs, Set rhs)
        => (Expr)lhs >= new Expr(Some((Sca)rhs), default, default);
    public static Ineq operator <=(Set lhs, Var rhs)
        => new Expr(Some((Sca)lhs), default, default) <= (Expr)rhs;
    public static Ineq operator >=(Set lhs, Var rhs)
        => new Expr(Some((Sca)lhs), default, default) >= (Expr)rhs;


    // op - obj
    public static ObjFun operator |(ObjDir direction, Var s)
        => new(direction, s);


    // common
    public override string ToString()
        => string.Format(T.Of(Variable.Key, Indices));
    public override bool Equals(object? obj)
        => obj is Var var && var.Equals(this);
    public override int GetHashCode()
        => HashCode.Combine(Variable, Indices);


    // method - internal
    internal void WriteStringFor(StreamWriter writer, int[] state)
    {
        writer.Write(Variable.Key);
        for (int i = 0; i < Indices.Length; i++)
        {
            writer.Write('_');
            writer.Write(Indices[i].GetCurrValueAsInt(state));
        }
    }
}
