namespace Lithium.Prelude.Algebra.Trait.Group;

public interface ISemigroup<T>
    where T : ISemigroup<T>
{
    static abstract T Combine(T left, T right);
}