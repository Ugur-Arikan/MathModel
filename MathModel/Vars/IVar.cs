namespace MathProg;

public interface IVar
{
    string Key { get; }
    int Dim { get; }
    VarType VarType { get; }
    bool IsDiscrete => VarType != VarType.Continuous;
    internal bool IsConstantlyNonneg { get; }
    internal bool HasContantBounds { get; }
}
