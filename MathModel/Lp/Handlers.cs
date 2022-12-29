namespace MathProg.Lp;

static class HandlerDim1
{
    static double Loop(this ExprWriter cw, Expr expr, Func<ExprWriter, Expr, double> handle, int ind1)
    {
        double val = 0.0;
        var gen1 = cw.GetGen(ind1);
        foreach (var i1 in gen1)
        {
            cw.SetState(ind1, i1);
            val += handle(cw, expr);
        }
        return val;
    }
    internal static double Constr(ExprWriter cw)
        => Loops.Run1(cw.AllIndices, cw.State, cw.GetConstrHandler(), 0);
    internal static double Expr(ExprWriter cw, Expr expr, int ind1)
        => cw.Loop(expr, (w, e) => w.HandleExpr0(e), ind1);
}
static class HandlerDim2
{
    static double Loop(this ExprWriter cw, Expr expr, Func<ExprWriter, Expr, double> handle, int ind1, int ind2)
    {
        double val = 0.0;
        var gen1 = cw.GetGen(ind1);
        foreach (var i1 in gen1)
        {
            cw.SetState(ind1, i1);
            var gen2 = cw.GetGen(ind2);
            foreach (var i2 in gen2)
            {
                cw.SetState(ind2, i2);
                val += handle(cw, expr);
            }
        }
        return val;
    }
    internal static double Constr(ExprWriter cw)
        => Loops.Run2(cw.AllIndices, cw.State, cw.GetConstrHandler(), 0, 1);
    internal static double Expr(ExprWriter cw, Expr expr, int ind1, int ind2)
        => cw.Loop(expr, (w, e) => w.HandleExpr0(e), ind1, ind2);
}
static class HandlerDim3
{
    static double Loop(this ExprWriter cw, Expr expr, Func<ExprWriter, Expr, double> handle, int ind1, int ind2, int ind3)
    {
        double val = 0.0;
        var gen1 = cw.GetGen(ind1);
        foreach (var i1 in gen1)
        {
            cw.SetState(ind1, i1);
            var gen2 = cw.GetGen(ind2);
            foreach (var i2 in gen2)
            {
                cw.SetState(ind2, i2);
                var gen3 = cw.GetGen(ind3);
                foreach (var i3 in gen3)
                {
                    cw.SetState(ind3, i3);
                    val += handle(cw, expr);
                }
            }
        }
        return val;
    }
    internal static double Constr(ExprWriter cw)
        => Loops.Run3(cw.AllIndices, cw.State, cw.GetConstrHandler(), 0, 1, 2);
    internal static double Expr(ExprWriter cw, Expr expr, int ind1, int ind2, int ind3)
        => cw.Loop(expr, (w, e) => w.HandleExpr0(e), ind1, ind2, ind3);
}
static class HandlerDim4
{
    static double Loop(this ExprWriter cw, Expr expr, Func<ExprWriter, Expr, double> handle, int ind1, int ind2, int ind3, int ind4)
    {
        double val = 0.0;
        var gen1 = cw.GetGen(ind1);
        foreach (var i1 in gen1)
        {
            cw.SetState(ind1, i1);
            var gen2 = cw.GetGen(ind2);
            foreach (var i2 in gen2)
            {
                cw.SetState(ind2, i2);
                var gen3 = cw.GetGen(ind3);
                foreach (var i3 in gen3)
                {
                    cw.SetState(ind3, i3);
                    var gen4 = cw.GetGen(ind4);
                    foreach (var i4 in gen4)
                    {
                        cw.SetState(ind4, i4);
                        val += handle(cw, expr);
                    }
                }
            }
        }
        return val;
    }
    internal static double Constr(ExprWriter cw)
        => Loops.Run4(cw.AllIndices, cw.State, cw.GetConstrHandler(), 0, 1, 2, 3);
    internal static double Expr(ExprWriter cw, Expr expr, int ind1, int ind2, int ind3, int ind4)
        => cw.Loop(expr, (w, e) => w.HandleExpr0(e), ind1, ind2, ind3, ind4);
}
static class HandlerDim5
{
    static double Loop(this ExprWriter cw, Expr expr, Func<ExprWriter, Expr, double> handle, int ind1, int ind2, int ind3, int ind4, int ind5)
    {
        double val = 0.0;
        var gen1 = cw.GetGen(ind1);
        foreach (var i1 in gen1)
        {
            cw.SetState(ind1, i1);
            var gen2 = cw.GetGen(ind2);
            foreach (var i2 in gen2)
            {
                cw.SetState(ind2, i2);
                var gen3 = cw.GetGen(ind3);
                foreach (var i3 in gen3)
                {
                    cw.SetState(ind3, i3);
                    var gen4 = cw.GetGen(ind4);
                    foreach (var i4 in gen4)
                    {
                        cw.SetState(ind4, i4);
                        var gen5 = cw.GetGen(ind5);
                        foreach (var i5 in gen5)
                        {
                            cw.SetState(ind5, i5);
                            val += handle(cw, expr);
                        }
                    }
                }
            }
        }
        return val;
    }
    internal static double Constr(ExprWriter cw)
        => Loops.Run5(cw.AllIndices, cw.State, cw.GetConstrHandler(), 0, 1, 2, 3, 4);
    internal static double Expr(ExprWriter cw, Expr expr, int ind1, int ind2, int ind3, int ind4, int ind5)
        => cw.Loop(expr, (w, e) => w.HandleExpr0(e), ind1, ind2, ind3, ind4, ind5);
}
static class HandlerDim6
{
    static double Loop(this ExprWriter cw, Expr expr, Func<ExprWriter, Expr, double> handle, int ind1, int ind2, int ind3, int ind4, int ind5, int ind6)
    {
        double val = 0.0;
        var gen1 = cw.GetGen(ind1);
        foreach (var i1 in gen1)
        {
            cw.SetState(ind1, i1);
            var gen2 = cw.GetGen(ind2);
            foreach (var i2 in gen2)
            {
                cw.SetState(ind2, i2);
                var gen3 = cw.GetGen(ind3);
                foreach (var i3 in gen3)
                {
                    cw.SetState(ind3, i3);
                    var gen4 = cw.GetGen(ind4);
                    foreach (var i4 in gen4)
                    {
                        cw.SetState(ind4, i4);
                        var gen5 = cw.GetGen(ind5);
                        foreach (var i5 in gen5)
                        {
                            cw.SetState(ind5, i5);
                            var gen6 = cw.GetGen(ind6);
                            foreach (var i6 in gen6)
                            {
                                cw.SetState(ind6, i6);
                                val += handle(cw, expr);
                            }
                        }
                    }
                }
            }
        }
        return val;
    }
    internal static double Constr(ExprWriter cw)
        => Loops.Run6(cw.AllIndices, cw.State, cw.GetConstrHandler(), 0, 1, 2, 3, 4, 5);
    internal static double Expr(ExprWriter cw, Expr expr, int ind1, int ind2, int ind3, int ind4, int ind5, int ind6)
        => cw.Loop(expr, (w, e) => w.HandleExpr0(e), ind1, ind2, ind3, ind4, ind5, ind6);
}
static class HandlerDim7
{
    static double Loop(this ExprWriter cw, Expr expr, Func<ExprWriter, Expr, double> handle, int ind1, int ind2, int ind3, int ind4, int ind5, int ind6, int ind7)
    {
        double val = 0.0;
        var gen1 = cw.GetGen(ind1);
        foreach (var i1 in gen1)
        {
            cw.SetState(ind1, i1);
            var gen2 = cw.GetGen(ind2);
            foreach (var i2 in gen2)
            {
                cw.SetState(ind2, i2);
                var gen3 = cw.GetGen(ind3);
                foreach (var i3 in gen3)
                {
                    cw.SetState(ind3, i3);
                    var gen4 = cw.GetGen(ind4);
                    foreach (var i4 in gen4)
                    {
                        cw.SetState(ind4, i4);
                        var gen5 = cw.GetGen(ind5);
                        foreach (var i5 in gen5)
                        {
                            cw.SetState(ind5, i5);
                            var gen6 = cw.GetGen(ind6);
                            foreach (var i6 in gen6)
                            {
                                cw.SetState(ind6, i6);
                                var gen7 = cw.GetGen(ind7);
                                foreach (var i7 in gen7)
                                {
                                    cw.SetState(ind7, i7);
                                    val += handle(cw, expr);
                                }
                            }
                        }
                    }
                }
            }
        }
        return val;
    }
    internal static double Constr(ExprWriter cw)
        => Loops.Run7(cw.AllIndices, cw.State, cw.GetConstrHandler(), 0, 1, 2, 3, 4, 5, 6);
    internal static double Expr(ExprWriter cw, Expr expr, int ind1, int ind2, int ind3, int ind4, int ind5, int ind6, int ind7)
        => cw.Loop(expr, (w, e) => w.HandleExpr0(e), ind1, ind2, ind3, ind4, ind5, ind6, ind7);
}
static class HandlerDim8
{
    static double Loop(this ExprWriter cw, Expr expr, Func<ExprWriter, Expr, double> handle, int ind1, int ind2, int ind3, int ind4, int ind5, int ind6, int ind7, int ind8)
    {
        double val = 0.0;
        var gen1 = cw.GetGen(ind1);
        foreach (var i1 in gen1)
        {
            cw.SetState(ind1, i1);
            var gen2 = cw.GetGen(ind2);
            foreach (var i2 in gen2)
            {
                cw.SetState(ind2, i2);
                var gen3 = cw.GetGen(ind3);
                foreach (var i3 in gen3)
                {
                    cw.SetState(ind3, i3);
                    var gen4 = cw.GetGen(ind4);
                    foreach (var i4 in gen4)
                    {
                        cw.SetState(ind4, i4);
                        var gen5 = cw.GetGen(ind5);
                        foreach (var i5 in gen5)
                        {
                            cw.SetState(ind5, i5);
                            var gen6 = cw.GetGen(ind6);
                            foreach (var i6 in gen6)
                            {
                                cw.SetState(ind6, i6);
                                var gen7 = cw.GetGen(ind7);
                                foreach (var i7 in gen7)
                                {
                                    cw.SetState(ind7, i7);
                                    var gen8 = cw.GetGen(ind8);
                                    foreach (var i8 in gen8)
                                    {
                                        cw.SetState(ind8, i8);
                                        val += handle(cw, expr);
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        return val;
    }
    internal static double Constr(ExprWriter cw)
        => Loops.Run8(cw.AllIndices, cw.State, cw.GetConstrHandler(), 0, 1, 2, 3, 4, 5, 6, 7);
    internal static double Expr(ExprWriter cw, Expr expr, int ind1, int ind2, int ind3, int ind4, int ind5, int ind6, int ind7, int ind8)
        => cw.Loop(expr, (w, e) => w.HandleExpr0(e), ind1, ind2, ind3, ind4, ind5, ind6, ind7, ind8);
}
static class HandlerDim9
{
    static double Loop(this ExprWriter cw, Expr expr, Func<ExprWriter, Expr, double> handle, int ind1, int ind2, int ind3, int ind4, int ind5, int ind6, int ind7, int ind8, int ind9)
    {
        double val = 0.0;
        var gen1 = cw.GetGen(ind1);
        foreach (var i1 in gen1)
        {
            cw.SetState(ind1, i1);
            var gen2 = cw.GetGen(ind2);
            foreach (var i2 in gen2)
            {
                cw.SetState(ind2, i2);
                var gen3 = cw.GetGen(ind3);
                foreach (var i3 in gen3)
                {
                    cw.SetState(ind3, i3);
                    var gen4 = cw.GetGen(ind4);
                    foreach (var i4 in gen4)
                    {
                        cw.SetState(ind4, i4);
                        var gen5 = cw.GetGen(ind5);
                        foreach (var i5 in gen5)
                        {
                            cw.SetState(ind5, i5);
                            var gen6 = cw.GetGen(ind6);
                            foreach (var i6 in gen6)
                            {
                                cw.SetState(ind6, i6);
                                var gen7 = cw.GetGen(ind7);
                                foreach (var i7 in gen7)
                                {
                                    cw.SetState(ind7, i7);
                                    var gen8 = cw.GetGen(ind8);
                                    foreach (var i8 in gen8)
                                    {
                                        cw.SetState(ind8, i8);
                                        var gen9 = cw.GetGen(ind9);
                                        foreach (var i9 in gen9)
                                        {
                                            cw.SetState(ind9, i9);
                                            val += handle(cw, expr);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        return val;
    }
    internal static double Constr(ExprWriter cw)
        => Loops.Run9(cw.AllIndices, cw.State, cw.GetConstrHandler(), 0, 1, 2, 3, 4, 5, 6, 7, 8);
    internal static double Expr(ExprWriter cw, Expr expr, int ind1, int ind2, int ind3, int ind4, int ind5, int ind6, int ind7, int ind8, int ind9)
        => cw.Loop(expr, (w, e) => w.HandleExpr0(e), ind1, ind2, ind3, ind4, ind5, ind6, ind7, ind8, ind9);
}
static class HandlerDim10
{
    static double Loop(this ExprWriter cw, Expr expr, Func<ExprWriter, Expr, double> handle, int ind1, int ind2, int ind3, int ind4, int ind5, int ind6, int ind7, int ind8, int ind9, int ind10)
    {
        double val = 0.0;
        var gen1 = cw.GetGen(ind1);
        foreach (var i1 in gen1)
        {
            cw.SetState(ind1, i1);
            var gen2 = cw.GetGen(ind2);
            foreach (var i2 in gen2)
            {
                cw.SetState(ind2, i2);
                var gen3 = cw.GetGen(ind3);
                foreach (var i3 in gen3)
                {
                    cw.SetState(ind3, i3);
                    var gen4 = cw.GetGen(ind4);
                    foreach (var i4 in gen4)
                    {
                        cw.SetState(ind4, i4);
                        var gen5 = cw.GetGen(ind5);
                        foreach (var i5 in gen5)
                        {
                            cw.SetState(ind5, i5);
                            var gen6 = cw.GetGen(ind6);
                            foreach (var i6 in gen6)
                            {
                                cw.SetState(ind6, i6);
                                var gen7 = cw.GetGen(ind7);
                                foreach (var i7 in gen7)
                                {
                                    cw.SetState(ind7, i7);
                                    var gen8 = cw.GetGen(ind8);
                                    foreach (var i8 in gen8)
                                    {
                                        cw.SetState(ind8, i8);
                                        var gen9 = cw.GetGen(ind9);
                                        foreach (var i9 in gen9)
                                        {
                                            cw.SetState(ind9, i9);
                                            var gen10 = cw.GetGen(ind10);
                                            foreach (var i10 in gen10)
                                            {
                                                cw.SetState(ind10, i10);
                                                val += handle(cw, expr);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        return val;
    }
    internal static double Constr(ExprWriter cw)
        => Loops.Run10(cw.AllIndices, cw.State, cw.GetConstrHandler(), 0, 1, 2, 3, 4, 5, 6, 7, 8, 9);
    internal static double Expr(ExprWriter cw, Expr expr, int ind1, int ind2, int ind3, int ind4, int ind5, int ind6, int ind7, int ind8, int ind9, int ind10)
        => cw.Loop(expr, (w, e) => w.HandleExpr0(e), ind1, ind2, ind3, ind4, ind5, ind6, ind7, ind8, ind9, ind10);
}
