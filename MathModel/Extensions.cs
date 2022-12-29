using MathProg.DefaultKeys;

namespace MathProg;

public static class Extensions
{
    // sum
    public static Sum Sum(SumArg sumArg)
        => sumArg.Sum;


    // depset - key
    public static Set St(this (Set i1, Set i2) depSets, string key, Func<int, int, IEnumerable<int>> depsetGenerator)
        => new(key, new DependentSet(new(depSets.i1, depSets.i2), arr => depsetGenerator(arr[0], arr[1])));
    public static Set St(this (Set i1, Set i2, Set i3) depSets, string key, Func<int, int, int, IEnumerable<int>> depsetGenerator)
        => new(key, new DependentSet(new(new List<Set>(3)
        {
            depSets.i1, depSets.i2, depSets.i3
        }), arr => depsetGenerator(arr[0], arr[1], arr[2])));
    public static Set St(this (Set i1, Set i2, Set i3, Set i4) depSets, string key, Func<int, int, int, int, IEnumerable<int>> depsetGenerator)
        => new(key, new DependentSet(new(new List<Set>(4)
        {
            depSets.i1, depSets.i2, depSets.i3, depSets.i4,
        }), arr => depsetGenerator(arr[0], arr[1], arr[2], arr[3])));
    public static Set St(this (Set i1, Set i2, Set i3, Set i4, Set i5) depSets, string key, Func<int, int, int, int, int, IEnumerable<int>> depsetGenerator)
        => new(key, new DependentSet(new(new List<Set>(4)
        {
        depSets.i1, depSets.i2, depSets.i3, depSets.i4, depSets.i5,
        }), arr => depsetGenerator(arr[0], arr[1], arr[2], arr[3], arr[4])));


    // depset
    public static Set St(this (Set i1, Set i2) depSets, Func<int, int, IEnumerable<int>> depsetGenerator)
        => St(depSets, DefaultSetKeys.Get(), depsetGenerator);
    public static Set St(this (Set i1, Set i2, Set i3) depSets, Func<int, int, int, IEnumerable<int>> depsetGenerator)
        => St(depSets, DefaultSetKeys.Get(), depsetGenerator);
    public static Set St(this (Set i1, Set i2, Set i3, Set i4) depSets, Func<int, int, int, int, IEnumerable<int>> depsetGenerator)
        => St(depSets, DefaultSetKeys.Get(), depsetGenerator);
    public static Set St(this (Set i1, Set i2, Set i3, Set i4, Set i5) depSets, Func<int, int, int, int, int, IEnumerable<int>> depsetGenerator)
        => St(depSets, DefaultSetKeys.Get(), depsetGenerator);


    // linq - dict
    public static IEnumerable<(int, double)> Flatten(this IEnumerable<KeyValuePair<int, double>> indexValuePairs)
        => indexValuePairs.Select(x => (x.Key, x.Value));
    public static IEnumerable<(int, int, double)> Flatten(this IEnumerable<KeyValuePair<(int, int), double>> indexValuePairs)
        => indexValuePairs.Select(x => (x.Key.Item1, x.Key.Item2, x.Value));
    public static IEnumerable<(int, int, int, double)> Flatten(this IEnumerable<KeyValuePair<(int, int, int), double>> indexValuePairs)
        => indexValuePairs.Select(x => (x.Key.Item1, x.Key.Item2, x.Key.Item3, x.Value));
    public static IEnumerable<(int, int, int, int, double)> Flatten(this IEnumerable<KeyValuePair<(int, int, int, int), double>> indexValuePairs)
        => indexValuePairs.Select(x => (x.Key.Item1, x.Key.Item2, x.Key.Item3, x.Key.Item4, x.Value));
    public static IEnumerable<(int, int, int, int, int, double)> Flatten(this IEnumerable<KeyValuePair<(int, int, int, int, int), double>> indexValuePairs)
        => indexValuePairs.Select(x => (x.Key.Item1, x.Key.Item2, x.Key.Item3, x.Key.Item4, x.Key.Item5, x.Value));
    public static IEnumerable<(int, int, int, int, int, int, double)> Flatten(this IEnumerable<KeyValuePair<(int, int, int, int, int, int), double>> indexValuePairs)
        => indexValuePairs.Select(x => (x.Key.Item1, x.Key.Item2, x.Key.Item3, x.Key.Item4, x.Key.Item5,
        x.Key.Item6, x.Value));
    public static IEnumerable<(int, int, int, int, int, int, int, double)> Flatten(this IEnumerable<KeyValuePair<(int, int, int, int, int, int, int), double>> indexValuePairs)
        => indexValuePairs.Select(x => (x.Key.Item1, x.Key.Item2, x.Key.Item3, x.Key.Item4, x.Key.Item5,
        x.Key.Item6, x.Key.Item7, x.Value));
    public static IEnumerable<(int, int, int, int, int, int, int, int, double)> Flatten(this IEnumerable<KeyValuePair<(int, int, int, int, int, int, int, int), double>> indexValuePairs)
        => indexValuePairs.Select(x => (x.Key.Item1, x.Key.Item2, x.Key.Item3, x.Key.Item4, x.Key.Item5,
        x.Key.Item6, x.Key.Item7, x.Key.Item8, x.Value));
    public static IEnumerable<(int, int, int, int, int, int, int, int, int, double)> Flatten(this IEnumerable<KeyValuePair<(int, int, int, int, int, int, int, int, int), double>> indexValuePairs)
        => indexValuePairs.Select(x => (x.Key.Item1, x.Key.Item2, x.Key.Item3, x.Key.Item4, x.Key.Item5,
        x.Key.Item6, x.Key.Item7, x.Key.Item8, x.Key.Item9, x.Value));
    public static IEnumerable<(int, int, int, int, int, int, int, int, int, int, double)> Flatten(this IEnumerable<KeyValuePair<(int, int, int, int, int, int, int, int, int, int), double>> indexValuePairs)
        => indexValuePairs.Select(x => (x.Key.Item1, x.Key.Item2, x.Key.Item3, x.Key.Item4, x.Key.Item5,
        x.Key.Item6, x.Key.Item7, x.Key.Item8, x.Key.Item9, x.Key.Item10, x.Value));
}
