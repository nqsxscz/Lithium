using Lithium.Prelude.Algebra.Trait.Group;
using Lithium.Prelude.Algebra.Trait.Group.Additive;
using Lithium.Prelude.Algebra.Trait.Group.Multiplicative;
using Lithium.Prelude.Algebra.Trait.Poset;

namespace Lithium.Prelude.Algebra;

public static class Group
{
    public static T Reciprocate<T>(this T operand)
        where T : IGroup<T>
        => T.Reciprocate(operand);
    
    public static T Negate<T>(this T operand)
        where T : IAdditiveGroup<T>
        => -operand;
    
    public static T Invert<T>(this T operand)
        where T : IMultiplicativeGroup<T>
        => T.Invert(operand);

    public static T Abs<T>(this T operand)
        where T :
        IAdditiveGroup<T>,
        IOrderable<T>
        => T.Maximum(
            operand, 
            -operand);

    public static T Subtract<T>(this T left, T right)
        where T : IAdditiveGroup<T>
        => left - right;
    
    public static T Divide<T>(this T left, T right)
        where T : IMultiplicativeGroup<T>
        => left / right;
}