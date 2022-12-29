namespace MathProg;

public record Constr(Ineq Ineq, OptList<Set> Sets)
{
    // implicit
    public static implicit operator Constr(Ineq ineq)
        => new(ineq, default);


    // set indices
    internal Indices SetIndices()
        => Ineq.SetIndices(Sets, ToString());


    // common
    public string ToString(string key)
        => string.Format("{0}({1})\t:\t{2}", key, string.Join(',', Sets), Ineq);
}
