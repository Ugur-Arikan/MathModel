namespace MathProg;

public abstract class SolverLp : ISolver
{
    // data
    internal readonly string PathTempDir;



    // ctor
    protected SolverLp(string pathTempDir)
    {
        PathTempDir = pathTempDir;
        if (Directory.Exists(pathTempDir))
            Directory.CreateDirectory(pathTempDir);
    }
    


    // ctor - cplex
    public static SolverLpCplex Cplex()
        => new(default);
    public static SolverLpCplex Cplex(ParamsCplex paramsCplex)
        => new(paramsCplex);
    // ctor - scip);
    public static SolverLpScip Scip()
        => new(default);
    public static SolverLpScip Scip(ParamsScip paramsScip)
        => new(paramsScip);


    // solver-lp
    internal abstract SolverLpExecution GetExecution(string pathLp, string pathSoln);


    // method
    public abstract SolverType SolverType { get; }
    public abstract IParams Params { get; }
    

    // solve
    public abstract SolnMp Solve(Model model, HashSet<IVar> varsToCache);
}
