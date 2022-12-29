namespace MathProg;

public class SolnMpScip : SolnMp
{
    // ctor
    public SolnMpScip(Model model, SolverLp solver, HashSet<IVar> varsToCache)
        : base(model, solver, varsToCache)
    {
    }


    // method - var vals
    const string LineStatus = "solution status:";
    const string LineObjVal = "objective value:";
    const string LineBreak = "no solution available";
    protected override LineType GetLineType(ReadOnlySpan<char> line)
    {
        if (line.StartsWith(LineBreak))
            return LineType.Break;

        if (OptStatus.IsNone && line.StartsWith(LineStatus))
            return LineType.Status;

        if (OptObjVal.IsNone && line.StartsWith(LineObjVal))
            return LineType.ObjVal;

        return LineType.Var;
    }

    protected override (string, double) ParseNameAndValue(ReadOnlySpan<char> line)
    {
        int indNameEnd = line.IndexOf(' ');
        string key = line[0..indNameEnd].Trim().ToString();

        line = line[indNameEnd..].Trim();
        int indValEnd = line.IndexOf(' ');
        if (indValEnd < 0)
            indValEnd = line.Length;
        double val = double.Parse(line[0..indValEnd].Trim());

        return (key, val);
    }
    protected override Opt<double> ParseObjVal(ReadOnlySpan<char> line)
    {
        var strval = line[LineObjVal.Length..].Trim();
        return double.TryParse(strval, out double val) ? val : None<double>();
    }
    protected override Opt<string> ParseStatus(ReadOnlySpan<char> line)
        => line[LineStatus.Length..].Trim().ToString();
}
