namespace Lithium.Prelude.Algebra.Trait.Bound;

public interface IToppable<out T>
    where T : IToppable<T>
{
    static abstract T Top { get; }
}