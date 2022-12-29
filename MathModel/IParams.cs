namespace MathProg;

public interface IParams
{
    // immut
    string PathSolver { get; }
    string PathTempDir { get; }
    double TimeLimitSec { get; set; }


    // mut
    bool Silent { get; set; }


    // method
    Res Validate();
}
