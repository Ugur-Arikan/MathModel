namespace MathProg.DefaultKeys;

internal static class DefaultParKeys
{
    static int CurrKeyInd = 0;
    internal static string Get()
        => GetKey(CurrKeyInd++);
    static string GetKey(int i)
        => string.Format("P{0}", i);
}
