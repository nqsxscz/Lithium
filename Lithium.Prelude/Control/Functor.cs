using Lithium.Prelude.Control.Trait;
using Lithium.Prelude.Kind;

namespace Lithium.Prelude.Control;

public static class Functor
{
    public static ITypeConstructor<TC, T2> 
        Map<TC, T1, T2>(this 
            ITypeConstructor<TC, T1> operand,
            Func<T1, T2> selector)
            where TC : IFunctor<TC>
            where T1 : notnull
            where T2 : notnull
        => TC.Map(operand, selector);
}