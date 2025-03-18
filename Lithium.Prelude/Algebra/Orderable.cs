using Lithium.Prelude.Algebra.Trait.Poset;

namespace Lithium.Prelude.Algebra;

public static class Orderable
{
    public static bool Eq<T>(this T left, T right) 
        where T : IOrderable<T>
        => left == right;
    
    public static bool Neq<T>(this T left, T right) 
        where T : IOrderable<T>
        => left != right;
    
    public static bool Lt<T>(this T left, T right) 
        where T : IOrderable<T>
        => left < right;
    
    public static bool Gt<T>(this T left, T right) 
        where T : IOrderable<T>
        => left > right;
    
    public static bool Leq<T>(this T left, T right) 
        where T : IOrderable<T>
        => left <= right;
    
    public static bool Geq<T>(this T left, T right) 
        where T : IOrderable<T>
        => left >= right;
    
    public static T Minimum<T>(this T left, T right) 
        where T : IOrderable<T>
        => T.Minimum(left, right);
    
    public static T Maximum<T>(this T left, T right) 
        where T : IOrderable<T>
        => T.Maximum(left, right);
}