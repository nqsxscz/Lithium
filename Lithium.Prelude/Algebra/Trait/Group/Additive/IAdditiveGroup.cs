namespace Lithium.Prelude.Algebra.Trait.Group.Additive;

public interface IAdditiveGroup<T> :
    IGroup<T>,
    IAdditiveMonoid<T>
    where T : IAdditiveGroup<T>
{
    static abstract T operator -(T operand);
    
    static virtual T operator -(T left, T right)
        => left + -right;
    
    static T IGroup<T>.Reciprocate(T operand)
        => -operand;
}