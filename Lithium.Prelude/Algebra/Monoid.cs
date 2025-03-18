using Lithium.Prelude.Algebra.Trait.Group;
using Lithium.Prelude.Algebra.Trait.Group.Additive;
using Lithium.Prelude.Algebra.Trait.Group.Multiplicative;

namespace Lithium.Prelude.Algebra;

public static class Monoid
{
    public static T Identity<T>()
        where T : IMonoid<T>
        => T.Identity;
    
    public static T Zero<T>()
        where T : IAdditiveMonoid<T>
        => T.Zero;

    public static T One<T>()
        where T : IMultiplicativeMonoid<T>
        => T.One;
}