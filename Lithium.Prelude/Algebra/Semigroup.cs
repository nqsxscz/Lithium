using Lithium.Prelude.Algebra.Trait.Group.Additive;
using Lithium.Prelude.Algebra.Trait.Group.Multiplicative;

namespace Lithium.Prelude.Algebra;

public static class Semigroup
{
    public static T Add<T>(this T left, T right)
        where T : IAdditiveSemigroup<T>
        => left + right;
    
    public static T Multiply<T>(this T left, T right)
        where T : IMultiplicativeSemigroup<T>
        => left * right;
    
    public static T Square<T>(this T operand)
        where T : IMultiplicativeSemigroup<T>
        => operand * operand;
}