namespace MathProg.DefaultKeys;

internal static class DefaultVarKeys
{
    static int CurrKeyInd = 0;
    internal static string Get()
        => GetKey(CurrKeyInd++);
    internal static string Get(Dictionary<string, IVar> addedVars)
    {
        int until = addedVars.Any() ? addedVars.Count : 1;
        for (int i = 0; i < until; i++)
        {
            string key = GetKey(i);
            if (!addedVars.ContainsKey(key))
                return key;
        }
        throw Exc.MustNotReach;
    }
    static string GetKey(int i)
        => string.Format("x{0}", i);
}
