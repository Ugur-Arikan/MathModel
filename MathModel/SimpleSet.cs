namespace MathProg;

public class SimpleSet
{
    // data
    internal readonly Func<IEnumerable<int>> GenSimple;
    internal readonly Func<int[], IEnumerable<int>> Gen;


    // ctor
    public SimpleSet(Func<IEnumerable<int>> gen)
    {
        GenSimple = gen;
        Gen = _ => gen();
    }
}
