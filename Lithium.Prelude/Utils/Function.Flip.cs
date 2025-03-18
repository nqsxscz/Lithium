namespace Lithium.Prelude.Utils;

public static partial class Function
{
    public static Func<T2, T1, T3> Flip<T1, T2, T3>(
        this Func<T1, T2, T3> f)
        => (t2, t1)
            => f(t1, t2);
}