namespace MathProg;

public struct Ind
{
    // data
    public readonly Set Set;
    internal int Index;


    // ctor
    Ind(Set set, int index)
    {
        Set = set;
        Index = index;
    }
    public Ind(Set set)
        : this(set, -1)
    {
    }
    public Ind WithIndex(int index)
        => new(Set, index);


    // implicit
    public static implicit operator Ind(Set set)
        => new(set);


    // common
    public override string ToString()
        => Set.Key;
}
