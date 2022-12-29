namespace MathProg;

public abstract class SolnMp : IDisposable
{
    // enum
    protected enum LineType { Skip, Break, Var, ObjVal, Status }


    // data - files
    readonly string PathLp, PathSol;
    readonly Res ResSolve;
    // data - mut
    protected Opt<string> OptStatus = default;
    protected Opt<double> OptObjVal = default;
    bool Disposed = false;


    // data - var vals
    protected int IndFirstUnderscore;
    protected readonly int[] Ind = new int[10];
    readonly Dictionary<string, int> VarDims = new();
    readonly Dictionary<string, SolnVar0> VarVal0 = new();
    readonly Dictionary<string, SolnVar1> VarVal1 = new();
    readonly Dictionary<string, SolnVar2> VarVal2 = new();
    readonly Dictionary<string, SolnVar3> VarVal3 = new();
    readonly Dictionary<string, SolnVar4> VarVal4 = new();
    readonly Dictionary<string, SolnVar5> VarVal5 = new();
    readonly Dictionary<string, SolnVar6> VarVal6 = new();
    readonly Dictionary<string, SolnVar7> VarVal7 = new();
    readonly Dictionary<string, SolnVar8> VarVal8 = new();
    readonly Dictionary<string, SolnVar9> VarVal9 = new();
    readonly Dictionary<string, SolnVar10> VarVal10 = new();


    // ctor
    protected SolnMp(Model model, SolverLp solver, HashSet<IVar> varsToCache)
    {
        // init
        string randName = Path.GetRandomFileName();
        PathLp = Path.Combine(solver.PathTempDir, randName + ".lp");
        PathSol = Path.Combine(solver.PathTempDir, randName + ".sol");

        // solve
        ResSolve = Solve(model, solver, PathLp, PathSol);
        if (ResSolve.IsOk)
        {
            // infeasible
            if (!File.Exists(PathSol))
                OptStatus = "Infeasible";
            // solved
            else
                ParseSolFile(varsToCache, PathSol);
        }
    }
    public void Dispose()
    {

        if (Disposed)
            return;

        Io.DeleteFileIfExists(PathSol);
        Io.DeleteFileIfExists(PathLp);

        Disposed = true;
        GC.SuppressFinalize(this);
    }


    // method - solve
    static Res Solve(Model model, SolverLp solver, string pathLp, string pathSol)
    {
        var resParams = solver.Params.Validate();
        if (resParams.IsErr)
            return resParams;

        var resLp = Ok().TryMap(() => model.CreateLpFile(pathLp));
        
        if (resLp.IsErr)
            return resLp.WithoutVal();
        
        if (resLp.IsOk && resLp.Unwrap().Any())
            return Err(resLp.Unwrap().ToString());

        return
             Ok().TryMap(() =>
            {
                using var exec = solver.GetExecution(pathLp, pathSol);
                return exec.Exe();
            })
            .Flatten();
    }
    // method - parse
    void ParseSolFile(HashSet<IVar> vars, string pathSol)
    {
        InitVarDicts(vars);
        Parse(pathSol);
    }
    void InitVarDicts(HashSet<IVar> vars)
    {
        foreach (var var in vars)
        {
            VarDims.Add(var.Key, var.Dim);
            switch (var)
            {
                case Var0 var0: VarVal0.Add(var0.Key, new(var0, var0.Bounds.Lower.Value)); break;
                case Var1 var1: VarVal1.Add(var1.Key, new(var1, new())); break;
                case Var2 var2: VarVal2.Add(var2.Key, new(var2, new())); break;
                case Var3 var3: VarVal3.Add(var3.Key, new(var3, new())); break;
                case Var4 var4: VarVal4.Add(var4.Key, new(var4, new())); break;
                case Var5 var5: VarVal5.Add(var5.Key, new(var5, new())); break;
                case Var6 var6: VarVal6.Add(var6.Key, new(var6, new())); break;
                case Var7 var7: VarVal7.Add(var7.Key, new(var7, new())); break;
                case Var8 var8: VarVal8.Add(var8.Key, new(var8, new())); break;
                case Var9 var9: VarVal9.Add(var9.Key, new(var9, new())); break;
                case Var10 var10: VarVal10.Add(var10.Key, new(var10, new())); break;
                default: throw Exc.DimHigherThan10;
            }
        }
    }
    int SetIndicesGetDim(string strName)
    {
        var remaining = strName.AsSpan();
        IndFirstUnderscore = remaining.IndexOf('_');
        if (IndFirstUnderscore == -1)
            return 0;

        remaining = remaining[(IndFirstUnderscore + 1)..];
        for (int i = 0; i < Ind.Length; i++)
        {
            int ind = remaining.IndexOf('_');
            if (ind == -1)
            {
                Ind[i] = int.Parse(remaining);
                return i + 1;
            }
            else
            {
                Ind[i] = int.Parse(remaining[..ind]);
            }
            remaining = remaining[(ind + 1)..];
        }
        return Ind.Length;
    }
    protected abstract LineType GetLineType(ReadOnlySpan<char> line);
    protected abstract (string, double) ParseNameAndValue(ReadOnlySpan<char> line);
    protected abstract Opt<double> ParseObjVal(ReadOnlySpan<char> line);
    protected abstract Opt<string> ParseStatus(ReadOnlySpan<char> line);
    void ParseLine(ReadOnlySpan<char> line)
    {
        (string strName, double val) = ParseNameAndValue(line);
        int dim = SetIndicesGetDim(strName);
        
        string key = dim == 0 ? strName : strName[..IndFirstUnderscore];
        if (!VarDims.TryGetValue(key, out int dimVar))
            return;

        Debug.Assert(dim == dimVar, "Dim-of-variable");

        switch (dim)
        {
            case 0:
                VarVal0[key] = VarVal0[key] with { Val = val };
                break;
            case 1:
                VarVal1[key].Vals[Ind[0]] = val;
                break;
            case 2:
                VarVal2[key].Vals[(Ind[0], Ind[1])] = val;
                break;
            case 3:
                VarVal3[key].Vals[(Ind[0], Ind[1], Ind[2])] = val;
                break;
            case 4:
                VarVal4[key].Vals[(Ind[0], Ind[1], Ind[2], Ind[3])] = val;
                break;
            case 5:
                VarVal5[key].Vals[(Ind[0], Ind[1], Ind[2], Ind[3], Ind[4])] = val;
                break;
            case 6:
                VarVal6[key].Vals[(Ind[0], Ind[1], Ind[2], Ind[3], Ind[4], Ind[5])] = val;
                break;
            case 7:
                VarVal7[key].Vals[(Ind[0], Ind[1], Ind[2], Ind[3], Ind[4], Ind[5], Ind[6])] = val;
                break;
            case 8:
                VarVal8[key].Vals[(Ind[0], Ind[1], Ind[2], Ind[3], Ind[4], Ind[5], Ind[6], Ind[7])] = val;
                break;
            case 9:
                VarVal9[key].Vals[(Ind[0], Ind[1], Ind[2], Ind[3], Ind[4], Ind[5], Ind[6], Ind[7], Ind[8])] = val;
                break;
            case 10:
                VarVal10[key].Vals[(Ind[0], Ind[1], Ind[2], Ind[3], Ind[4], Ind[5], Ind[6], Ind[7], Ind[8], Ind[9])] = val;
                break;
            default:
                throw Exc.DimHigherThan10;
        }
    }
    protected void Parse(string pathSol)
    {
        using var reader = new StreamReader(pathSol);
        while (!reader.EndOfStream)
        {
            string? strline = reader.ReadLine();
            if (strline == null)
                continue;

            var line = strline.AsSpan().Trim();
            var lineTyp = GetLineType(line);
            if (lineTyp == LineType.Break)
                break;
            if (lineTyp == LineType.Skip)
                continue;
            switch (lineTyp)
            {
                case LineType.Var: ParseLine(line); break;
                case LineType.ObjVal: OptObjVal = ParseObjVal(line); break;
                case LineType.Status: OptStatus = ParseStatus(line); break;
                default: throw Exc.MissingEnum(lineTyp);
            }
        }
    }


    // method - summary
    public string Status
        => OptStatus.UnwrapOr("NotSolved");
    public double ObjVal
        => OptObjVal.UnwrapOr(double.NegativeInfinity);
    public bool IsFeasible
        => ResSolve.IsOk && OptStatus.Map(s => IsStatusSolved(s)).UnwrapOr(false);


    // method - var
    public SolnVar0 GetVals(Var0 var)
        => VarVal0[var.Key];
    public SolnVar1 GetVals(Var1 var)
        => VarVal1[var.Key];
    public SolnVar2 GetVals(Var2 var)
        => VarVal2[var.Key];
    public SolnVar3 GetVals(Var3 var)
        => VarVal3[var.Key];
    public SolnVar4 GetVals(Var4 var)
        => VarVal4[var.Key];
    public SolnVar5 GetVals(Var5 var)
        => VarVal5[var.Key];
    public SolnVar6 GetVals(Var6 var)
        => VarVal6[var.Key];
    public SolnVar7 GetVals(Var7 var)
        => VarVal7[var.Key];
    public SolnVar8 GetVals(Var8 var)
        => VarVal8[var.Key];
    public SolnVar9 GetVals(Var9 var)
        => VarVal9[var.Key];
    public SolnVar10 GetVals(Var10 var)
        => VarVal10[var.Key];


    // helper
    static bool IsStatusSolved(string solutionStatusString)
    {
        return solutionStatusString == "optimal"
            || solutionStatusString == "integer optimal solution"
            || solutionStatusString == "integer optimal, tolerance"
            || solutionStatusString.Contains("optimal");
    }


    // common
    public string Summary()
    {
        var sb = new StringBuilder();
        sb.Append("Result:\t").AppendLine(ResSolve.ToString());
        if (ResSolve.IsOk)
        {
            sb.Append("Status:\t").AppendLine(Status)
                .Append("ObjVal:\t").Append(ObjVal.ToString());
        }
        return sb.ToString();
    }
}
