namespace MathProg;

public record struct ScaTerm(double Coef, OptList<Ind> Num, OptList<Ind> Denom, OptList<Par> PNum, OptList<Par> PDenom)
{
    // ctor
    public ScaTerm(double num)
        : this(num, default, default, default, default)
    {
    }
    public ScaTerm(OptList<Ind> num, OptList<Ind> denom, OptList<Par> pnum, OptList<Par> pdenom)
        : this(1.0, num, denom, pnum, pdenom)
    {
    }


    // method
    internal ScaTerm SetIndices(Indices indices, string exprStr)
    {
        var num = Num;
        var errInd = indices.SetIndicesGetErrInd(ref num);
        if (errInd.IsSome)
            throw Indices.GetIndexNotFound(Num[errInd.Unwrap()].Set.Key, exprStr);

        var denom = Denom;
        errInd = indices.SetIndicesGetErrInd(ref denom);
        if (errInd.IsSome)
            throw Indices.GetIndexNotFound(Denom[errInd.Unwrap()].Set.Key, exprStr);

        var pnum = PNum;
        for (int i = 0; i < pnum.Length; i++)
            pnum[i] = pnum[i].SetIndices(indices, exprStr);

        var pdenom = PDenom;
        for (int i = 0; i < pdenom.Length; i++)
            pdenom[i] = pdenom[i].SetIndices(indices, exprStr);

        return new(Coef, num, denom, pnum, pdenom);
    }
    internal double GetCurrValue(int[] state)
    {
        double val = Coef;
        for (int i = 0; i < Num.Length; i++)
            val *= state[Num[i].Index];
        for (int i = 0; i < PNum.Length; i++)
            val *= PNum[i].GetCurrValue(state);
        for (int i = 0; i < Denom.Length; i++)
            val /= state[Denom[i].Index];
        for (int i = 0; i < PDenom.Length; i++)
            val /= PDenom[i].GetCurrValue(state);
        return val;
    }
    internal bool IsConst()
        => Num.Length == 0 && Denom.Length == 0 && PNum.Length == 0 && PDenom.Length == 0;
    internal bool IsNum(int num)
        => IsConst() && Math.Abs(Coef - num) < 1e-15;



    // ops
    public static implicit operator ScaTerm(Set i)
        => new(1.0, (Ind)i, default, default, default);
    public static implicit operator ScaTerm(Ind i)
        => new(1.0, i, default, default, default);
    public static implicit operator ScaTerm(Par p)
        => new(1.0, default, default, p, default);
    public static ScaTerm operator -(ScaTerm t)
        => new(-t.Coef, t.Num, t.Denom, t.PNum, t.PDenom);
    public ScaTerm Reciprocal()
        => new(1.0 / Coef, Denom, Num, PDenom, PNum);


    // ops - double
    public static ScaTerm operator *(ScaTerm t, double n)
        => new(t.Coef * n, t.Num, t.Denom, t.PNum, t.PDenom);
    public static ScaTerm operator *(double n, ScaTerm t)
        => t * n;
    public static ScaTerm operator /(ScaTerm t, double n)
        => new(t.Coef / n, t.Num, t.Denom, t.PNum, t.PDenom);
    public static ScaTerm operator /(double n, ScaTerm t)
        => new(n / t.Coef, t.Denom, t.Num, t.PDenom, t.PNum);
    public static Sca operator +(ScaTerm t, double n)
        => new(new(t, new ScaTerm(n)));
    public static Sca operator +(double n, ScaTerm t)
        => t + n;
    public static Sca operator -(ScaTerm t, double n)
        => new(new(t, new ScaTerm(-n)));
    public static Sca operator -(double n, ScaTerm t)
        => (-t) + n;
    // ops - int
    public static ScaTerm operator *(ScaTerm t, int n)
        => new(t.Coef * n, t.Num, t.Denom, t.PNum, t.PDenom);
    public static ScaTerm operator *(int n, ScaTerm t)
        => t * n;
    public static ScaTerm operator /(ScaTerm t, int n)
        => new(t.Coef / n, t.Num, t.Denom, t.PNum, t.PDenom);
    public static ScaTerm operator /(int n, ScaTerm t)
        => new(n / t.Coef, t.Denom, t.Num, t.PDenom, t.PNum);
    public static Sca operator +(ScaTerm t, int n)
        => new(new(t, new ScaTerm(n)));
    public static Sca operator +(int n, ScaTerm t)
        => t + n;
    public static Sca operator -(ScaTerm t, int n)
        => new(new(t, new ScaTerm(-n)));
    public static Sca operator -(int n, ScaTerm t)
        => (-t) + n;
    // ops - Ind
    public static ScaTerm operator *(ScaTerm t, Ind n)
        => new(t.Coef, t.Num + n, t.Denom, t.PNum, t.PDenom);
    public static ScaTerm operator *(Ind n, ScaTerm t)
        => t * n;
    public static ScaTerm operator /(ScaTerm t, Ind n)
        => new(t.Coef, t.Num, t.Denom + n, t.PNum, t.PDenom);
    public static ScaTerm operator /(Ind n, ScaTerm t)
        => new(1.0 / t.Coef, n + t.Denom, t.Num, t.PDenom, t.PNum);
    public static Sca operator +(ScaTerm t, Ind n)
        => new(new OptList<ScaTerm>(t, new ScaTerm(new OptList<Ind>(n), default, default, default)));
    public static Sca operator +(Ind n, ScaTerm t)
        => t + n;
    public static Sca operator -(ScaTerm t, Ind n)
        => new(new OptList<ScaTerm>(t, new ScaTerm(-1.0, new OptList<Ind>(n), default, default, default)));
    public static Sca operator -(Ind n, ScaTerm t)
        => new(new OptList<ScaTerm>(-t, new ScaTerm(new OptList<Ind>(n), default, default, default)));
    // ops - Par
    public static ScaTerm operator *(ScaTerm t, Par n)
        => new(t.Coef, t.Num, t.Denom, t.PNum + n, t.PDenom);
    public static ScaTerm operator *(Par n, ScaTerm t)
        => t * n;
    public static ScaTerm operator /(ScaTerm t, Par n)
        => new(t.Coef, t.Num, t.Denom, t.PNum, t.PDenom + n);
    public static ScaTerm operator /(Par n, ScaTerm t)
        => new(1.0 / t.Coef, t.Denom, t.Num, n + t.PDenom, t.PNum);
    public static Sca operator +(ScaTerm t, Par n)
        => new(new OptList<ScaTerm>(t, new ScaTerm(default, default, new OptList<Par>(n), default)));
    public static Sca operator +(Par n, ScaTerm t)
        => t + n;
    public static Sca operator -(ScaTerm t, Par n)
        => new(new OptList<ScaTerm>(t, new ScaTerm(-1.0, default, default, new OptList<Par>(n), default)));
    public static Sca operator -(Par n, ScaTerm t)
        => new(new OptList<ScaTerm>(-t, new ScaTerm(default, default, new OptList<Par>(n), default)));


    // ops - ScaTerm
    public static ScaTerm operator *(ScaTerm t, ScaTerm s)
        => new(t.Coef * s.Coef, t.Num + s.Num, t.Denom + s.Denom, t.PNum + s.PNum, t.PDenom + s.PDenom);
    public static ScaTerm operator /(ScaTerm t, ScaTerm s)
        => new(t.Coef / s.Coef, t.Num + s.Denom, t.Denom + s.Num, t.PNum + s.PDenom, t.PDenom + s.PNum);
    public static Sca operator +(ScaTerm t, ScaTerm s)
        => new(new OptList<ScaTerm>(t, s));
    public static Sca operator -(ScaTerm t, ScaTerm s)
        => new(new OptList<ScaTerm>(t, -s));


    // common
    public override string ToString()
    {
        var num = new List<string>(Num.Length + PNum.Length);
        var denom = new List<string>(Denom.Length + PDenom.Length);
        for (int i = 0; i < Num.Length; i++)
            num.Add(Num[i].ToString());
        for (int i = 0; i < PNum.Length; i++)
            num.Add(PNum[i].ToString());
        for (int i = 0; i < Denom.Length; i++)
            denom.Add(Denom[i].ToString());
        for (int i = 0; i < PDenom.Length; i++)
            denom.Add(PDenom[i].ToString());

        if (num.Count > 0)
        {
            if (denom.Count > 0)
            {
                if (Math.Abs(Coef - 1.0) > 1e-10)
                    return string.Format("{0} {1} / {2}", Coef, string.Join(' ', num), string.Join(' ', denom));
                else
                    return string.Format("{0} / {1}", string.Join(' ', num), string.Join(' ', denom));
            }
            else
            {
                if (Math.Abs(Coef - 1.0) > 1e-10)
                    return string.Format("{0} {1}", Coef, string.Join(' ', num));
                else
                    return string.Format("{0}", string.Join(' ', num));
            }
        }
        else
        {
            if (denom.Count > 0)
            {
                return string.Format("{0} / {1}", Coef, string.Join(' ', denom));
            }
            else
            {
                return Coef.ToString();
            }
        }
    }
}

public record struct Sca(OptList<ScaTerm> Terms)
{
    // ctor - static
    public static Sca One()
        => new(new ScaTerm(1.0));
    public static Sca MinOne()
        => new(new ScaTerm(-1.0));


    // method
    internal Sca SetIndices(Indices indices, string exprStr)
    {
        var terms = Terms;
        for (int i = 0; i < terms.Length; i++)
            terms[i] = terms[i].SetIndices(indices, exprStr);
        return new(terms);
    }
    internal double GetCurrValue(int[] state)
    {
        double val = 0.0;
        for (int i = 0; i < Terms.Length; i++)
            val += Terms[i].GetCurrValue(state);
        return val;
    }
    internal int GetCurrValueAsInt(int[] state)
    {
        double dval = GetCurrValue(state);
        var ival = (int)dval;
        if (Math.Abs(dval - ival) > 1e-5)
            throw Exc.NonIntegerIndex(ref this, dval);
        return ival;
    }
    internal bool IsConst()
        => Terms.All(t => t.IsConst());
    internal bool IsNum(int num)
    {
        if (!IsConst())
            return false;
        double val = Terms.Sum(t => t.Coef);
        return Math.Abs(val - num) < 1e-15;
    }


    // ops
    public static implicit operator Sca(Set i)
        => new(new ScaTerm(1.0, (Ind)i, default, default, default));
    public static implicit operator Sca(Ind i)
        => new(new ScaTerm(1.0, i, default, default, default));
    public static implicit operator Sca(Par p)
        => new(new ScaTerm(1.0, default, default, p, default));
    public static implicit operator Sca(ScaTerm t)
        => new(new OptList<ScaTerm>(t));
    public static implicit operator Sca(double n)
        => new(new ScaTerm(n));
    public static implicit operator Sca(int n)
        => new(new ScaTerm(n));
    public static Sca operator -(Sca s)
        => new(s.Terms.Neg());
    public Sca Reciprocal()
        => new(Terms.Reciprocal());


    // ops - sca*sca
    public static Sca operator +(Sca s, Sca t)
        => new(s.Terms + t.Terms);
    public static Sca operator -(Sca s, Sca t)
        => new(s.Terms + t.Terms.Neg());
    public static Sca operator *(Sca s, Sca t)
        => new(s.Terms.Mul(t.Terms));
    public static Sca operator /(Sca s, Sca t)
        => new(s.Terms.Mul(t.Terms.Reciprocal()));

    // ops - sca*double
    public static Sca operator +(Sca s, double n)
        => new(s.Terms + new ScaTerm(n));
    public static Sca operator +(double n, Sca s)
        => s + n;
    public static Sca operator -(Sca s, double n)
        => new(s.Terms + new ScaTerm(-n));
    public static Sca operator -(double n, Sca s)
        => new(new ScaTerm(n) + s.Terms.Neg());
    public static Sca operator *(Sca s, double n)
        => new(s.Terms.Mul(n));
    public static Sca operator *(double n, Sca s)
        => s * n;
    public static Sca operator /(Sca s, double n)
        => new(s.Terms.Div(n));
    public static Sca operator /(double n, Sca s)
        => s.Reciprocal() * n;
    // ops - sca*int
    public static Sca operator +(Sca s, int n)
        => new(s.Terms + new ScaTerm(n));
    public static Sca operator +(int n, Sca s)
        => s + n;
    public static Sca operator -(Sca s, int n)
        => new(s.Terms + new ScaTerm(-n));
    public static Sca operator -(int n, Sca s)
        => new(new ScaTerm(n) + s.Terms.Neg());
    public static Sca operator *(Sca s, int n)
        => new(s.Terms.Mul(n));
    public static Sca operator *(int n, Sca s)
        => s * n;
    public static Sca operator /(Sca s, int n)
        => new(s.Terms.Div(n));
    public static Sca operator /(int n, Sca s)
        => s.Reciprocal() * n;
    // ops - sca*ind
    public static Sca operator +(Sca s, Ind n)
        => new(s.Terms + (ScaTerm)n);
    public static Sca operator +(Ind n, Sca s)
        => s + n;
    public static Sca operator -(Sca s, Ind n)
        => new(s.Terms + new ScaTerm(-1.0, n, default, default, default));
    public static Sca operator -(Ind n, Sca s)
        => new((ScaTerm)n + s.Terms.Neg());
    // ops - sca*par
    public static Sca operator +(Sca s, Par n)
        => new(s.Terms + (ScaTerm)n);
    public static Sca operator +(Par n, Sca s)
        => s + n;
    public static Sca operator -(Sca s, Par n)
        => new(s.Terms + new ScaTerm(-1.0, default, default, n, default));
    public static Sca operator -(Par n, Sca s)
        => new((ScaTerm)n + s.Terms.Neg());


    // op - sum - Sca
    public static SumArg operator |(Set i, Sca s)
        => new(new Sum(s, new(i)));
    public static SumArg operator |((Set i, Set j) sets, Sca s)
        => new(new Sum(s, new(sets.i, sets.j)));
    public static SumArg operator |((Set i, Set j, Set k) sets, Sca s)
        => new(new Sum(s, new(new List<Set>() { sets.i, sets.j, sets.k })));


    // op - obj
    public static ObjFun operator |(ObjDir direction, Sca s)
        => new(direction, s);


    // common
    public override string ToString()
        => string.Join(" + ", Terms);
}
