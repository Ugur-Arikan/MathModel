namespace MathProg;

public class ParamsCplex : IParams
{
    // data
    public string PathSolver { get; set; } = "cplex";
    public string PathTempDir { get; set; } = Path.GetTempPath();
    public bool Silent { get; set; } = true;
    public double TimeLimitSec { get; set; } = 1e+75;
    public double Gap { get; set; } = 0.0001;
    public double AbsGap { get; set; } = 1e-06;


    // ctor
    public Res Validate()
    {
        if (TimeLimitSec > 1e+75)
            TimeLimitSec = 1e+75;
        if (AbsGap > 1e+20)
            AbsGap = 1e+20;

        return
            OkIf(TimeLimitSec >= 0.0)
            .OkIf(Gap >= 0.0 && Gap <= 1.0)
            .OkIf(AbsGap >= 0.0);
    }


    // method
    public Res CheckAvailability()
        => ParamsHelpers.CreateDirIfAbsent(PathTempDir);
}
