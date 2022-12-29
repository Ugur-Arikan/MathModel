namespace MathProg.Lp;

internal static class BoundsWriter
{
    internal static void WriteAll(StreamWriter writer, Model model)
    {
        foreach (var var in model.Vars.Values)
            WriteVar(writer, var);
    }
    static void WriteVar(StreamWriter w, IVar var)
    {
        if (var.IsConstantlyNonneg)
            return;

        switch (var)
        {
            case Var0 var0: WriteVar(w, var0); break;
            case Var1 var1: WriteVar(w, var1); break;
            case Var2 var2: WriteVar(w, var2); break;
            case Var3 var3: WriteVar(w, var3); break;
            case Var4 var4: WriteVar(w, var4); break;
            case Var5 var5: WriteVar(w, var5); break;
            case Var6 var6: WriteVar(w, var6); break;
            case Var7 var7: WriteVar(w, var7); break;
            case Var8 var8: WriteVar(w, var8); break;
            case Var9 var9: WriteVar(w, var9); break;
            case Var10 var10: WriteVar(w, var10); break;
            default: throw Exc.DimHigherThan10;
        }
    }


    // Write Var
    static void WriteVar(StreamWriter w, Var0 var)
        => WriteBoundFor(w, new(var, default), Array.Empty<int>(), var.Bounds.Lower.Value, var.Bounds.Upper.Value);
    static void WriteVar(StreamWriter w, Var1 var)
        => Loops.LoopVar(var, w, (w, st, genVar, i) => WriteBoundFor(w, genVar, st, var.Bounds.Lower[i], var.Bounds.Upper[i]));
    static void WriteVar(StreamWriter w, Var2 var)
        => Loops.LoopVar(var, w, (w, st, genVar, i, j) => WriteBoundFor(w, genVar, st, var.Bounds.Lower[i, j], var.Bounds.Upper[i, j]));
    static void WriteVar(StreamWriter w, Var3 var)
        => Loops.LoopVar(var, w, (w, st, genVar, i, j, k) => WriteBoundFor(w, genVar, st, var.Bounds.Lower[i, j, k], var.Bounds.Upper[i, j, k]));
    static void WriteVar(StreamWriter w, Var4 var)
        => Loops.LoopVar(var, w, (w, st, genVar, i, j, k, l) => WriteBoundFor(w, genVar, st, var.Bounds.Lower[i, j, k, l], var.Bounds.Upper[i, j, k, l]));
    static void WriteVar(StreamWriter w, Var5 var)
        => Loops.LoopVar(var, w, (w, st, genVar, i, j, k, l, m) => WriteBoundFor(w, genVar, st, var.Bounds.Lower[i, j, k, l, m], var.Bounds.Upper[i, j, k, l, m]));
    static void WriteVar(StreamWriter w, Var6 var)
        => Loops.LoopVar(var, w, (w, st, genVar, i, j, k, l, m, n) 
            => WriteBoundFor(w, genVar, st, var.Bounds.Lower[i, j, k, l, m, n], var.Bounds.Upper[i, j, k, l, m, n]));
    static void WriteVar(StreamWriter w, Var7 var)
        => Loops.LoopVar(var, w, (w, st, genVar, i, j, k, l, m, n, o)
            => WriteBoundFor(w, genVar, st, var.Bounds.Lower[i, j, k, l, m, n, o], var.Bounds.Upper[i, j, k, l, m, n, o]));
    static void WriteVar(StreamWriter w, Var8 var)
        => Loops.LoopVar(var, w, (w, st, genVar, i, j, k, l, m, n, o, p)
            => WriteBoundFor(w, genVar, st, var.Bounds.Lower[i, j, k, l, m, n, o, p], var.Bounds.Upper[i, j, k, l, m, n, o, p]));
    static void WriteVar(StreamWriter w, Var9 var)
        => Loops.LoopVar(var, w, (w, st, genVar, i, j, k, l, m, n, o, p, q)
            => WriteBoundFor(w, genVar, st, var.Bounds.Lower[i, j, k, l, m, n, o, p, q], var.Bounds.Upper[i, j, k, l, m, n, o, p, q]));
    static void WriteVar(StreamWriter w, Var10 var)
        => Loops.LoopVar(var, w, (w, st, genVar, i, j, k, l, m, n, o, p, q, r)
            => WriteBoundFor(w, genVar, st, var.Bounds.Lower[i, j, k, l, m, n, o, p, q, r], var.Bounds.Upper[i, j, k, l, m, n, o, p, q, r]));
    static void WriteBoundFor(StreamWriter w, Var v, int[] state, double lower, double upper)
    {
        w.WriteNumAsBound(lower);
        w.Write("<=");
        v.WriteStringFor(w, state);
        w.Write("<=");
        w.WriteNumAsBound(upper);
        w.Write(Environment.NewLine);
    }
}
