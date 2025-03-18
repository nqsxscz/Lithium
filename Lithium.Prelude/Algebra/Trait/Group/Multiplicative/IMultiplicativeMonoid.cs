namespace Lithium.Prelude.Algebra.Trait.Group.Multiplicative;

public interface IMultiplicativeMonoid<T> : 
    IMonoid<T>,
    IMultiplicativeSemigroup<T> 
    where T : IMultiplicativeMonoid<T>
{
    static abstract T One { get; }

    static T IMonoid<T>.Identity
        => T.One;
}