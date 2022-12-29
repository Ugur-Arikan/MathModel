namespace MathProg;

public class Subset
{
    // data
    readonly Set Parent;
    internal readonly OptList<Set> DepSets;
    readonly Func<int, int[], bool> Filter;
    readonly int[] IndIndices, DepVals;
    internal Opt<Func<int[], IEnumerable<int>>> Gen = default;


    // ctor
    internal Subset(Set parent, OptList<Set> depSets, Func<int, int[], bool> filter)
    {
        Parent = parent;
        DepSets = depSets;
        Filter = filter;
        IndIndices = new int[depSets.Length];
        DepVals = new int[depSets.Length];
        Gen = default;
    }


    // method
    internal void SetIndices(Indices allIndices)
    {
        if (DepSets.Length == 0)
        {
            Gen = Some<Func<int[], IEnumerable<int>>>(
                state =>
                {
                    return Parent.GetGen()(state).Where(p => Filter(p, DepVals));
                });
        }
        else
        {
            DependentSet.SetIndIndices(allIndices, DepSets, IndIndices);
            Gen = Some<Func<int[], IEnumerable<int>>>(
                state =>
                {
                    var genPar = Parent.GetGen()(state);
                    return genPar.Where(p =>
                    {
                        for (int i = 0; i < DepVals.Length; i++)
                            DepVals[i] = state[IndIndices[i]];
                        return Filter(p, DepVals);
                });
            });
        }
    }
}
