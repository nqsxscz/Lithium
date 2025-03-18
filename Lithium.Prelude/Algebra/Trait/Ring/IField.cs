using Lithium.Prelude.Algebra.Trait.Group;
using Lithium.Prelude.Algebra.Trait.Group.Multiplicative;

namespace Lithium.Prelude.Algebra.Trait.Ring;

public interface IField<T> :
    IRing<T>,
    IMultiplicativeGroup<T>
    where T : IField<T>
{
    static T IGroup<T>.Reciprocate(T operand)
        => -operand;
}