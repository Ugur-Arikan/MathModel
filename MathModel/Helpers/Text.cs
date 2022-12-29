namespace MathProg.Helpers;

internal static class Text
{
    internal static string Term<T1, T2>(T1 coef, T2 var)
        => string.Format("{0} {1}", coef, var);
    internal static string Of<T>(string key, OptList<T> items)
        => items.Length == 0 ? key : string.Format("{0}({1})", key, string.Join(',', items));
    
    
    internal static string Sum(Sum sum)
        => string.Format("SUM{{{0} | {1}}}", string.Join(',', sum.Sets), sum.Expr);
    internal static string Expr(Expr expr)
    {
        if (expr.Constant.IsSome)
        {
            if (expr.Terms.Length > 0)
            {
                if (expr.Sums.Length > 0)
                    return string.Format("{0} + {1} + {2}", expr.Constant.Unwrap(), string.Join(" + ", expr.Terms), string.Join(" + ", expr.Sums));
                else
                    return string.Format("{0} + {1}", expr.Constant.Unwrap(), string.Join(" + ", expr.Terms));
            }
            else
            {
                if (expr.Sums.Length > 0)
                    return string.Format("{0} + {1}", expr.Constant.Unwrap(), string.Join(" + ", expr.Sums));
                else
                    return expr.Constant.Unwrap().ToString();
            }
        }
        else
        {
            if (expr.Terms.Length > 0)
            {
                if (expr.Sums.Length > 0)
                    return string.Format("{0} + {1}", string.Join(" + ", expr.Terms), string.Join(" + ", expr.Sums));
                else
                    return string.Join(" + ", expr.Terms);
            }
            else
            {
                if (expr.Sums.Length > 0)
                    return string.Join(" + ", expr.Sums);
                else
                    return string.Empty;
            }
        }
    }
    internal static string RelationStr(this ConstrRelation relation)
    {
        return relation switch
        {
            ConstrRelation.Leq => "<=",
            ConstrRelation.Geq => ">=",
            ConstrRelation.Eq => "=",
            _ => throw Exc.MissingEnum(relation),
        };
    }
    internal static string Ineq(Ineq inequality)
        => string.Format("{0} {1} {2}", inequality.Lhs, inequality.Relation.RelationStr(), inequality.Rhs);


    // Of
    internal static string Of<T>(string key, T i)
        => string.Format("{0}_{1}", key, i);
    internal static string Of<T>(string key, T i1, T i2)
        => string.Format("{0}_{1}_{2}", key, i1, i2);
    internal static string Of<T>(string key, T i1, T i2, T i3)
        => string.Format("{0}_{1}_{2}_{3}", key, i1, i2, i3);
    internal static string Of<T>(string key, T i1, T i2, T i3, T i4)
        => string.Format("{0}_{1}_{2}_{3}_{4}", key, i1, i2, i3, i4);
    internal static string Of<T>(string key, T i1, T i2, T i3, T i4, T i5)
        => string.Format("{0}_{1}_{2}_{3}_{4}_{5}", key, i1, i2, i3, i4, i5);
    internal static string Of<T>(string key, T i1, T i2, T i3, T i4, T i5, T i6)
        => string.Format("{0}_{1}_{2}_{3}_{4}_{5}_{6}", key, i1, i2, i3, i4, i5, i6);
    internal static string Of<T>(string key, T i1, T i2, T i3, T i4, T i5, T i6, T i7)
        => string.Format("{0}_{1}_{2}_{3}_{4}_{5}_{6}_{7}", key, i1, i2, i3, i4, i5, i6, i7);
    internal static string Of<T>(string key, T i1, T i2, T i3, T i4, T i5, T i6, T i7, T i8)
        => string.Format("{0}_{1}_{2}_{3}_{4}_{5}_{6}_{7}_{8}", key, i1, i2, i3, i4, i5, i6, i7, i8);
    internal static string Of<T>(string key, T i1, T i2, T i3, T i4, T i5, T i6, T i7, T i8, T i9)
        => string.Format("{0}_{1}_{2}_{3}_{4}_{5}_{6}_{7}_{8}_{9}", key, i1, i2, i3, i4, i5, i6, i7, i8, i9);
    internal static string Of<T>(string key, T i1, T i2, T i3, T i4, T i5, T i6, T i7, T i8, T i9, T i10)
        => string.Format("{0}_{1}_{2}_{3}_{4}_{5}_{6}_{7}_{8}_{9}_{10}", key, i1, i2, i3, i4, i5, i6, i7, i8, i9, i10);


    // WriteOf
    internal static void WriteOf<T>(this StreamWriter w, string key, T i)
    {
        w.Write(key);
        w.Write('_'); w.Write(i);
    }
    internal static void WriteOf<T>(this StreamWriter w, string key, T i1, T i2)
    {
        w.Write(key);
        w.Write('_'); w.Write(i1);
        w.Write('_'); w.Write(i2);
    }
    internal static void WriteOf<T>(this StreamWriter w, string key, T i1, T i2, T i3)
    {
        w.Write(key);
        w.Write('_'); w.Write(i1);
        w.Write('_'); w.Write(i2);
        w.Write('_'); w.Write(i3);
    }
    internal static void WriteOf<T>(this StreamWriter w, string key, T i1, T i2, T i3, T i4)
    {
        w.Write(key);
        w.Write('_'); w.Write(i1);
        w.Write('_'); w.Write(i2);
        w.Write('_'); w.Write(i3);
        w.Write('_'); w.Write(i4);
    }
    internal static void WriteOf<T>(this StreamWriter w, string key, T i1, T i2, T i3, T i4, T i5)
    {
        w.Write(key);
        w.Write('_'); w.Write(i1);
        w.Write('_'); w.Write(i2);
        w.Write('_'); w.Write(i3);
        w.Write('_'); w.Write(i4);
        w.Write('_'); w.Write(i5);
    }
    internal static void WriteOf<T>(this StreamWriter w, string key, T i1, T i2, T i3, T i4, T i5, T i6)
    {
        w.Write(key);
        w.Write('_'); w.Write(i1);
        w.Write('_'); w.Write(i2);
        w.Write('_'); w.Write(i3);
        w.Write('_'); w.Write(i4);
        w.Write('_'); w.Write(i5);
        w.Write('_'); w.Write(i6);
    }
    internal static void WriteOf<T>(this StreamWriter w, string key, T i1, T i2, T i3, T i4, T i5, T i6, T i7)
    {
        w.Write(key);
        w.Write('_'); w.Write(i1);
        w.Write('_'); w.Write(i2);
        w.Write('_'); w.Write(i3);
        w.Write('_'); w.Write(i4);
        w.Write('_'); w.Write(i5);
        w.Write('_'); w.Write(i6);
        w.Write('_'); w.Write(i7);
    }
    internal static void WriteOf<T>(this StreamWriter w, string key, T i1, T i2, T i3, T i4, T i5, T i6, T i7, T i8)
    {
        w.Write(key);
        w.Write('_'); w.Write(i1);
        w.Write('_'); w.Write(i2);
        w.Write('_'); w.Write(i3);
        w.Write('_'); w.Write(i4);
        w.Write('_'); w.Write(i5);
        w.Write('_'); w.Write(i6);
        w.Write('_'); w.Write(i7);
        w.Write('_'); w.Write(i8);
    }
    internal static void WriteOf<T>(this StreamWriter w, string key, T i1, T i2, T i3, T i4, T i5, T i6, T i7, T i8, T i9)
    {
        w.Write(key);
        w.Write('_'); w.Write(i1);
        w.Write('_'); w.Write(i2);
        w.Write('_'); w.Write(i3);
        w.Write('_'); w.Write(i4);
        w.Write('_'); w.Write(i5);
        w.Write('_'); w.Write(i6);
        w.Write('_'); w.Write(i7);
        w.Write('_'); w.Write(i8);
        w.Write('_'); w.Write(i9);
    }
    internal static void WriteOf<T>(this StreamWriter w, string key, T i1, T i2, T i3, T i4, T i5, T i6, T i7, T i8, T i9, T i10)
    {
        w.Write(key);
        w.Write('_'); w.Write(i1);
        w.Write('_'); w.Write(i2);
        w.Write('_'); w.Write(i3);
        w.Write('_'); w.Write(i4);
        w.Write('_'); w.Write(i5);
        w.Write('_'); w.Write(i6);
        w.Write('_'); w.Write(i7);
        w.Write('_'); w.Write(i8);
        w.Write('_'); w.Write(i9);
        w.Write('_'); w.Write(i10);
    }


    // Keys
    internal static readonly string None = "__NONE__";
}
