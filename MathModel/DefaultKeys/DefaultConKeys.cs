namespace MathProg.DefaultKeys;

internal static class DefaultConKeys
{
    internal static string Get(Dictionary<string, Constr> constrs)
    {
        int until = constrs.Any() ? 2 * constrs.Count : 1;
        for (int i = 0; i < until; i++)
        {
            string key = GetKey(i);
            if (!constrs.ContainsKey(key))
                return key;
        }
        throw Exc.MustNotReach;
    }
    static string GetKey(int i)
        => string.Format("C_{0}", i);
}
