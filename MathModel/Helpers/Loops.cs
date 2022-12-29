namespace MathProg.Helpers;

internal static class Loops
{
    // general
    internal static double Run1(Indices allIndices, int[] state, Func<int[], double> funState,
        int s1)
    {
        double val = 0.0;
        var g1 = allIndices[s1].Set.GetGen()(state);
        foreach (var i1 in g1)
        {
            state[s1] = i1;
            val += funState(state);
        }
        return val;
    }
    internal static double Run2(Indices allIndices, int[] state, Func<int[], double> funState,
        int s1, int s2)
    {
        double val = 0.0;
        var g1 = allIndices[s1].Set.GetGen()(state);
        foreach (var i1 in g1)
        {
            state[s1] = i1;
            val += Run1(allIndices, state, funState, s2);
        }
        return val;
    }
    internal static double Run3(Indices allIndices, int[] state, Func<int[], double> funState,
        int s1, int s2, int s3)
    {
        double val = 0.0;
        var g1 = allIndices[s1].Set.GetGen()(state);
        foreach (var i1 in g1)
        {
            state[s1] = i1;
            val += Run2(allIndices, state, funState, s2, s3);
        }
        return val;
    }
    internal static double Run4(Indices allIndices, int[] state, Func<int[], double> funState,
        int s1, int s2, int s3, int s4)
    {
        double val = 0.0;
        var g1 = allIndices[s1].Set.GetGen()(state);
        foreach (var i1 in g1)
        {
            state[s1] = i1;
            val += Run3(allIndices, state, funState, s2, s3, s4);
        }
        return val;
    }
    internal static double Run5(Indices allIndices, int[] state, Func<int[], double> funState,
        int s1, int s2, int s3, int s4, int s5)
    {
        double val = 0.0;
        var g1 = allIndices[s1].Set.GetGen()(state);
        foreach (var i1 in g1)
        {
            state[s1] = i1;
            val += Run4(allIndices, state, funState, s2, s3, s4, s5);
        }
        return val;
    }
    internal static double Run6(Indices allIndices, int[] state, Func<int[], double> funState,
        int s1, int s2, int s3, int s4, int s5, int s6)
    {
        double val = 0.0;
        var g1 = allIndices[s1].Set.GetGen()(state);
        foreach (var i1 in g1)
        {
            state[s1] = i1;
            val += Run5(allIndices, state, funState, s2, s3, s4, s5, s6);
        }
        return val;
    }
    internal static double Run7(Indices allIndices, int[] state, Func<int[], double> funState,
        int s1, int s2, int s3, int s4, int s5, int s6, int s7)
    {
        double val = 0.0;
        var g1 = allIndices[s1].Set.GetGen()(state);
        foreach (var i1 in g1)
        {
            state[s1] = i1;
            val += Run6(allIndices, state, funState, s2, s3, s4, s5, s6, s7);
        }
        return val;
    }
    internal static double Run8(Indices allIndices, int[] state, Func<int[], double> funState,
        int s1, int s2, int s3, int s4, int s5, int s6, int s7, int s8)
    {
        double val = 0.0;
        var g1 = allIndices[s1].Set.GetGen()(state);
        foreach (var i1 in g1)
        {
            state[s1] = i1;
            val += Run7(allIndices, state, funState, s2, s3, s4, s5, s6, s7, s8);
        }
        return val;
    }
    internal static double Run9(Indices allIndices, int[] state, Func<int[], double> funState,
        int s1, int s2, int s3, int s4, int s5, int s6, int s7, int s8, int s9)
    {
        double val = 0.0;
        var g1 = allIndices[s1].Set.GetGen()(state);
        foreach (var i1 in g1)
        {
            state[s1] = i1;
            val += Run8(allIndices, state, funState, s2, s3, s4, s5, s6, s7, s8, s9);
        }
        return val;
    }
    internal static double Run10(Indices allIndices, int[] state, Func<int[], double> funState,
        int s1, int s2, int s3, int s4, int s5, int s6, int s7, int s8, int s9, int s10)
    {
        double val = 0.0;
        var g1 = allIndices[s1].Set.GetGen()(state);
        foreach (var i1 in g1)
        {
            state[s1] = i1;
            val += Run9(allIndices, state, funState, s2, s3, s4, s5, s6, s7, s8, s9, s10);
        }
        return val;
    }


    // var
    internal static void LoopVar(Var1 var, StreamWriter w, Action<StreamWriter, int[], Var, int> funWriter)
    {
        Var genVar = new(var, (Sca)var.I1);
        Indices indices = new(var.I1);
        var state = new int[indices.Length];
        genVar = genVar.SetIndices(indices, string.Empty);
        Run1(indices, state, st =>
        {
            int i = genVar.Indices[0].GetCurrValueAsInt(st);
            funWriter(w, st, genVar, i);
            return 0.0;
        }, 0);
    }
    internal static void LoopVar(Var2 var, StreamWriter w, Action<StreamWriter, int[], Var, int, int> funWriter)
    {
        Var genVar = new(var, new((Sca)var.Indices.I1, (Sca)var.Indices.I2));
        Indices indices = new(new OptList<Set>(var.Indices.I1, var.Indices.I2));
        var state = new int[indices.Length];
        genVar = genVar.SetIndices(indices, string.Empty);
        Run2(indices, state, st =>
        {
            int i = genVar.Indices[0].GetCurrValueAsInt(state);
            int j = genVar.Indices[1].GetCurrValueAsInt(state);
            funWriter(w, st, genVar, i, j);
            return 0.0;
        }, 0, 1);
    }
    internal static void LoopVar(Var3 var, StreamWriter w, Action<StreamWriter, int[], Var, int, int, int> funWriter)
    {
        Var genVar = new(var, new OptList<Sca>(new List<Sca>()
        {
            var.Indices.I1, var.Indices.I2, var.Indices.I3
        }));
        Indices indices = new(new OptList<Set>(new List<Set>()
        {
            var.Indices.I1, var.Indices.I2, var.Indices.I3
        }));
        var state = new int[indices.Length];
        genVar = genVar.SetIndices(indices, string.Empty);
        Run3(indices, state, st =>
        {
            int i = genVar.Indices[0].GetCurrValueAsInt(state);
            int j = genVar.Indices[1].GetCurrValueAsInt(state);
            int k = genVar.Indices[2].GetCurrValueAsInt(state);
            funWriter(w, st, genVar, i, j, k);
            return 0.0;
        }, 0, 1, 2);
    }
    internal static void LoopVar(Var4 var, StreamWriter w, Action<StreamWriter, int[], Var, int, int, int, int> funWriter)
    {
        Var genVar = new(var, new OptList<Sca>(new List<Sca>()
        {
          var.Indices.I1, var.Indices.I2, var.Indices.I3, var.Indices.I4
        }));
        Indices indices = new(new OptList<Set>(new List<Set>()
        {
            var.Indices.I1, var.Indices.I2, var.Indices.I3, var.Indices.I4
        }));
        var state = new int[indices.Length];
        genVar = genVar.SetIndices(indices, string.Empty);
        Run4(indices, state, st =>
        {
            int i = genVar.Indices[0].GetCurrValueAsInt(state);
            int j = genVar.Indices[1].GetCurrValueAsInt(state);
            int k = genVar.Indices[2].GetCurrValueAsInt(state);
            int l = genVar.Indices[3].GetCurrValueAsInt(state);
            funWriter(w, st, genVar, i, j, k, l);
            return 0.0;
        }, 0, 1, 2, 3);
    }
    internal static void LoopVar(Var5 var, StreamWriter w, Action<StreamWriter, int[], Var, int, int, int, int, int> funWriter)
    {
        Var genVar = new(var, new OptList<Sca>(new List<Sca>()
        {
            var.Indices.I1, var.Indices.I2, var.Indices.I3, var.Indices.I4, var.Indices.I5
        }));
        Indices indices = new(new OptList<Set>(new List<Set>()
        {
            var.Indices.I1, var.Indices.I2, var.Indices.I3, var.Indices.I4, var.Indices.I5
        }));
        var state = new int[indices.Length];
        genVar = genVar.SetIndices(indices, string.Empty);
        Run5(indices, state, st =>
        {
            int i = genVar.Indices[0].GetCurrValueAsInt(state);
            int j = genVar.Indices[1].GetCurrValueAsInt(state);
            int k = genVar.Indices[2].GetCurrValueAsInt(state);
            int l = genVar.Indices[3].GetCurrValueAsInt(state);
            int m = genVar.Indices[4].GetCurrValueAsInt(state);
            funWriter(w, st, genVar, i, j, k, l, m);
            return 0.0;
        }, 0, 1, 2, 3, 4);
    }
    internal static void LoopVar(Var6 var, StreamWriter w, Action<StreamWriter, int[], Var, int, int, int, int, int, int> funWriter)
    {
        Var genVar = new(var, new OptList<Sca>(new List<Sca>()
        {
           var.Indices.I1, var.Indices.I2, var.Indices.I3, var.Indices.I4, var.Indices.I5,
            var.Indices.I6
        }));
        Indices indices = new(new OptList<Set>(new List<Set>()
        {
            var.Indices.I1, var.Indices.I2, var.Indices.I3, var.Indices.I4, var.Indices.I5,
            var.Indices.I6
        }));
        var state = new int[indices.Length];
        genVar = genVar.SetIndices(indices, string.Empty);
        Run6(indices, state, st =>
        {
            int i = genVar.Indices[0].GetCurrValueAsInt(state);
            int j = genVar.Indices[1].GetCurrValueAsInt(state);
            int k = genVar.Indices[2].GetCurrValueAsInt(state);
            int l = genVar.Indices[3].GetCurrValueAsInt(state);
            int m = genVar.Indices[4].GetCurrValueAsInt(state);
            int n = genVar.Indices[5].GetCurrValueAsInt(state);
            funWriter(w, st, genVar, i, j, k, l, m, n);
            return 0.0;
        }, 0, 1, 2, 3, 4, 5);
    }
    internal static void LoopVar(Var7 var, StreamWriter w, Action<StreamWriter, int[], Var, int, int, int, int, int, int, int> funWriter)
    {
        Var genVar = new(var, new OptList<Sca>(new List<Sca>()
        {
            var.Indices.I1, var.Indices.I2, var.Indices.I3, var.Indices.I4, var.Indices.I5,
            var.Indices.I6, var.Indices.I7
        }));
        Indices indices = new(new OptList<Set>(new List<Set>()
        {
            var.Indices.I1, var.Indices.I2, var.Indices.I3, var.Indices.I4, var.Indices.I5,
            var.Indices.I6, var.Indices.I7
        }));
        var state = new int[indices.Length];
        genVar = genVar.SetIndices(indices, string.Empty);
        Run7(indices, state, st =>
        {
            int i = genVar.Indices[0].GetCurrValueAsInt(state);
            int j = genVar.Indices[1].GetCurrValueAsInt(state);
            int k = genVar.Indices[2].GetCurrValueAsInt(state);
            int l = genVar.Indices[3].GetCurrValueAsInt(state);
            int m = genVar.Indices[4].GetCurrValueAsInt(state);
            int n = genVar.Indices[5].GetCurrValueAsInt(state);
            int o = genVar.Indices[6].GetCurrValueAsInt(state);
            funWriter(w, st, genVar, i, j, k, l, m, n, o);
            return 0.0;
        }, 0, 1, 2, 3, 4, 5, 6);
    }
    internal static void LoopVar(Var8 var, StreamWriter w, Action<StreamWriter, int[], Var, int, int, int, int, int, int, int, int> funWriter)
    {
        Var genVar = new(var, new OptList<Sca>(new List<Sca>()
        {
            var.Indices.I1, var.Indices.I2, var.Indices.I3, var.Indices.I4, var.Indices.I5,
            var.Indices.I6, var.Indices.I7, var.Indices.I8,
        }));
        Indices indices = new(new OptList<Set>(new List<Set>()
        {
            var.Indices.I1, var.Indices.I2, var.Indices.I3, var.Indices.I4, var.Indices.I5,
            var.Indices.I6, var.Indices.I7, var.Indices.I8,
        }));
        var state = new int[indices.Length];
        genVar = genVar.SetIndices(indices, string.Empty);
        Run8(indices, state, st =>
        {
            int i = genVar.Indices[0].GetCurrValueAsInt(state);
            int j = genVar.Indices[1].GetCurrValueAsInt(state);
            int k = genVar.Indices[2].GetCurrValueAsInt(state);
            int l = genVar.Indices[3].GetCurrValueAsInt(state);
            int m = genVar.Indices[4].GetCurrValueAsInt(state);
            int n = genVar.Indices[5].GetCurrValueAsInt(state);
            int o = genVar.Indices[6].GetCurrValueAsInt(state);
            int p = genVar.Indices[7].GetCurrValueAsInt(state);
            funWriter(w, st, genVar, i, j, k, l, m, n, o, p);
            return 0.0;
        }, 0, 1, 2, 3, 4, 5, 6, 7);
    }
    internal static void LoopVar(Var9 var, StreamWriter w, Action<StreamWriter, int[], Var, int, int, int, int, int, int, int, int, int> funWriter)
    {
        Var genVar = new(var, new OptList<Sca>(new List<Sca>()
        {
            var.Indices.I1, var.Indices.I2, var.Indices.I3, var.Indices.I4, var.Indices.I5,
            var.Indices.I6, var.Indices.I7, var.Indices.I8, var.Indices.I9,
        }));
        Indices indices = new(new OptList<Set>(new List<Set>()
        {
            var.Indices.I1, var.Indices.I2, var.Indices.I3, var.Indices.I4, var.Indices.I5,
            var.Indices.I6, var.Indices.I7, var.Indices.I8, var.Indices.I9,
        }));
        var state = new int[indices.Length];
        genVar = genVar.SetIndices(indices, string.Empty);
        Run9(indices, state, st =>
        {
            int i = genVar.Indices[0].GetCurrValueAsInt(state);
            int j = genVar.Indices[1].GetCurrValueAsInt(state);
            int k = genVar.Indices[2].GetCurrValueAsInt(state);
            int l = genVar.Indices[3].GetCurrValueAsInt(state);
            int m = genVar.Indices[4].GetCurrValueAsInt(state);
            int n = genVar.Indices[5].GetCurrValueAsInt(state);
            int o = genVar.Indices[6].GetCurrValueAsInt(state);
            int p = genVar.Indices[7].GetCurrValueAsInt(state);
            int q = genVar.Indices[8].GetCurrValueAsInt(state);
            funWriter(w, st, genVar, i, j, k, l, m, n, o, p, q);
            return 0.0;
        }, 0, 1, 2, 3, 4, 5, 6, 7, 8);
    }
    internal static void LoopVar(Var10 var, StreamWriter w, Action<StreamWriter, int[], Var, int, int, int, int, int, int, int, int, int, int> funWriter)
    {
        Var genVar = new(var, new OptList<Sca>(new List<Sca>()
        {
            var.Indices.I1, var.Indices.I2, var.Indices.I3, var.Indices.I4, var.Indices.I5,
            var.Indices.I6, var.Indices.I7, var.Indices.I8, var.Indices.I9, var.Indices.I10,
        }));
        Indices indices = new(new OptList<Set>(new List<Set>()
        {
            var.Indices.I1, var.Indices.I2, var.Indices.I3, var.Indices.I4, var.Indices.I5,
            var.Indices.I6, var.Indices.I7, var.Indices.I8, var.Indices.I9, var.Indices.I10,
        }));
        var state = new int[indices.Length];
        genVar = genVar.SetIndices(indices, string.Empty);
        Run10(indices, state, st =>
        {
            int i = genVar.Indices[0].GetCurrValueAsInt(state);
            int j = genVar.Indices[1].GetCurrValueAsInt(state);
            int k = genVar.Indices[2].GetCurrValueAsInt(state);
            int l = genVar.Indices[3].GetCurrValueAsInt(state);
            int m = genVar.Indices[4].GetCurrValueAsInt(state);
            int n = genVar.Indices[5].GetCurrValueAsInt(state);
            int o = genVar.Indices[6].GetCurrValueAsInt(state);
            int p = genVar.Indices[7].GetCurrValueAsInt(state);
            int q = genVar.Indices[8].GetCurrValueAsInt(state);
            int r = genVar.Indices[9].GetCurrValueAsInt(state);
            funWriter(w, st, genVar, i, j, k, l, m, n, o, p, q, r);
            return 0.0;
        }, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9);
    }
}
