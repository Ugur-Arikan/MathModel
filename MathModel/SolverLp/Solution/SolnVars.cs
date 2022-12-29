namespace MathProg;

public record struct SolnVar0(Var0 Var, double Val)
{
    public static implicit operator double(SolnVar0 varVal) => varVal.Val;
}
public record struct SolnVar1(Var1 Var, Dictionary<int, double> Vals)
{
    public double this[int i] => Vals[i];
    public bool ContainsKey(int i) => Vals.ContainsKey(i);
    public double[] IntoArr(Func<int, int> mapIndToVal)
    {
        var arr = Var.EmptySoln();
        for (int i = 0; i < arr.Length; i++)
        {
            int key = mapIndToVal(i);
            if (!Vals.TryGetValue(key, out arr[i]))
                arr[i] = Var.Bounds.Lower[i];
        }
        return arr;
    }
    public IEnumerable<KeyValuePair<int, double>> Filter(Func<double, bool> valueFilter)
        => Vals.Where(x => valueFilter(x.Value));
    public IEnumerable<KeyValuePair<int, double>> FilterPositives(double epsilon = 1e-15)
        => Filter(v => v > epsilon);
    public IEnumerable<int> FilterIndices(Func<double, bool> valueFilter)
        => Vals.Where(x => valueFilter(x.Value)).Select(x => x.Key);
}
public record struct SolnVar2(Var2 Var, Dictionary<(int, int), double> Vals)
{
    public double this[int i, int j] => Vals[(i, j)];
    public bool ContainsKey((int, int) indices) => Vals.ContainsKey(indices);
    public double[][] IntoArr(Func<int, int, (int, int)> mapIndToVal)
    {
        var arr = Var.EmptySoln();
        for (int i = 0; i < arr.Length; i++)
            for (int j = 0; j < arr[i].Length; j++)
            {
                var key = mapIndToVal(i, j);
                if (!Vals.TryGetValue(key, out arr[i][j]))
                    arr[i][j] = Var.Bounds.Lower[i, j];
            }
        return arr;
    }
    public IEnumerable<KeyValuePair<(int, int), double>> Filter(Func<double, bool> valueFilter)
        => Vals.Where(x => valueFilter(x.Value));
    public IEnumerable<KeyValuePair<(int, int), double>> FilterPositives(double epsilon = 1e-15)
        => Filter(v => v > epsilon);
    public IEnumerable<(int, int)> FilterIndices(Func<double, bool> valueFilter)
        => Vals.Where(x => valueFilter(x.Value)).Select(x => x.Key);
    
}
public record struct SolnVar3(Var3 Var, Dictionary<(int, int, int), double> Vals)
{
    public double this[int i, int j, int k] => Vals[(i, j, k)];
    public bool ContainsKey((int, int, int) indices) => Vals.ContainsKey(indices);
    public double[][][] IntoArr(Func<int, int, int, (int, int, int)> mapIndToVal)
    {
        var arr = Var.EmptySoln();
        for (int i = 0; i < arr.Length; i++)
            for (int j = 0; j < arr[i].Length; j++)
                for (int k = 0; k < arr[i][j].Length; k++)
                {
                    var key = mapIndToVal(i, j, k);
                    if (!Vals.TryGetValue(key, out arr[i][j][k]))
                        arr[i][j][k] = Var.Bounds.Lower[i, j, k];
                }
        return arr;
    }
    public IEnumerable<KeyValuePair<(int, int, int), double>> Filter(Func<double, bool> valueFilter)
        => Vals.Where(x => valueFilter(x.Value));
    public IEnumerable<KeyValuePair<(int, int, int), double>> FilterPositives(double epsilon = 1e-15)
        => Filter(v => v > epsilon);
    public IEnumerable<(int, int, int)> FilterIndices(Func<double, bool> valueFilter)
        => Vals.Where(x => valueFilter(x.Value)).Select(x => x.Key);
}
public record struct SolnVar4(Var4 Var, Dictionary<(int, int, int, int), double> Vals)
{
    public double this[int i, int j, int k, int l] => Vals[(i, j, k, l)];
    public bool ContainsKey((int, int, int, int) indices) => Vals.ContainsKey(indices);

    public IEnumerable<KeyValuePair<(int, int, int, int), double>> Filter(Func<double, bool> valueFilter)
        => Vals.Where(x => valueFilter(x.Value));
    public IEnumerable<KeyValuePair<(int, int, int, int), double>> FilterPositives(double epsilon = 1e-15)
        => Filter(v => v > epsilon);
    public IEnumerable<(int, int, int, int)> FilterIndices(Func<double, bool> valueFilter)
        => Vals.Where(x => valueFilter(x.Value)).Select(x => x.Key);
}
public record struct SolnVar5(Var5 Var, Dictionary<(int, int, int, int, int), double> Vals)
{
    public double this[int i, int j, int k, int l, int m] => Vals[(i, j, k, l, m)];
    public bool ContainsKey((int, int, int, int, int) indices) => Vals.ContainsKey(indices);

    public IEnumerable<KeyValuePair<(int, int, int, int , int), double>> Filter(Func<double, bool> valueFilter)
        => Vals.Where(x => valueFilter(x.Value));
    public IEnumerable<KeyValuePair<(int, int, int, int, int), double>> FilterPositives(double epsilon = 1e-15)
        => Filter(v => v > epsilon);
    public IEnumerable<(int, int, int, int , int)> FilterIndices(Func<double, bool> valueFilter)
        => Vals.Where(x => valueFilter(x.Value)).Select(x => x.Key);
}
public record struct SolnVar6(Var6 Var, Dictionary<(int, int, int, int, int, int), double> Vals)
{
    public double this[int i, int j, int k, int l, int m, int n] => Vals[(i, j, k, l, m, n)];
    public bool ContainsKey((int, int, int, int, int, int) indices) => Vals.ContainsKey(indices);

    public IEnumerable<KeyValuePair<(int, int, int, int, int , int), double>> Filter(Func<double, bool> valueFilter)
        => Vals.Where(x => valueFilter(x.Value));
    public IEnumerable<KeyValuePair<(int, int, int, int, int, int), double>> FilterPositives(double epsilon = 1e-15)
        => Filter(v => v > epsilon);
    public IEnumerable<(int, int, int, int, int , int)> FilterIndices(Func<double, bool> valueFilter)
        => Vals.Where(x => valueFilter(x.Value)).Select(x => x.Key);
}
public record struct SolnVar7(Var7 Var, Dictionary<(int, int, int, int, int, int, int), double> Vals)
{
    public double this[int i, int j, int k, int l, int m, int n, int o] => Vals[(i, j, k, l, m, n, o)];
    public bool ContainsKey((int, int, int, int, int, int, int) indices) => Vals.ContainsKey(indices);

    public IEnumerable<KeyValuePair<(int, int, int, int, int, int , int), double>> Filter(Func<double, bool> valueFilter)
        => Vals.Where(x => valueFilter(x.Value));
    public IEnumerable<KeyValuePair<(int, int, int, int, int, int, int), double>> FilterPositives(double epsilon = 1e-15)
        => Filter(v => v > epsilon);
    public IEnumerable<(int, int, int, int, int, int , int)> FilterIndices(Func<double, bool> valueFilter)
        => Vals.Where(x => valueFilter(x.Value)).Select(x => x.Key);
}
public record struct SolnVar8(Var8 Var, Dictionary<(int, int, int, int, int, int, int, int), double> Vals)
{
    public double this[int i, int j, int k, int l, int m, int n, int o, int p] => Vals[(i, j, k, l, m, n, o, p)];
    public bool ContainsKey((int, int, int, int, int, int, int, int) indices) => Vals.ContainsKey(indices);

    public IEnumerable<KeyValuePair<(int, int, int, int, int, int, int , int), double>> Filter(Func<double, bool> valueFilter)
        => Vals.Where(x => valueFilter(x.Value));
    public IEnumerable<KeyValuePair<(int, int, int, int, int, int, int, int), double>> FilterPositives(double epsilon = 1e-15)
        => Filter(v => v > epsilon);
    public IEnumerable<(int, int, int, int, int, int, int , int)> FilterIndices(Func<double, bool> valueFilter)
        => Vals.Where(x => valueFilter(x.Value)).Select(x => x.Key);
}
public record struct SolnVar9(Var9 Var, Dictionary<(int, int, int, int, int, int, int, int, int), double> Vals)
{
    public double this[int i, int j, int k, int l, int m, int n, int o, int p, int q] => Vals[(i, j, k, l, m, n, o, p, q)];
    public bool ContainsKey((int, int, int, int, int, int, int, int, int) indices) => Vals.ContainsKey(indices);

    public IEnumerable<KeyValuePair<(int, int, int, int, int, int, int, int , int), double>> Filter(Func<double, bool> valueFilter)
        => Vals.Where(x => valueFilter(x.Value));
    public IEnumerable<KeyValuePair<(int, int, int, int, int, int, int, int, int), double>> FilterPositives(double epsilon = 1e-15)
        => Filter(v => v > epsilon);
    public IEnumerable<(int, int, int, int, int, int, int, int , int)> FilterIndices(Func<double, bool> valueFilter)
        => Vals.Where(x => valueFilter(x.Value)).Select(x => x.Key);
}
public record struct SolnVar10(Var10 Var, Dictionary<(int, int, int, int, int, int, int, int, int, int), double> Vals)
{
    public double this[int i, int j, int k, int l, int m, int n, int o, int p, int q, int r] => Vals[(i, j, k, l, m, n, o, p, q, r)];
    public bool ContainsKey((int, int, int, int, int, int, int, int, int, int) indices) => Vals.ContainsKey(indices);

    public IEnumerable<KeyValuePair<(int, int, int, int, int, int, int, int, int , int), double>> Filter(Func<double, bool> valueFilter)
        => Vals.Where(x => valueFilter(x.Value));
    public IEnumerable<KeyValuePair<(int, int, int, int, int, int, int, int, int, int), double>> FilterPositives(double epsilon = 1e-15)
        => Filter(v => v > epsilon);
    public IEnumerable<(int, int, int, int, int, int, int, int, int , int)> FilterIndices(Func<double, bool> valueFilter)
        => Vals.Where(x => valueFilter(x.Value)).Select(x => x.Key);
}
