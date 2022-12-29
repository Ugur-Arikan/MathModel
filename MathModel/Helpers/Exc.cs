using System.Reflection.Metadata.Ecma335;

namespace MathProg.Helpers;

internal static class Exc
{
    internal static NotImplementedException MustNotReach = new("Must not have reached here!");
    internal static NotImplementedException DimHigherThan10 = new("Not implemented to handle dimensions higher than 10.");
    internal static NotImplementedException MissingEnum<T>(T enumVal)
        => new(string.Format("Unhandled {0} variant: {1}", (typeof(T)).Name, enumVal));
    internal static NotImplementedException InvalidNotEq = new("Only <=, >= and == constraints are valid; not-equal constraint is not available.");
    internal static IndexOutOfRangeException IndOut = new();
    internal static ArgumentException NonIntegerIndex(ref Sca sca, double dval)
        => new(string.Format("Expected integer index; however scalar computed as {0} in expression '{1}'.", dval, sca.ToString()));
    internal static NotImplementedException Todo => new("Todo!");
}
