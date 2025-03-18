namespace Lithium.Prelude.Algebra.Trait.Bound;

public interface IBottomable<out T>
    where T : IBottomable<T>
{
    static abstract T Bottom { get; }
}