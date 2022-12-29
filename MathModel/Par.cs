namespace MathProg;

public record Par(IPar Parameter, OptList<Sca> Indices)
{
    // implicit
    public static implicit operator Par(Par0 par0)
        => new(par0, default);


    // method
    internal Par SetIndices(Indices indices, string exprStr)
    {
        var newIndices = Indices;
        for (int i = 0; i < newIndices.Length; i++)
            newIndices[i] = newIndices[i].SetIndices(indices, exprStr);
        return new(Parameter, newIndices);
    }
    internal double GetCurrValue(int[] st)
    {
        return Parameter.Dim switch
        {
            1 => ((Par1)Parameter).Data[Ind(st, 0)],
            2 => ((Par2)Parameter).Data[Ind(st, 0), Ind(st, 1)],
            3 => ((Par3)Parameter).Data[Ind(st, 0), Ind(st, 1), Ind(st, 2)],
            4 => ((Par4)Parameter).Data[Ind(st, 0), Ind(st, 1), Ind(st, 2), Ind(st, 3)],
            5 => ((Par5)Parameter).Data[Ind(st, 0), Ind(st, 1), Ind(st, 2), Ind(st, 3), Ind(st, 4)],
            6 => ((Par6)Parameter).Data[Ind(st, 0), Ind(st, 1), Ind(st, 2), Ind(st, 3), Ind(st, 4), Ind(st, 5)],
            7 => ((Par7)Parameter).Data[Ind(st, 0), Ind(st, 1), Ind(st, 2), Ind(st, 3), Ind(st, 4), Ind(st, 5), Ind(st, 6)],
            8 => ((Par8)Parameter).Data[Ind(st, 0), Ind(st, 1), Ind(st, 2), Ind(st, 3), Ind(st, 4), Ind(st, 5), Ind(st, 6), Ind(st, 7)],
            9 => ((Par9)Parameter).Data[Ind(st, 0), Ind(st, 1), Ind(st, 2), Ind(st, 3), Ind(st, 4), Ind(st, 5), Ind(st, 6), Ind(st, 7), Ind(st, 8)],
            10 => ((Par10)Parameter).Data[Ind(st, 0), Ind(st, 1), Ind(st, 2), Ind(st, 3), Ind(st, 4), Ind(st, 5), Ind(st, 6), Ind(st, 7), Ind(st, 8), Ind(st, 9)],
            _ => throw Exc.DimHigherThan10,
        };
    }
    int Ind(int[] state, int ind)
        => Indices[ind].GetCurrValueAsInt(state);



    // op - sum
    public static SumArg operator |(Set i, Par s)
        => new(new Sum(s, new(i)));
    public static SumArg operator |((Set i, Set j) sets, Par s)
        => new(new Sum(s, new(sets.i, sets.j)));
    public static SumArg operator |((Set i, Set j, Set k) sets, Par s)
        => new(new Sum(s, new(new List<Set>() { sets.i, sets.j, sets.k })));


    // op - obj
    public static ObjFun operator |(ObjDir direction, Par s)
        => new(direction, s);


    // common
    public override string ToString()
        => string.Format(T.Of(Parameter.Key, Indices));
}
