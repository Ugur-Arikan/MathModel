namespace MathProg.Helpers;

internal class Indices
{
    // data
    readonly List<(Set Set, int Index)> List;


    // ctor
    public Indices(List<(Set Set, int Index)> list)
    {
        List = list;
    }
    public Indices(OptList<Set> sets = default)
    {
        List = new(sets.Length);
        for (int i = 0; i < sets.Length; i++)
            Add(sets[i]);
    }


    // method
    public Indices Clone()
        => new(new List<(Set, int)>(List));
    public int Add(Set set)
    {
        set.SetIndices(this);
        int ind = List.Count;
        List.Add((set, ind));
        return ind;
    }
    public void Add(OptList<Set> sets)
    {
        for (int i = 0; i < sets.Length; i++)
            Add(sets[i]);
    }
    public (Indices NewRunning, int[] IndIndices) AddGetNewRunning(Indices running, OptList<Set> sets)
    {
        var newRunning = running.Clone();
        var indIndices = new int[sets.Length];
        for (int i = 0; i < sets.Length; i++)
        {
            int ind = Add(sets[i]);
            newRunning.List.Add((sets[i], ind));
            indIndices[i] = ind;
        }
        return (newRunning, indIndices);
    }
    public Indices NewWith(OptList<Set> sets)
    {
        var clone = Clone();
        clone.Add(sets);
        return clone;
    }
    public Opt<int> GetIndexOf(Set set)
    {
        for (int i = List.Count - 1; i > -1; i--)
            if (List[i].Set == set)
                return List[i].Index;
        return None<int>();
    }
    public Opt<int> SetIndicesGetErrInd(ref OptList<Ind> indices)
    {
        for (int i = 0; i < indices.Length; i++)
        {
            var index = GetIndexOf(indices[i].Set);
            if (index.IsNone)
                return i;
            indices[i] = indices[i].WithIndex(index.Unwrap());
        }
        return None<int>();
    }
    public static ArgumentException GetIndexNotFound(string indexKey, string exprStr)
        => new(string.Format("Undefined index '{0}' in expression '{1}'.", indexKey, exprStr));


    // get
    public int Length
        => List.Count;
    public (Set Set, int Index) this[int i]
        => List[i];


    // common
    public override string ToString()
        => string.Join("; ", List);
}
