namespace Lithium.Prelude.Algebra.Trait.Group.Multiplicative;

public interface IMultiplicativeGroup<T> :
    IGroup<T>,
    IMultiplicativeMonoid<T>
    where T : IMultiplicativeGroup<T>
{
    static abstract T Invert(T operand);
    
    static virtual T operator /(T left, T right)
        => left * T.Invert(right);
    
    static T IGroup<T>.Reciprocate(T operand)
        => T.Invert(operand);
}