namespace Lithium.Prelude.Algebra.Trait.Group.Additive;

public interface IAdditiveMonoid<T> : 
    IMonoid<T>,
    IAdditiveSemigroup<T> 
    where T : IAdditiveMonoid<T>
{
    static abstract T Zero { get; }

    static T IMonoid<T>.Identity
        => T.Zero;
}