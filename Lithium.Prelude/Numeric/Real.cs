using Lithium.Prelude.Data.Numeric;
using Lithium.Prelude.Data.Numeric.Instance;
using Lithium.Prelude.Numeric.Trait;
// ReSharper disable MemberCanBePrivate.Global

namespace Lithium.Prelude.Numeric;

public static class Real
{
    public static real ToReal(this double x)
        => x.ToReal<real>();
    
    public static T ToReal<T>(this double x)
        where T : IReal<T>
        => T.Of(x);
    
    public static T Pi<T>()
        where T : IReal<T>
        => T.Pi;
    
    public static T E<T>()
        where T : IReal<T>
        => T.E;
    
    public static T Sqrt<T>(this T t)
        where T : IReal<T>
        => T.Sqrt(t);
    
    public static T Log<T>(this T t)
        where T : IReal<T>
        => T.Log(t);
    
    public static T Exp<T>(this T t)
        where T : IReal<T>
        => T.Exp(t);
    
    public static T Sin<T>(this T t)
        where T : IReal<T>
        => T.Sin(t);
    
    public static T Cos<T>(this T t)
        where T : IReal<T>
        => T.Cos(t);
    
    public static T Tan<T>(this T t)
        where T : IReal<T>
        => T.Tan(t);
    
    public static T Asin<T>(this T t)
        where T : IReal<T>
        => T.Asin(t);
    
    public static T Acos<T>(this T t)
        where T : IReal<T>
        => T.Acos(t);
    
    public static T Atan<T>(this T t)
        where T : IReal<T>
        => T.Atan(t);
    
    public static T Power<T>(
        this T left, 
        T right)
        where T : IReal<T>
        => left ^ right;
}