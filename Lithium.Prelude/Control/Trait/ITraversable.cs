using Lithium.Prelude.Kind;

namespace Lithium.Prelude.Control.Trait;

public interface ITraversable<TC> :
    IFunctor<TC>,
    IFoldable<TC>
    where TC : ITraversable<TC>
{
    static abstract ITypeConstructor<TF, ITypeConstructor<TC, T2>>
        Traverse<TF, T1, T2>(
            ITypeConstructor<TC, T1> operand,
            Func<T1, ITypeConstructor<TF, T2>> traverse)
        where TF : IApplicative<TF>
        where T1 : notnull
        where T2 : notnull;
}