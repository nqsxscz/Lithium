namespace Lithium.Prelude.Algebra.Trait.Group;

public interface IMonoid<T>
    : ISemigroup<T>
    where T : IMonoid<T>
{
    static abstract T Identity { get; }
}