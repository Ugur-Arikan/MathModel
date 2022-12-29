namespace MathProg;

public class DependentSet
{
    // data
    internal readonly OptList<Set> DepSets;
    readonly Func<int[], IEnumerable<int>> GenValsToSet;
    readonly int[] IndIndices, DepVals;
    internal Opt<Func<int[], IEnumerable<int>>> Gen = default;


    // ctor
    internal DependentSet(OptList<Set> depSets, Func<int[], IEnumerable<int>> genValsToSet)
    {
        DepSets = depSets;
        GenValsToSet = genValsToSet;
        IndIndices = new int[depSets.Length];
        DepVals = new int[depSets.Length];
        Gen = default;
    }


    // method
    internal void SetIndices(Indices allIndices)
    {
        if (DepSets.Length == 0)
        {
            Gen = Some<Func<int[], IEnumerable<int>>>(state => GenValsToSet(Array.Empty<int>()));
        }
        else
        {
            SetIndIndices(allIndices, DepSets, IndIndices);
            Gen = Some<Func<int[], IEnumerable<int>>>(
                state =>
                {
                    for (int i = 0; i < DepVals.Length; i++)
                        DepVals[i] = state[IndIndices[i]];
                    return GenValsToSet(DepVals);
                });
        }
    }
    internal static void SetIndIndices(Indices allIndices, OptList<Set> depSets, int[] indIndices)
    {
        for (int i = 0; i < indIndices.Length; i++)
            indIndices[i] = allIndices.GetIndexOf(depSets[i]).Unwrap("Must not reach here!");
    }
}
