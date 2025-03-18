using Lithium.Prelude.Kind;

namespace Lithium.Prelude.Control.Trait;

public interface IApplicative<TC>
    : IFunctor<TC>
    where TC : IApplicative<TC>
{
    static abstract ITypeConstructor<TC, T> Pure<T>(T t)
        where T : notnull;

    static abstract ITypeConstructor<TC, T3>
        Lift<T1, T2, T3>(
            ITypeConstructor<TC, T1> left,
            ITypeConstructor<TC, T2> right,
            Func<T1, T2, T3> combinator)
        where T1 : notnull
        where T2 : notnull
        where T3 : notnull;
}