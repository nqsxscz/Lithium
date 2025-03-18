namespace Lithium.Prelude.Utils;

public static partial class Function
{
    public static Func<T1, T3> AndThen<T1, T2, T3>(this 
        Func<T1, T2> f1,
        Func<T2, T3> f2)
        => t1 
            => f2(f1(t1));
}