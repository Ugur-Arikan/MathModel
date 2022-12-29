namespace MathProg;

public interface ISolver
{
    IParams Params { get; }

    SolnMp Solve(Model model, HashSet<IVar> varsToCache);
    SolnMp Solve(Model model, params IVar[] varsToCache)
        => Solve(model, varsToCache.ToHashSet());
}
