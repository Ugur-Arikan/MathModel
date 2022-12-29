namespace MathProg;

internal static class HelperExtensions
{
    // OptList - ScaTerm
    public static OptList<ScaTerm> Neg(this OptList<ScaTerm> list)
        => list.Map(s => -s);
    public static OptList<ScaTerm> Reciprocal(this OptList<ScaTerm> list)
        => list.Map(s => s.Reciprocal());
    public static OptList<ScaTerm> Mul(this OptList<ScaTerm> list, double n)
        => list.Map(s => s * n);
    public static OptList<ScaTerm> Div(this OptList<ScaTerm> list, double n)
        => list.Map(s => s / n);
    public static OptList<ScaTerm> Mul(this OptList<ScaTerm> x, OptList<ScaTerm> y)
    {
        if (x.Length == 0 || y.Length == 0)
            return default;
        if (x.Length == 1)
        {
            if (y.Length == 1)
                return new(x[0] * y[0]);
            else if (y.Length == 2)
                return new(x[0] * y[0], x[0] * y[1]);
        }
        else if (x.Length == 2 && y.Length == 1)
            return new(x[0] * y[0], x[1] * y[0]);
        
        return MulList(x, y);
    }
    static OptList<ScaTerm> MulList(this OptList<ScaTerm> x, OptList<ScaTerm> y)
    {
        var lst = new List<ScaTerm>(x.Length * y.Length);
        for (int i = 0; i < x.Length; i++)
            for (int j = 0; j < y.Length; j++)
                lst.Add(x[i] * y[j]);
        Debug.Assert(lst.Count > 2);
        return new(lst);
    }


    // OptList - Term
    public static OptList<Term> Neg(this OptList<Term> terms)
        => terms.Map(t => -t);
    public static OptList<Term> Mul(this OptList<Term> terms, double num)
        => terms.Map(t => t * num);
    public static OptList<Term> Div(this OptList<Term> terms, double num)
        => terms.Map(t => t / num);
    public static OptList<Term> Mul(this OptList<Term> terms, Sca sca)
        => terms.Map(t => t * sca);
    public static OptList<Term> Div(this OptList<Term> terms, Sca sca)
        => terms.Map(t => t / sca);


    // OptList - Sum
    public static OptList<Sum> Neg(this OptList<Sum> sums)
        => sums.Map(t => -t);
    public static OptList<Sum> Mul(this OptList<Sum> sums, double num)
        => sums.Map(t => t * num);
    public static OptList<Sum> Div(this OptList<Sum> sums, double num)
        => sums.Map(t => t / num);
    public static OptList<Sum> Mul(this OptList<Sum> sums, Sca sca)
        => sums.Map(t => t * sca);
    public static OptList<Sum> Div(this OptList<Sum> sums, Sca sca)
        => sums.Map(t => t / sca);


    // Opt - Sca
    public static Opt<Sca> Neg(this Opt<Sca> s)
        => s.IsNone ? default : Some(-s.Unwrap());
    public static Opt<Sca> Mul(this Opt<Sca> s, double num)
        => s.IsNone ? default : Some(num * s.Unwrap());
    public static Opt<Sca> Div(this Opt<Sca> s, double num)
        => s.IsNone ? default : Some(s.Unwrap() / num);
    public static Opt<Sca> Mul(this Opt<Sca> s, Sca num)
        => s.IsNone ? default : Some(num * s.Unwrap());
    public static Opt<Sca> Div(this Opt<Sca> s, Sca num)
        => s.IsNone ? default : Some(s.Unwrap() / num);
    public static Opt<Sca> Add(this Opt<Sca> s, Opt<Sca> t)
        => s.IsNone ? t : (t.IsNone ? s : Some(s.Unwrap() + t.Unwrap()));


    // OptList
    static OptList<T> Map<T>(this OptList<T> list, Func<T, T> fun)
    {
        if (list.Length == 0)
            return default;
        if (list.Length == 1)
            return new(fun(list[0]));
        if (list.Length == 2)
            return new(fun(list[0]), fun(list[1]));
        var newList = new List<T>(list.Length);
        for (int i = 0; i < list.Length; i++)
            newList.Add(fun(list[i]));
        return new(newList);
    }
}
