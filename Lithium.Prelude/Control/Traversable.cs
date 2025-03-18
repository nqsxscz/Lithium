using Lithium.Prelude.Control.Trait;
using Lithium.Prelude.Kind;
using Lithium.Prelude.Utils;
// ReSharper disable MemberCanBePrivate.Global

namespace Lithium.Prelude.Control;

public static class Traversable
{
    public static ITypeConstructor<TF, ITypeConstructor<TC, T2>>
        Traverse<TC, TF, T1, T2>(this 
            ITypeConstructor<TC, T1> operand,
            Func<T1, ITypeConstructor<TF, T2>> traverse)
        where TC : ITraversable<TC>
        where TF : IApplicative<TF>
        where T1 : notnull
        where T2 : notnull
        => TC.Traverse(operand, traverse);

    public static ITypeConstructor<TF, ITypeConstructor<TC, T>>
        Sequence<TC, TF, T>(this 
            ITypeConstructor<TC, ITypeConstructor<TF, T>> operand)
        where TC : ITraversable<TC>
        where TF : IApplicative<TF>
        where T : notnull
        => operand.Traverse(Function.Identity);
}