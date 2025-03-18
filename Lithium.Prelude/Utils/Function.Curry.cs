namespace Lithium.Prelude.Utils;

public static partial class Function
{
    public static Func<T1, Func<T2, T3>>
        Curry<T1, T2, T3>(this Func<T1, T2, T3> f)
        => t1
            => t2
                => f(t1, t2);
    
    public static Func<T1, T2, Func<T3, T4>>
        Curry<T1, T2, T3, T4>(this Func<T1, T2, T3, T4> f)
        => (t1, t2)
            => t3
                => f(t1, t2, t3);
    
    public static Func<T1, T2, T3, Func<T4, T5>>
        Curry<T1, T2, T3, T4, T5>(this Func<T1, T2, T3, T4, T5> f)
        => (t1, t2, t3)
            => t4
                => f(t1, t2, t3, t4);
}