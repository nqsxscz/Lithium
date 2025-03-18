using Lithium.Prelude.Algebra.Trait.Group;
using Lithium.Prelude.Algebra.Trait.Group.Additive;
using Lithium.Prelude.Algebra.Trait.Group.Multiplicative;

namespace Lithium.Prelude.Algebra.Trait.Ring;

public interface ISemiring<T> :
    IAdditiveMonoid<T>,
    IMultiplicativeMonoid<T>
    where T : ISemiring<T>
{
    static T IMonoid<T>.Identity
        => T.Zero;

    static T ISemigroup<T>.Combine(T left, T right)
        => left + right;
    
    static virtual T Two
        => T.Successor(T.One);
    
    static virtual T Three
        => T.Successor(T.Two);
    
    static virtual T Four
        => T.Successor(T.Three);
    
    static virtual T Five
        => T.Successor(T.Four);
    
    static virtual T Six
        => T.Successor(T.Five);
    
    static virtual T Seven
        => T.Successor(T.Six);
    
    static virtual T Eight
        => T.Successor(T.Seven);
    
    static virtual T Nine
        => T.Successor(T.Eight);
    
    static virtual T Ten
        => T.Successor(T.Nine);
    
    static virtual T Successor(T t)
        => t + T.One;
}