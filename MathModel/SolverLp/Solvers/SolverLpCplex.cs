namespace MathProg;

public class SolverLpCplex : SolverLp
{
    // data
    readonly ParamsCplex Pars;


    // ctor
    public SolverLpCplex(Opt<ParamsCplex> paramsCplex = default)
        : base(paramsCplex.Map(x => x.PathTempDir).UnwrapOr(() => Path.GetTempPath()))
    {
        Pars = paramsCplex.UnwrapOr(() => new());
    }



    // method
    public override SolverType SolverType => SolverType.Cplex;
    public override ParamsCplex Params => Pars;


    // solve
    internal override SolverLpExecution GetExecution(string pathLp, string pathSoln)
    {
        var commands = new string[]
        {
            $"-c \"set timelimit {Pars.TimeLimitSec}\"",
            $"-c \"set mip tolerances mipgap {Pars.Gap}\"",
            $"-c \"set mip tolerances absmipgap {Pars.AbsGap}\"",
            $"-c \"read {pathLp}\"",
            "-c \"optimize\"",
            $"-c \"write {pathSoln}\"",
        };
        string args = string.Join(' ', commands);
        return new(Pars, args);
    }
    public override SolnMpCplex Solve(Model model, HashSet<IVar> varsToCache)
        => new(model, this, varsToCache);
    public SolnMpCplex Solve(Model model, params IVar[] varsToCache)
        => Solve(model, varsToCache.ToHashSet());
}
