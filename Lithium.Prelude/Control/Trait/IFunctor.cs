using Lithium.Prelude.Kind;

namespace Lithium.Prelude.Control.Trait;

public interface IFunctor<TC>
    where TC : IFunctor<TC>
{
    static abstract ITypeConstructor<TC, T2> 
        Map<T1, T2>(
            ITypeConstructor<TC, T1> operand, 
            Func<T1, T2> selector)
        where T1 : notnull
        where T2 : notnull;
}