namespace Lithium.Prelude.Utils;

public static partial class Function
{
    public static (T1, T2) Tuple2<T1, T2>(
        T1 t1, 
        T2 t2)
        => (t1, t2);
    
    public static (T1, T2, T3) Tuple3<T1, T2, T3>(
        T1 t1, 
        T2 t2, 
        T3 t3)
        => (t1, t2, t3);
    
    public static (T1, T2, T3, T4) Tuple4<T1, T2, T3, T4>(
        T1 t1, 
        T2 t2, 
        T3 t3, 
        T4 t4)
        => (t1, t2, t3, t4);
}