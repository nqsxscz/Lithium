using Lithium.Prelude.Algebra.Trait.Group.Additive;

namespace Lithium.Prelude.Algebra.Trait.Ring;

public interface IRing<T> :
    ISemiring<T>,
    IAdditiveGroup<T>
    where T : IRing<T>
{
    static virtual T NegativeOne
        => T.Predecessor(T.Zero);
    
    static virtual T NegativeTwo
        => T.Predecessor(T.One);
    
    static virtual T NegativeThree
        => T.Predecessor(T.Two);
    
    static virtual T NegativeFour
        => T.Predecessor(T.Three);
    
    static virtual T NegativeFive
        => T.Predecessor(T.Four);
    
    static virtual T NegativeSix
        => T.Predecessor(T.Five);
    
    static virtual T NegativeSeven
        => T.Predecessor(T.Six);
    
    static virtual T NegativeEight
        => T.Predecessor(T.Seven);
    
    static virtual T NegativeNine
        => T.Predecessor(T.Eight);
    
    static virtual T NegativeTen
        => T.Predecessor(T.Nine);
    
    static virtual T Predecessor(T t)
        => t - T.One;
}