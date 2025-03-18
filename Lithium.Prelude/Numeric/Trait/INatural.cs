using Lithium.Prelude.Algebra.Trait.Bound;
using Lithium.Prelude.Algebra.Trait.Poset;
using Lithium.Prelude.Algebra.Trait.Ring;

namespace Lithium.Prelude.Numeric.Trait;

public interface INatural<T> :
    ISemiring<T>,
    IOrderable<T>,
    IBottomable<T> 
    where T : INatural<T>
{
    static abstract T Of(ulong value);

    static T IBottomable<T>.Bottom
        => T.Zero;
}