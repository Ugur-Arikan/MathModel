namespace MathProg;

public record ObjFun(ObjDir Direction, Expr Expr)
{
    // singletons
    public static ObjFun Zero
        => new(ObjDir.Min, 0.0);


    // common
    public override string ToString()
        => string.Format("{0}\t \t{1}", Direction, Expr);
}
