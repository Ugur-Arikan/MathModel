namespace MathProg.Helpers;

internal static class Constants
{
    // infinity
    internal static void WriteNumAsBound(this StreamWriter writer, double val)
    {
        switch (val)
        {
            case double.NegativeInfinity: writer.Write("-inf"); break;
            case double.PositiveInfinity: writer.Write("inf"); break;
            default: writer.Write(val); break;
        }
    }
}
