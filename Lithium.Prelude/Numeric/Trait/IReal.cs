using Lithium.Prelude.Algebra.Trait.Poset;
using Lithium.Prelude.Algebra.Trait.Ring;

namespace Lithium.Prelude.Numeric.Trait;

public interface IReal<T> :
    IField<T>,
    IOrderable<T>
    where T : IReal<T>
{
    static abstract T Of(double value);
    
    static abstract T Pi { get; }
    
    static abstract T E { get; }
    
    static abstract T Sqrt(T t);
    
    static abstract T Log(T t);
    
    static abstract T Exp(T t);
    
    static abstract T Sin(T t);
    
    static abstract T Cos(T t);
    
    static abstract T Tan(T t);
    
    static abstract T Asin(T t);
    
    static abstract T Acos(T t);
    
    static abstract T Atan(T t);
    
    static abstract T operator ^(
        T left, 
        T right);
}