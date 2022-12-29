namespace MathProg;

public record LpBuildErrors(List<ConstantIneqErr> ConstantIneq)
{
    public LpBuildErrors()
        : this(new List<ConstantIneqErr>())
    {
    }
    public bool Any()
        => ConstantIneq.Any();
    internal void AddConstantIneq(string key, ConstrRelation rel, double rhs)
        => ConstantIneq.Add(new(key, rel, rhs));
    public override string ToString()
    {
        if (!Any())
            return "None";

        string errConstIneq = !ConstantIneq.Any() ? string.Empty :
            string.Format("{0}:\n{1}\n",
            nameof(ConstantIneqErr), string.Join(Environment.NewLine, ConstantIneq.Select(e => "   * " + e.ToString())));

        return string.Format("{0}", errConstIneq);
    }
}

public record struct ConstantIneqErr(string ConstrKey, string Ineq)
{
    internal ConstantIneqErr(string key, ConstrRelation rel, double rhs)
        : this(key, string.Format("0 {0} {1}", T.RelationStr(rel), rhs))
    {
    }
    public override string ToString()
        => string.Format("{0}: {1}", ConstrKey, Ineq);
}
