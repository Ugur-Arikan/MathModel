using MathProg.DefaultKeys;

namespace MathProg;

public class Model
{
    // data
    internal readonly Dictionary<string, IVar> Vars;
    internal readonly Dictionary<string, Constr> Constrs;
    internal ObjFun ObjFun;


    // ctor
    public Model(Opt<ObjFun> objFun = default)
    {
        Vars = new();
        Constrs = new();
        ObjFun = objFun.UnwrapOr(ObjFun.Zero);
    }
    // ctor
    public static Model New()
        => new();
    public static Model New(ObjFun obj)
        => new(Some(obj));
    public static Res<Model> New(params Constr[] constrs)
        => New(Some(ObjFun.Zero), constrs);
    public static Res<Model> New(ObjFun obj, params Constr[] constrs)
        => New(Some(obj), constrs);
    public static Res<Model> New(params (string ConstrKey, Constr Con)[] constrs)
        => New(Some(ObjFun.Zero), constrs);
    public static Res<Model> New(ObjFun obj, params (string ConstrKey, Constr Con)[] constrs)
        => New(Some(obj), constrs);
    public static Res<Model> New(IEnumerable<Constr> constrs)
        => New(Some(ObjFun.Zero), constrs);
    public static Res<Model> New(ObjFun obj, IEnumerable<Constr> constrs)
        => New(Some(obj), constrs);
    public static Res<Model> New(IEnumerable<(string ConstrKey, Constr Con)> constrs)
        => New(Some(ObjFun.Zero), constrs);
    public static Res<Model> New(ObjFun obj, IEnumerable<(string ConstrKey, Constr Con)> constrs)
        => New(Some(obj), constrs);
    public static Res<Model> New(Dictionary<string, Constr> constrs)
        => New(Some(ObjFun.Zero), constrs.Select(x => (x.Key, x.Value)));
    public static Res<Model> New(ObjFun obj, Dictionary<string, Constr> constrs)
        => New(Some(obj), constrs.Select(x => (x.Key, x.Value)));
    // ctor helpers
    static Res<Model> New(Opt<ObjFun> obj, IEnumerable<Constr> constrs)
    {
        Model mdl = new(obj);
        return constrs.Select(c => mdl.AddConstr(c)).Reduce().Map(mdl);
    }
    static Res<Model> New(Opt<ObjFun> obj, IEnumerable<(string ConstrKey, Constr Con)> constrs)
    {
        Model mdl = new(obj);
        return constrs.Select(c => mdl.AddConstr(c.ConstrKey, c.Con)).Reduce().Map(mdl);
    }


    // constrs - prop
    public Constr this[string constrKey]
    {
        get => Constrs[constrKey];
        set
        {
            if (Constrs.ContainsKey(constrKey))
                Constrs.Remove(constrKey);
            AddConstr(constrKey, value);
        }
    }
    public Res AddConstr(string key, Constr constr)
    {
        Dictionary<string, IVar> tempVars = new();
        return 
            OkIf(Constrs.ContainsKey(key))
            .FlatMap(() => CheckExprVars(constr, Vars, tempVars, constr.Ineq.LhsMinRhs))
            .Do(() =>
            {
                foreach (var item in tempVars)
                    if (!Vars.ContainsKey(item.Key))
                        Vars.Add(item.Key, item.Value);
                Constrs.Add(key, constr);
            });
    }
    public Res AddConstr(Constr constr)
        => AddConstr(DefaultConKeys.Get(Constrs), constr);
    // constrs - op
    public static Model operator +(Model m, Constr c)
    {
        m.AddConstr(c);
        return m;
    }
    public static Model operator +(Model m, (Constr, Constr) constrs)
    {
        m.AddConstr(constrs.Item1);
        m.AddConstr(constrs.Item2);
        return m;
    }
    public static Model operator +(Model m, (Constr, Constr, Constr) constrs)
    {
        m.AddConstr(constrs.Item1);
        m.AddConstr(constrs.Item2);
        m.AddConstr(constrs.Item3);
        return m;
    }
    public static Model operator +(Model m, (Constr, Constr, Constr, Constr) constrs)
    {
        m.AddConstr(constrs.Item1);
        m.AddConstr(constrs.Item2);
        m.AddConstr(constrs.Item3);
        m.AddConstr(constrs.Item4);
        return m;
    }
    public static Model operator +(Model m, (Constr, Constr, Constr, Constr, Constr) constrs)
    {
        m.AddConstr(constrs.Item1);
        m.AddConstr(constrs.Item2);
        m.AddConstr(constrs.Item3);
        m.AddConstr(constrs.Item4);
        m.AddConstr(constrs.Item5);
        return m;
    }
    public static Model operator +(Model m, (Constr, Constr, Constr, Constr, Constr, Constr) constrs)
    {
        m.AddConstr(constrs.Item1);
        m.AddConstr(constrs.Item2);
        m.AddConstr(constrs.Item3);
        m.AddConstr(constrs.Item4);
        m.AddConstr(constrs.Item5);
        m.AddConstr(constrs.Item6);
        return m;
    }
    public static Model operator +(Model m, (Constr, Constr, Constr, Constr, Constr, Constr, Constr) constrs)
    {
        m.AddConstr(constrs.Item1);
        m.AddConstr(constrs.Item2);
        m.AddConstr(constrs.Item3);
        m.AddConstr(constrs.Item4);
        m.AddConstr(constrs.Item5);
        m.AddConstr(constrs.Item6);
        m.AddConstr(constrs.Item7);
        return m;
    }
    public static Model operator +(Model m, (Constr, Constr, Constr, Constr, Constr, Constr, Constr, Constr) constrs)
    {
        m.AddConstr(constrs.Item1);
        m.AddConstr(constrs.Item2);
        m.AddConstr(constrs.Item3);
        m.AddConstr(constrs.Item4);
        m.AddConstr(constrs.Item5);
        m.AddConstr(constrs.Item6);
        m.AddConstr(constrs.Item7);
        m.AddConstr(constrs.Item8);
        return m;
    }
    public static Model operator +(Model m, (Constr, Constr, Constr, Constr, Constr, Constr, Constr, Constr, Constr) constrs)
    {
        m.AddConstr(constrs.Item1);
        m.AddConstr(constrs.Item2);
        m.AddConstr(constrs.Item3);
        m.AddConstr(constrs.Item4);
        m.AddConstr(constrs.Item5);
        m.AddConstr(constrs.Item6);
        m.AddConstr(constrs.Item7);
        m.AddConstr(constrs.Item8);
        m.AddConstr(constrs.Item9);
        return m;
    }
    public static Model operator +(Model m, (Constr, Constr, Constr, Constr, Constr, Constr, Constr, Constr, Constr, Constr) constrs)
    {
        m.AddConstr(constrs.Item1);
        m.AddConstr(constrs.Item2);
        m.AddConstr(constrs.Item3);
        m.AddConstr(constrs.Item4);
        m.AddConstr(constrs.Item5);
        m.AddConstr(constrs.Item6);
        m.AddConstr(constrs.Item7);
        m.AddConstr(constrs.Item8);
        m.AddConstr(constrs.Item9);
        m.AddConstr(constrs.Item10);
        return m;
    }
    // constrs -  helper
    static Res CheckExprVars(object constrOrObj, Dictionary<string, IVar> vars, Dictionary<string, IVar> tempVars, Expr e)
    {
        return e.Terms.Select(t => CheckTermVar(constrOrObj, vars, tempVars, t))
            .Concat(e.Sums.Select(s => CheckExprVars(constrOrObj, vars, tempVars, s.Expr)))
            .Reduce();
    }
    static Res CheckTermVar(object constrOrObj, Dictionary<string, IVar> vars, Dictionary<string, IVar> tempVars, Term t)
    {
        return IsTermVarPresent(constrOrObj, tempVars, t)
            .Do(isPresent =>
            {
                if (!isPresent)
                    tempVars.Add(t.Var.Variable.Key, t.Var.Variable);
            })
            .FlatMap(() => IsTermVarPresent(constrOrObj, vars, t))
            .WithoutVal();
    }
    static Res<bool> IsTermVarPresent(object constrOrObj, Dictionary<string, IVar> vars, Term t)
    {
        var newVar = t.Var.Variable;
        if (vars.TryGetValue(newVar.Key, out var oldVar))
        {
            if (newVar != oldVar)
                return Err<bool>(
                    string.Format(
                        "Model already contains another variable with key '{0}' and dimension {1}; cannot add constraint\n{2}",
                        oldVar.Key, oldVar.Dim, constrOrObj));
            return true;
        }
        return false;
    }


    // obj
    public ObjFun Obj
    {
        get => ObjFun;
        set
        {
            Dictionary<string, IVar> tempVars = new();
            CheckExprVars(value, Vars, tempVars, value.Expr).ThrowIfErr();
            ObjFun = value;
        }
    }


    // method
    public LpBuildErrors CreateLpFile(string lpFilepath)
    {
        using StreamWriter w = new(lpFilepath);
        return Lp.Builder.WriteModel(w, this);
    }


    // text
    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.AppendLine(ObjFun.ToString());
        sb.AppendLine("subject to");
        foreach (var item in Constrs)
            sb.AppendLine(item.Value.ToString(item.Key));
        return sb.ToString();
    }
}
