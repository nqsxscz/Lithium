using Lithium.Prelude.Algebra.Trait.Poset;
using Lithium.Prelude.Algebra.Trait.Ring;

namespace Lithium.Prelude.Numeric.Trait;

public interface IInteger<T> :
    IRing<T>, 
    IOrderable<T>
    where T : IInteger<T>
{
    static abstract T Of(long value);
}