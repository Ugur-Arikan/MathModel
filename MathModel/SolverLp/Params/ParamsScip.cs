namespace MathProg;

public class ParamsScip : IParams
{
    // data
    public string PathSolver { get; init; } = "scip";
    public string PathTempDir { get; set; } = Path.GetTempPath();
    public bool Silent { get; set; } = true;
    public double TimeLimitSec { get; set; } = 1e+20;
    public double Gap { get; set; } = 0;
    public double AbsGap { get; set; } = 0;


    // ctor
    public Res Validate()
    {
        if (TimeLimitSec > 1e+20)
            TimeLimitSec = 1e+20;

        return
            OkIf(TimeLimitSec >= 0.0)
            .OkIf(Gap >= 0.0)
            .OkIf(AbsGap >= 0.0);
    }


    // method
    public Res CheckAvailability()
        => ParamsHelpers.CreateDirIfAbsent(PathTempDir);
}
