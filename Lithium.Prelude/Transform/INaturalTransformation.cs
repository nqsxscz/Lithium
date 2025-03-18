using Lithium.Prelude.Control.Trait;
using Lithium.Prelude.Kind;

namespace Lithium.Prelude.Transform;

public interface INaturalTransformation<TC1, TC2>
    where TC1 : IFunctor<TC1>
    where TC2 : IFunctor<TC2>
{
    ITypeConstructor<TC2, T> Apply<T>(
        ITypeConstructor<TC1, T> typeConstructor)
        where T : notnull;
}