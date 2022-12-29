namespace MathProg.Lp;

internal static class Builder
{
    internal static LpBuildErrors WriteModel(StreamWriter writer, Model model)
    {
        LpBuildErrors result = new();

        ExprWriter.WriteObj(result, writer, model.Obj);
        
        if (model.Constrs.Any())
            writer.WriteLine("s.t.");
        
        foreach (var item in model.Constrs)
            ExprWriter.WriteConstr(result, writer, item.Key, item.Value);

        writer.WriteLine("bounds");
        BoundsWriter.WriteAll(writer, model);

        writer.WriteLine("generals");
        GeneralsWriter.WriteAll(writer, model);
                
        writer.WriteLine("end");

        return result;
    }
}
