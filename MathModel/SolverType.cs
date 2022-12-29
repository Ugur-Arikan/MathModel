namespace MathProg;

public enum SolverType
{
    Cplex,
    Scip,
}
internal static class SolverTypeExt
{
    internal static ArgumentException NotHandled(this SolverType solverType)
        => new(string.Format("Unhandled {0}: '{1}'.", nameof(SolverType), solverType));
}