namespace MathProg.Lp;

internal class ExprWriter
{
    // data
    readonly LpBuildErrors Result;
    readonly StreamWriter Writer;
    readonly string Key;
    readonly Constr Constr;
    internal readonly Indices AllIndices;
    internal readonly int[] State;
    bool Started;


    // ctor
    internal static void WriteObj(LpBuildErrors result, StreamWriter writer, ObjFun obj)
    {
        writer.WriteLine(obj.Direction);
        writer.Write("obj: ");

        ExprWriter cw = new(result, writer, "obj", new Constr(new Ineq(ConstrRelation.Leq, obj.Expr, (Expr)0.0, obj.Expr), default));
        _ = cw.HandleExpr0(obj.Expr);
        if (!cw.Started)
            cw.Writer.Write('0');
        cw.Writer.Write(Environment.NewLine);
    }
    internal static void WriteConstr(LpBuildErrors result, StreamWriter writer, string key, Constr constr)
    {
        ExprWriter cw = new(result, writer, key, constr);
        cw.WriteConstraints();
    }
    ExprWriter(LpBuildErrors result, StreamWriter writer, string key, Constr constr)
    {
        Result = result;
        Writer = writer;
        Key = key;
        Constr = constr;
        AllIndices = constr.SetIndices();
        State = new int[AllIndices.Length];
        Started = false;
    }


    // helper
    internal IEnumerable<int> GetGen(int i)
        => AllIndices[i].Set.GetGen()(State);
    internal void SetState(int ind, int i)
        => State[ind] = i;
    internal Expr LhsMinRhs
        => Constr.Ineq.LhsMinRhs;


    // terms
    const double BIG_VAL = 1e16;
    void AddTerms(OptList<Term> terms)
    {
        for (int i = 0; i < terms.Length; i++)
            AddTerm(terms[i]);
    }
    void AddTerm(Term term)
    {
        double val = term.Sca.GetCurrValue(State);
        if (val >= BIG_VAL)
            val = BIG_VAL;
        else if (val <= -BIG_VAL)
            val = -BIG_VAL;

        // general
        if (Math.Abs(val) > 1e-15)  // nonzero
        {
            if (Math.Abs(val - 1.0) < 1e-15) // ~ 1
            {
                if (Started)
                    Writer.Write(" + ");
                else
                    Started = true;
                term.Var.WriteStringFor(Writer, State);
            }
            else if (Math.Abs(val + 1.0) < 1e-15) // ~ -1
            {
                if (Started)
                    Writer.Write(" - ");
                else
                {
                    Writer.Write('-');
                    Started = true;
                }
                term.Var.WriteStringFor(Writer, State);
            }
            else
            {
                if (Started)
                    AddScaRest(val); 
                else
                {
                    AddScaFirst(val);
                    Started = true;
                }
                Writer.Write(' ');
                term.Var.WriteStringFor(Writer, State);
            }
        }
    }


    // sca
    void AddScaFirst(double val)
    {
        Writer.Write(val);
    }
    void AddScaRest(double val)
    {
        bool nonneg = val >= 0.0;
        Writer.Write(' ');
        Writer.Write(nonneg ? '+' : '-');
        Writer.Write(' ');
        if (nonneg)
            Writer.Write(val);
        else
            Writer.Write(-val);
    }
    double GetSca(Opt<Sca> sca)
        => sca.IsNone ? 0.0 : sca.Unwrap().GetCurrValue(State);


    // dim*
    void WriteConstraints()
    {
        var _ = Constr.Sets.Length switch
        {
            0 => HandleConstr0(),
            1 => HandlerDim1.Constr(this),
            2 => HandlerDim2.Constr(this),
            3 => HandlerDim3.Constr(this),
            4 => HandlerDim4.Constr(this),
            5 => HandlerDim5.Constr(this),
            6 => HandlerDim6.Constr(this),
            7 => HandlerDim7.Constr(this),
            8 => HandlerDim8.Constr(this),
            9 => HandlerDim9.Constr(this),
            10 => HandlerDim10.Constr(this),
            _ => throw Exc.DimHigherThan10,
        };
    }
    double HandleExpr(Expr expr, OptList<Set> sets, Opt<int[]> indIndices)
    {
        var ind = indIndices.UnwrapOr(Array.Empty<int>());
        double val = sets.Length switch
        {
            0 => HandleExpr0(expr),
            1 => HandlerDim1.Expr(this, expr, ind[0]),
            2 => HandlerDim2.Expr(this, expr, ind[0], ind[1]),
            3 => HandlerDim3.Expr(this, expr, ind[0], ind[1], ind[2]),
            4 => HandlerDim4.Expr(this, expr, ind[0], ind[1], ind[2], ind[3]),
            5 => HandlerDim5.Expr(this, expr, ind[0], ind[1], ind[2], ind[3], ind[4]),
            6 => HandlerDim6.Expr(this, expr, ind[0], ind[1], ind[2], ind[3], ind[4], ind[5]),
            7 => HandlerDim7.Expr(this, expr, ind[0], ind[1], ind[2], ind[3], ind[4], ind[5], ind[6]),
            8 => HandlerDim8.Expr(this, expr, ind[0], ind[1], ind[2], ind[3], ind[4], ind[5], ind[6], ind[7]),
            9 => HandlerDim9.Expr(this, expr, ind[0], ind[1], ind[2], ind[3], ind[4], ind[5], ind[6], ind[7], ind[8]),
            10 => HandlerDim10.Expr(this, expr, ind[0], ind[1], ind[2], ind[3], ind[4], ind[5], ind[6], ind[7], ind[8], ind[9]),
            _ => throw Exc.DimHigherThan10,
        };
        return val;
    }
    static void BegConstr(ExprWriter w)
    {
        w.Started = false;
        var st = w.State;
        switch (w.Constr.Sets.Length)
        {
            case 0: w.Writer.Write(w.Key); break;
            case 1: w.Writer.WriteOf(w.Key, st[0]); break;
            case 2: w.Writer.WriteOf(w.Key, st[0], st[1]); break;
            case 3: w.Writer.WriteOf(w.Key, st[0], st[1], st[2]); break;
            case 4: w.Writer.WriteOf(w.Key, st[0], st[1], st[2], st[3]); break;
            case 5: w.Writer.WriteOf(w.Key, st[0], st[1], st[2], st[3], st[4]); break;
            case 6: w.Writer.WriteOf(w.Key, st[0], st[1], st[2], st[3], st[4], st[5]); break;
            case 7: w.Writer.WriteOf(w.Key, st[0], st[1], st[2], st[3], st[4], st[5], st[6]); break;
            case 8: w.Writer.WriteOf(w.Key, st[0], st[1], st[2], st[3], st[4], st[5], st[6], st[7]); break;
            case 9: w.Writer.WriteOf(w.Key, st[0], st[1], st[2], st[3], st[4], st[5], st[6], st[7], st[8]); break;
            case 10: w.Writer.WriteOf(w.Key, st[0], st[1], st[2], st[3], st[4], st[5], st[6], st[7], st[8], st[9]); break;
            default: throw Exc.DimHigherThan10;
        }
        w.Writer.Write(':');
        w.Writer.Write(' ');
    }


    // expr
    internal double HandleExpr0(Expr expr)
    {
        double val = GetSca(expr.Constant);
        AddTerms(expr.Terms);
        val += HandleSums(expr.Sums);
        return val;
    }


    // sum
    double HandleSums(OptList<Sum> sums)
        => sums.Aggregate(0.0, (val, sum) => val + HandleSum(sum));
    double HandleSum(Sum sum)
        => HandleExpr(sum.Expr, sum.Sets, sum.IndIndices);


    // constr
    double HandleConstr0()
        => ConstrHandler(this, Constr.Ineq.LhsMinRhs);
    static double ConstrHandler(ExprWriter w, Expr e)
    {
        BegConstr(w);
        double rhs = -w.HandleExpr0(e);
        if (!w.Started)
        {
            bool isFeas = w.Constr.Ineq.Relation switch
            {
                ConstrRelation.Leq => rhs >= -1e-15,
                ConstrRelation.Geq => rhs <= 1e-15,
                ConstrRelation.Eq => Math.Abs(rhs) < 1e-15,
                _ => true,
            };
            if (!isFeas)    // add to results; lp will also fail
            {
                var st = w.State;
                string conKey = w.Constr.Sets.Length switch
                {
                    0 => w.Key,
                    1 => T.Of(w.Key, st[0]),
                    2 => T.Of(w.Key, st[0], st[1]),
                    3 => T.Of(w.Key, st[0], st[1], st[2]),
                    4 => T.Of(w.Key, st[0], st[1], st[2], st[3]),
                    5 => T.Of(w.Key, st[0], st[1], st[2], st[3], st[4]),
                    6 => T.Of(w.Key, st[0], st[1], st[2], st[3], st[4], st[5]),
                    7 => T.Of(w.Key, st[0], st[1], st[2], st[3], st[4], st[5], st[6]),
                    8 => T.Of(w.Key, st[0], st[1], st[2], st[3], st[4], st[5], st[6], st[7]),
                    9 => T.Of(w.Key, st[0], st[1], st[2], st[3], st[4], st[5], st[6], st[7], st[8]),
                    10 => T.Of(w.Key, st[0], st[1], st[2], st[3], st[4], st[5], st[6], st[7], st[8], st[9]),
                    _ => throw Exc.DimHigherThan10,
                };
                w.Result.AddConstantIneq(conKey, w.Constr.Ineq.Relation, rhs);
            }
        }
        EndConstr(w.Writer, w.Constr.Ineq.Relation, rhs);
        return 0.0;
    }
    internal Func<int[], double> GetConstrHandler()
    {
        return st =>
        {
            ConstrHandler(this, Constr.Ineq.LhsMinRhs);
            return 0.0;
        };
    }
    static void EndConstr(StreamWriter writer, ConstrRelation relation, double rhs)
    {
        writer.Write(' ');
        writer.Write(relation.RelationStr());
        writer.Write(' ');

        writer.Write(rhs);

        writer.Write(Environment.NewLine);
    }
}
