namespace MathProg;

public struct OptList<T> : IEnumerable<T>
{
    // data
    internal Opt<List<T>> MaybeList;
    internal Opt<T> Val1;
    internal Opt<T> Val2;


    // ctor
    public OptList()
    {
        MaybeList = None<List<T>>();
        Val1 = default;
        Val2 = default;
    }
    internal OptList(List<T> list)
    {
        MaybeList = list;
        Val1 = default;
        Val2 = default;
    }
    internal OptList(T val1)
    {
        MaybeList = None<List<T>>();
        Val1 = val1;
        Val2 = default;
    }
    internal OptList(T val1, T val2)
    {
        MaybeList = None<List<T>>();
        Val1 = val1;
        Val2 = val2;
    }


    // method
    public T this[int index]
    {
        get
        {
            if (index >= Length)
                throw Exc.IndOut;

            if (MaybeList.IsSome)
                return MaybeList.Unwrap()[index];
            if (index == 0)
                return Val1.IsSome ? Val1.Unwrap() : throw Exc.IndOut;
            if (index == 1)
                return Val2.IsSome ? Val2.Unwrap() : throw Exc.IndOut;
            throw Exc.IndOut;
        }
        set
        {
            if (index >= Length)
                throw Exc.IndOut;
            
            if (MaybeList.IsSome)
                MaybeList.Unwrap()[index] = value;
            else if (index == 0)
                Val1 = Some(value);
            else if (index == 1)
                Val2 = Some(value);
            else
                throw Exc.IndOut;
        }
    }
    public int Length
    {
        get
        {
            if (MaybeList.IsSome)
                return MaybeList.Unwrap().Count;
            if (Val1.IsNone)
                return 0;
            return Val2.IsNone ? 1 : 2;
        }
    }
    public OptList<T> Clone()
    {
        if (Val1.IsSome)
        {
            if (Val2.IsSome)
                return new(Val1.Unwrap(), Val2.Unwrap());
            else
                return new(Val1.Unwrap());
        }
        else if (MaybeList.IsSome)
            return new(new List<T>(MaybeList.Unwrap()));
        else
            return default;
    }
    public OptList<T> Add(T val)
    {
        if (Val1.IsSome)
        {
            if (Val2.IsSome)
                return new(new List<T>() { Val1.Unwrap(), Val2.Unwrap(), val });
            else
                return new(Val1.Unwrap(), val);
        }
        else if (MaybeList.IsSome)
        {
            var list = new List<T>(MaybeList.Unwrap())
            {
                val
            };
            return new(list);
        }
        else
            return new(val);
    }
    public OptList<T> RemoveAt(int ind)
    {
        if (Val1.IsSome)
        {
            if (Val2.IsSome)
            {
                if (ind == 0)
                    return new(Val2.Unwrap());
                else if (ind == 1)
                    return new(Val1.Unwrap());
                else
                    throw Exc.IndOut;
            }
            else
            {
                if (ind == 0)
                    return default;
                else
                    throw Exc.IndOut;
            }
        }
        else
        {
            var lst = new List<T>(MaybeList.Unwrap());
            lst.RemoveAt(ind);
            if (lst.Count == 2)
                return new(lst[0], lst[1]);
            else if (lst.Count > 2)
                return new(lst);
            else
                throw Exc.IndOut;
        }
    }


    // implicit
    public static implicit operator OptList<T>(T val)
        => new(val);


    // op
    public static OptList<T> operator +(OptList<T> s, OptList<T> t)
    {
        if (s.MaybeList.IsSome)
        {
            if (t.MaybeList.IsSome)
            {
                var sl = s.MaybeList.Unwrap();
                sl.AddRange(t.MaybeList.Unwrap());
                return new(sl);
            }
            else if (t.Val1.IsSome)
            {
                var sl = s.MaybeList.Unwrap();
                sl.Add(t.Val1.Unwrap());
                if (t.Val2.IsSome)
                    sl.Add(t.Val2.Unwrap());
                return new(sl);
            }
            else
                return s;
        }
        else if (s.Val1.IsSome)
        {
            if (s.Val2.IsNone) // s == 1
            {
                if (t.MaybeList.IsSome)
                {
                    var tl = t.MaybeList.Unwrap();
                    tl.Add(s.Val1.Unwrap());
                    return new(tl);
                }
                else if (t.Val1.IsSome)
                {
                    if (t.Val2.IsNone) // t == 1
                        return new(s.Val1.Unwrap(), t.Val1.Unwrap());
                    else
                        return new(new List<T>() { s.Val1.Unwrap(), t.Val1.Unwrap(), t.Val2.Unwrap() });
                }
                else
                    return s;
            }
            else // s == 2
            {
                if (t.MaybeList.IsSome)
                {
                    var tl = t.MaybeList.Unwrap();
                    tl.Add(s.Val1.Unwrap());
                    tl.Add(s.Val2.Unwrap());
                    return new(tl);
                }
                else if (t.Val1.IsSome)
                {
                    if (t.Val2.IsNone) // t == 1
                        return new(new List<T>() { s.Val1.Unwrap(), s.Val2.Unwrap(), t.Val1.Unwrap() });
                    else
                        return new(new List<T>() { s.Val1.Unwrap(), s.Val2.Unwrap(), t.Val1.Unwrap(), t.Val2.Unwrap() });
                }
                else
                    return s;
            }
        }
        else // s == 0
            return t;
    }
    public IEnumerator<T> GetEnumerator()
        => new OptListEnumerator<T>(this);
    IEnumerator IEnumerable.GetEnumerator()
        => new OptListEnumerator<T>(this);


    // common
    public override string ToString()
        => string.Join(",", this);
}
