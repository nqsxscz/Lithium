using Lithium.Prelude.Kind;
using Lithium.Prelude.Utils;

namespace Lithium.Prelude.Control.Trait;

public interface IMonad<TC>
    : IApplicative<TC>
    where TC : IMonad<TC>
{
    static abstract ITypeConstructor<TC, T> Return<T>(T t)
        where T : notnull;

    static abstract ITypeConstructor<TC, T2> 
        FlatMap<T1, T2>(
            ITypeConstructor<TC, T1> operand, 
            Func<T1, ITypeConstructor<TC, T2>> selector)
        where T1 : notnull
        where T2 : notnull;
    
    static virtual ITypeConstructor<TC, T3> 
        LiftM<T1, T2, T3>(
            ITypeConstructor<TC, T1> left, 
            ITypeConstructor<TC, T2> right, 
            Func<T1, T2, T3> combinator)
        where T1 : notnull
        where T2 : notnull
        where T3 : notnull
        => TC.FlatMap(
            left, 
            l =>
                TC.Map(
                    right, 
                    r => combinator(l, r)));
    
    static ITypeConstructor<TC, T2> 
        IFunctor<TC>.Map<T1, T2>(
            ITypeConstructor<TC, T1> operand, 
            Func<T1, T2> selector)
        => TC.FlatMap(
            operand, 
            selector
                .AndThen(TC.Return));

    static ITypeConstructor<TC, T> IApplicative<TC>.Pure<T>(T t)
        => TC.Return(t);
}