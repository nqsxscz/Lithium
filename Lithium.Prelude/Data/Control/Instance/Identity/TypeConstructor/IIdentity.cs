using Lithium.Prelude.Control;
using Lithium.Prelude.Control.Trait;
using Lithium.Prelude.Kind;

namespace Lithium.Prelude.Data.Control.Instance.Identity.TypeConstructor;

public interface IIdentity :
    IMonad<IIdentity>,
    ITraversable<IIdentity>
{
    static ITypeConstructor<IIdentity, T>
        IMonad<IIdentity>.Return<T>(T t)
        => t.ToIdentity();

    static ITypeConstructor<IIdentity, T2>
        IMonad<IIdentity>.FlatMap<T1, T2>(
            ITypeConstructor<IIdentity, T1> operand,
            Func<T1, ITypeConstructor<IIdentity, T2>> selector)
        => selector(
            operand
                .ToIdentity()
                .Value);
    
    static ITypeConstructor<IIdentity, T3>
        IApplicative<IIdentity>.Lift<T1, T2, T3>(
            ITypeConstructor<IIdentity, T1> left,
            ITypeConstructor<IIdentity, T2> right,
            Func<T1, T2, T3> combinator)
        => left
            .LiftM(
                right, 
                combinator);

    static T2 IFoldable<IIdentity>.FoldRight<T1, T2>(
        ITypeConstructor<IIdentity, T1> operand,
        T2 init,
        Func<T1, T2, T2> accumulator)
        => accumulator(
            operand
                .ToIdentity()
                .Value, 
            init);

    static ITypeConstructor<TF, ITypeConstructor<IIdentity, T2>>
        ITraversable<IIdentity>.Traverse<TF, T1, T2>(
            ITypeConstructor<IIdentity, T1> operand,
            Func<T1, ITypeConstructor<TF, T2>> traverse)
        => traverse(operand
                .ToIdentity()
                .Value)
            .Map(Control.Identity.Of);
}