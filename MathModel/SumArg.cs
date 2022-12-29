namespace MathProg;

public readonly ref struct SumArg
{
    // data
    internal readonly Sum Sum;
    internal SumArg(Sum sum)
        => Sum = sum;


    // common
    public override string ToString()
        => Sum.ToString();
}
