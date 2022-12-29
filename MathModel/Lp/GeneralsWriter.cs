namespace MathProg.Lp;

internal static class GeneralsWriter
{
    internal static void WriteAll(StreamWriter writer, Model model)
    {
        foreach (var var in model.Vars.Values)
            WriteVar(writer, var);
        writer.WriteLine();
    }
    static void WriteVar(StreamWriter w, IVar var)
    {
        if (!var.IsDiscrete)
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
        => WriteGeneralsFor(w, new(var, default), Array.Empty<int>());
    static void WriteVar(StreamWriter w, Var1 var)
        => Loops.LoopVar(var, w, (w, st, genVar, i) => WriteGeneralsFor(w, genVar, st));
    static void WriteVar(StreamWriter w, Var2 var)
        => Loops.LoopVar(var, w, (w, st, genVar, i, j) => WriteGeneralsFor(w, genVar, st));
    static void WriteVar(StreamWriter w, Var3 var)
        => Loops.LoopVar(var, w, (w, st, genVar, i, j, k) => WriteGeneralsFor(w, genVar, st));
    static void WriteVar(StreamWriter w, Var4 var)
        => Loops.LoopVar(var, w, (w, st, genVar, i, j, k, l) => WriteGeneralsFor(w, genVar, st));
    static void WriteVar(StreamWriter w, Var5 var)
        => Loops.LoopVar(var, w, (w, st, genVar, i, j, k, l, m) => WriteGeneralsFor(w, genVar, st));
    static void WriteVar(StreamWriter w, Var6 var)
        => Loops.LoopVar(var, w, (w, st, genVar, i, j, k, l, m, n) => WriteGeneralsFor(w, genVar, st));
    static void WriteVar(StreamWriter w, Var7 var)
        => Loops.LoopVar(var, w, (w, st, genVar, i, j, k, l, m, n, o) => WriteGeneralsFor(w, genVar, st));
    static void WriteVar(StreamWriter w, Var8 var)
        => Loops.LoopVar(var, w, (w, st, genVar, i, j, k, l, m, n, o, p) => WriteGeneralsFor(w, genVar, st));
    static void WriteVar(StreamWriter w, Var9 var)
        => Loops.LoopVar(var, w, (w, st, genVar, i, j, k, l, m, n, o, p, q) => WriteGeneralsFor(w, genVar, st));
    static void WriteVar(StreamWriter w, Var10 var)
        => Loops.LoopVar(var, w, (w, st, genVar, i, j, k, l, m, n, o, p, q, r) => WriteGeneralsFor(w, genVar, st));
    static void WriteGeneralsFor(StreamWriter w, Var v, int[] state)
    {
        v.WriteStringFor(w, state);
        w.Write(' ');
    }
}
