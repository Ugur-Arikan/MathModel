namespace MathProg;

public class SolverLpScip : SolverLp
{
    // data
    readonly ParamsScip Pars;


    // ctor
    public SolverLpScip(Opt<ParamsScip> paramsScip = default)
        : base(paramsScip.Map(x => x.PathTempDir).UnwrapOr(() => Path.GetTempPath()))
    {
        Pars = paramsScip.UnwrapOr(() => new());
    }


    // solver-lp
    internal override SolverLpExecution GetExecution(string pathLp, string pathSoln)
    {
        var commands = new string[]
        {
            $"-c \"set limits time {Pars.TimeLimitSec}\"",
            $"-c \"set limits gap {Pars.Gap}\"",
            $"-c \"set limits absgap {Pars.AbsGap}\"",
            $"-c \"read {pathLp}\"",
            "-c \"optimize\"",
            $"-c \"write solution {pathSoln}\"",
            $"-c \"quit\"",
        };
        string args = string.Join(' ', commands);
        return new(Pars, args);
    }



    // method
    public override SolverType SolverType => SolverType.Scip;
    public override ParamsScip Params => Pars;


    public override SolnMpScip Solve(Model model, HashSet<IVar> varsToCache)
        => new(model, this, varsToCache);
    public SolnMpScip Solve(Model model, params IVar[] varsToCache)
        => Solve(model, varsToCache.ToHashSet());
}
