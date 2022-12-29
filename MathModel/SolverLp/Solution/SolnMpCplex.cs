namespace MathProg;

public class SolnMpCplex : SolnMp
{
    // ctor
    internal SolnMpCplex(Model model, SolverLp solver, HashSet<IVar> varsToCache)
        : base(model, solver, varsToCache)
    {
    }


    // method - var vals
    const string LineVar = "<variable ";
    const string LineBreak = "</variables>";
    const string LineStatus = "solutionStatusString=\"";
    const string LineObjVal = "objectiveValue=\"";
    const string ColName = "name=\"";
    const string ColVal = "value=\"";
    protected override LineType GetLineType(ReadOnlySpan<char> line)
    {
        if (line.StartsWith(LineVar))
            return LineType.Var;

        if (line.StartsWith(LineBreak))
            return LineType.Break;
        
        if (OptStatus.IsNone && line.StartsWith(LineStatus))
            return LineType.Status;
        
        if (OptObjVal.IsNone && line.StartsWith(LineObjVal))
            return LineType.ObjVal;
        
        return LineType.Skip;
    }
    protected override (string, double) ParseNameAndValue(ReadOnlySpan<char> line)
    {
        int indNameBeg = line.IndexOf(ColName) + ColName.Length;
        line = line[indNameBeg..];
        int indNameEnd = line.IndexOf("\"");
        string key = line[..indNameEnd].ToString();

        line = line[indNameEnd..];
        int indValBeg = line.IndexOf(ColVal) + ColVal.Length;
        line = line[indValBeg..];
        int indValEnd = line.IndexOf("\"");
        double val = double.Parse(line[0..indValEnd]);
        
        return (key, val);
    }
    protected override Opt<double> ParseObjVal(ReadOnlySpan<char> line)
    {
        var strval = line.Slice(LineObjVal.Length, line.Length - LineObjVal.Length - 1);
        return double.TryParse(strval, out double val) ? val : None<double>();
    }
    protected override Opt<string> ParseStatus(ReadOnlySpan<char> line)
        => line.Slice(LineStatus.Length, line.Length - LineStatus.Length - 1).ToString();
}
