using MathProg.DefaultKeys;

namespace MathProg;

public class Set
{
    // data
    internal readonly string Key;
    readonly Opt<SimpleSet> AsSimple;
    readonly Opt<Subset> AsSubset;
    readonly Opt<DependentSet> AsDependent;
    
    
    // ctor
    Set(Opt<string> key, Opt<SimpleSet> simple, Opt<Subset> subset, Opt<DependentSet> asDependent)
    {
        Key = key.UnwrapOr(() => DefaultSetKeys.Get());
        AsSimple = simple;
        AsSubset = subset;
        AsDependent = asDependent;
    }
    Set(Opt<string> key, SimpleSet simple)
        : this(key, simple, default, default) { }
    Set(Opt<string> key, Subset subset)
        : this(key, default, subset, default) { }
    internal Set(Opt<string> key, DependentSet dependentSet)
        : this(key, default, default, dependentSet) { }
    // implicit
    public static implicit operator Set(SimpleSet simple)
        => new(default, simple);
    public static implicit operator Set(Subset subset)
        => new(default, subset);
    public static implicit operator Set(DependentSet dependentSet)
        => new(default, dependentSet);


    // simple - key
    public Set(string key, Func<IEnumerable<int>> getValues)
        : this(key, new SimpleSet(getValues), default, default)
    {
    }
    public Set(string key, IEnumerable<int> values)
        : this(key, () => values)
    {
    }
    public Set(string key, int start, int endExclusive)
        : this(key, new SimpleSet(() => Enumerable.Range(start, endExclusive)), default, default)
    {
    }
    public Set(string key, Range range)
        : this(key, range.Start.Value, range.End.Value)
    {
    }
    public Set(string key, int length)
        : this(key, new SimpleSet(() => Enumerable.Range(0, length)), default, default)
    {
    }
    // simple - default
    public Set(Func<IEnumerable<int>> getValues)
        : this(DefaultSetKeys.Get(), getValues)
    {
    }
    public Set(IEnumerable<int> values)
        : this(DefaultSetKeys.Get(), values)
    {
    }
    public Set(int start, int endExclusive)
        : this(DefaultSetKeys.Get(), start, endExclusive)
    {
    }
    public Set(Range range)
        : this(DefaultSetKeys.Get(), range)
    {
    }
    public Set(int length)
        : this(DefaultSetKeys.Get(), length)
    {
    }
    // simple - implicit
    public static implicit operator Set(Func<IEnumerable<int>> getValues)
        => new(getValues);
    public static implicit operator Set(int[] values)
        => new(values);
    public static implicit operator Set(List<int> values)
        => new(values);
    public static implicit operator Set((int Start, int EndExclusive) range)
        => new(range.Start, range.EndExclusive);
    public static implicit operator Set(Range range)
        => new(range);


    // method
    internal Func<int[], IEnumerable<int>> GetGen()
    {
        if (AsSimple.IsSome)
            return AsSimple.Unwrap().Gen;
        if (AsSubset.IsSome)
            return AsSubset.Unwrap().Gen.Unwrap();
        if (AsDependent.IsSome)
            return AsDependent.Unwrap().Gen.Unwrap();
        throw Exc.MustNotReach;
    }
    internal void SetIndices(Indices allIndices)
    {
        if (AsSubset.IsSome)
            AsSubset.Unwrap().SetIndices(allIndices);
        if (AsDependent.IsSome)
            AsDependent.Unwrap().SetIndices(allIndices);
    }
    internal Opt<SimpleSet> GetSimple()
        => AsSimple;
    internal bool IsSimple
        => AsSimple.IsSome;
    internal OptList<Set> DepSets
        => AsSubset.IsNone ? default : AsSubset.Unwrap().DepSets;


    // subset - keys
    public Set Subset(string key, Func<int, bool> filter)
        => new(key, new Subset(this, default, (p, _arr) => filter(p)));
    public Set Subset(string key, Set i1, Func<int, int, bool> filter)
        => new(key, new Subset(this, i1, (p, arr) => filter(p, arr[0])));
    public Set Subset(string key, Set i1, Set i2, Func<int, int, int, bool> filter)
        => new(key, new Subset(this, new(i1, i2), (p, arr) => filter(p, arr[0], arr[1])));
    // subset
    public Set Subset(Func<int, bool> filter)
        => new(default, new Subset(this, default, (p, _arr) => filter(p)));
    public Set Subset(Set i1, Func<int, int, bool> filter)
        => new(default, new Subset(this, i1, (p, arr) => filter(p, arr[0])));
    public Set Subset(Set i1, Set i2, Func<int, int, int, bool> filter)
        => new(default, new Subset(this, new(i1, i2), (p, arr) => filter(p, arr[0], arr[1])));


    // depset - keys
    public Set St(string key, Func<int, IEnumerable<int>> depsetGenerator)
        => new(key, new DependentSet(this, arr => depsetGenerator(arr[0])));
    // depset
    public Set St(Func<int, IEnumerable<int>> depsetGenerator)
        => new(default, new DependentSet(this, arr => depsetGenerator(arr[0])));


    // common
    public override string ToString()
        => Key;
}
