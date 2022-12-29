namespace MathProg.DefaultKeys;

internal static class DefaultSetKeys
{
    static int CurrKeyInd = 0;
    internal static string Get()
        => GetKey(CurrKeyInd++);
    static string GetKey(int i)
        => string.Format("i{0}", i);
}
