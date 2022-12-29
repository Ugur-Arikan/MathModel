using MathProg.DefaultKeys;

namespace MathProg;

public record Var0(
    string Key,
    VarType VarType,
    Bounds0 Bounds) : IVar
{
    // ctor
    public Var0(VarType varType, Bounds0 bounds)
        : this(DefaultVarKeys.Get(), varType, bounds)
    {
    }


    // implicit
    public static implicit operator Term(Var0 v)
        => (Var)v;
    public static implicit operator Expr(Var0 v)
        => (Var)v;


    // ctor - key
    public static Var0 Bin(string key)
        => new(key, VarType.Binary, Bounds0.ZeroOne);
    public static Var0 Cont(string key, Bounds0 bounds)
        => new(key, VarType.Continuous, bounds);
    public static Var0 Ubdd(string key)
        => new(key, VarType.Continuous, Bounds0.None);
    public static Var0 Nonneg(string key)
        => new(key, VarType.Continuous, Bounds0.Nonneg);
    public static Var0 Nonpos(string key)
        => new(key, VarType.Continuous, Bounds0.Nonpos);
    public static Var0 Disc(string key, Bounds0 bounds)
        => new(key, VarType.Integer, bounds);
    public static Var0 DiscUbdd(string key)
            => new(key, VarType.Integer, Bounds0.None);
    public static Var0 DiscNonneg(string key)
        => new(key, VarType.Integer, Bounds0.Nonneg);
    public static Var0 DiscNonpos(string key)
        => new(key, VarType.Integer, Bounds0.Nonpos);


    // ctor - default
    public static Var0 Bin()
        => Bin(DefaultVarKeys.Get());
    public static Var0 Cont(Bounds0 bounds)
        => Cont(DefaultVarKeys.Get(), bounds);
    public static Var0 Ubdd()
        => Ubdd(DefaultVarKeys.Get());
    public static Var0 Nonneg()
        => Nonneg(DefaultVarKeys.Get());
    public static Var0 Nonpos()
        => Nonpos(DefaultVarKeys.Get());
    public static Var0 Disc(Bounds0 bounds)
        => Disc(DefaultVarKeys.Get(), bounds);
    public static Var0 DiscUbdd()
        => DiscUbdd(DefaultVarKeys.Get());
    public static Var0 DiscNonneg()
        => DiscNonneg(DefaultVarKeys.Get());
    public static Var0 DiscNonpos()
        => DiscNonpos(DefaultVarKeys.Get());


    // method
    public int Dim => 0;
    bool IVar.HasContantBounds
        => Bounds.IsContant;
    bool IVar.IsConstantlyNonneg
        => Bounds.IsConstantlyNonneg;


    // ops - Var0
    public static Term operator -(Var0 v)
        => -(Var)v;
    // ops - Sca
    public static Term operator *(Sca c, Var0 v)
        => new(c, v);
    public static Term operator *(Var0 v, Sca c)
        => new(c, v);
    public static Term operator /(Var0 v, Sca c)
        => new(1.0 / c, v);
    public static Expr operator +(Sca c, Var0 v)
        => new(c, (Term)v, default);
    public static Expr operator +(Var0 v, Sca c)
        => c + v;
    public static Expr operator -(Sca c, Var0 v)
        => new(c, -v, default);
    public static Expr operator -(Var0 v, Sca c)
        => new(-c, (Term)v, default);
    // ops - double
    public static Term operator *(double c, Var0 v)
        => new(c, v);
    public static Term operator *(Var0 v, double c)
        => new(c, v);
    public static Term operator /(Var0 v, double c)
        => new(1.0 / c, v);
    public static Expr operator +(double c, Var0 v)
        => new((Sca)c, (Term)v, default);
    public static Expr operator +(Var0 v, double c)
        => c + v;
    public static Expr operator -(double c, Var0 v)
        => new((Sca)c, -v, default);
    public static Expr operator -(Var0 v, double s)
        => new((Sca)(-s), (Term)v, default);
    // ops - int
    public static Term operator *(int c, Var0 v)
        => new(c, v);
    public static Term operator *(Var0 v, int c)
        => new(c, v);
    public static Term operator /(Var0 v, int c)
        => new(1.0 / c, v);
    public static Expr operator +(int c, Var0 v)
        => new((Sca)c, (Term)v, default);
    public static Expr operator +(Var0 v, int c)
        => c + v;
    public static Expr operator -(int c, Var0 v)
        => new((Sca)c, -v, default);
    public static Expr operator -(Var0 v, int s)
        => new((Sca)(-s), (Term)v, default);



    // ops - Constr - var*Sca
    public static Ineq operator ==(Var0 lhs, Sca rhs)
        => (Expr)lhs == (Expr)rhs;
    public static Ineq operator !=(Var0 lhs, Sca rhs)
        => (Expr)lhs != (Expr)rhs;
    public static Ineq operator ==(Sca lhs, Var0 rhs)
        => (Expr)lhs == (Expr)rhs;
    public static Ineq operator !=(Sca lhs, Var0 rhs)
        => (Expr)lhs != (Expr)rhs;
    public static Ineq operator <=(Var0 lhs, Sca rhs)
        => (Expr)lhs <= (Expr)rhs;
    public static Ineq operator >=(Var0 lhs, Sca rhs)
        => (Expr)lhs >= (Expr)rhs;
    public static Ineq operator <=(Sca lhs, Var0 rhs)
        => (Expr)lhs <= (Expr)rhs;
    public static Ineq operator >=(Sca lhs, Var0 rhs)
        => (Expr)lhs >= (Expr)rhs;
    // ops - Constr - var*double
    public static Ineq operator ==(Var0 lhs, double rhs)
        => (Expr)lhs == (Expr)rhs;
    public static Ineq operator !=(Var0 lhs, double rhs)
        => (Expr)lhs != (Expr)rhs;
    public static Ineq operator ==(double lhs, Var0 rhs)
        => (Expr)lhs == (Expr)rhs;
    public static Ineq operator !=(double lhs, Var0 rhs)
        => (Expr)lhs != (Expr)rhs;
    public static Ineq operator <=(Var0 lhs, double rhs)
        => (Expr)lhs <= (Expr)rhs;
    public static Ineq operator >=(Var0 lhs, double rhs)
        => (Expr)lhs >= (Expr)rhs;
    public static Ineq operator <=(double lhs, Var0 rhs)
        => (Expr)lhs <= (Expr)rhs;
    public static Ineq operator >=(double lhs, Var0 rhs)
        => (Expr)lhs >= (Expr)rhs;
    // ops - Constr - var*int
    public static Ineq operator ==(Var0 lhs, int rhs)
        => (Expr)lhs == (Expr)rhs;
    public static Ineq operator !=(Var0 lhs, int rhs)
        => (Expr)lhs != (Expr)rhs;
    public static Ineq operator ==(int lhs, Var0 rhs)
        => (Expr)lhs == (Expr)rhs;
    public static Ineq operator !=(int lhs, Var0 rhs)
        => (Expr)lhs != (Expr)rhs;
    public static Ineq operator <=(Var0 lhs, int rhs)
        => (Expr)lhs <= (Expr)rhs;
    public static Ineq operator >=(Var0 lhs, int rhs)
        => (Expr)lhs >= (Expr)rhs;
    public static Ineq operator <=(int lhs, Var0 rhs)
        => (Expr)lhs <= (Expr)rhs;
    public static Ineq operator >=(int lhs, Var0 rhs)
        => (Expr)lhs >= (Expr)rhs;
    // ops - Constr - var*Set
    public static Ineq operator ==(Var0 lhs, Set rhs)
        => (Expr)lhs == (Expr)(Sca)rhs;
    public static Ineq operator !=(Var0 lhs, Set rhs)
        => (Expr)lhs != (Expr)(Sca)rhs;
    public static Ineq operator ==(Set lhs, Var0 rhs)
        => (Expr)(Sca)lhs == (Expr)rhs;
    public static Ineq operator !=(Set lhs, Var0 rhs)
        => (Expr)(Sca)lhs != (Expr)rhs;
    public static Ineq operator <=(Var0 lhs, Set rhs)
        => (Expr)lhs <= new Expr(Some((Sca)rhs), default, default);
    public static Ineq operator >=(Var0 lhs, Set rhs)
        => (Expr)lhs >= new Expr(Some((Sca)rhs), default, default);
    public static Ineq operator <=(Set lhs, Var0 rhs)
        => new Expr(Some((Sca)lhs), default, default) <= (Expr)rhs;
    public static Ineq operator >=(Set lhs, Var0 rhs)
        => new Expr(Some((Sca)lhs), default, default) >= (Expr)rhs;


    // op - obj
    public static ObjFun operator |(ObjDir direction, Var0 s)
        => new(direction, (Var)s);
}
