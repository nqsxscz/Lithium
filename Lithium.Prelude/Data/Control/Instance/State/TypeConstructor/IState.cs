using Lithium.Prelude.Control.Trait;
using Lithium.Prelude.Data.Control.Instance.State.Type;
using Lithium.Prelude.Kind;

#pragma warning disable CS8509 // The switch expression does not handle all possible values of its input type (it is not exhaustive).

namespace Lithium.Prelude.Data.Control.Instance.State.TypeConstructor;

public interface IState<TState> :
    IMonad<IState<TState>>
{
    static ITypeConstructor<IState<TState>, T>
        IMonad<IState<TState>>.Return<T>(T t)
        => t.ToState<TState, T>();

    static ITypeConstructor<IState<TState>, T2>
        IMonad<IState<TState>>.FlatMap<T1, T2>(
            ITypeConstructor<IState<TState>, T1> operand,
            Func<T1, ITypeConstructor<IState<TState>, T2>> mapper)
        => operand switch
        {
            IFunctionState<TState, T1> { Function: var f } =>
                Control.State.Of<TState, T2>(s0 =>
                    f(s0) switch
                    {
                        var (t1, s1) =>
                            mapper(t1)
                                .ToState()
                                .Run(s1)
                    })
        };

    static ITypeConstructor<IState<TState>, T3>
        IApplicative<IState<TState>>.Lift<T1, T2, T3>(
            ITypeConstructor<IState<TState>, T1> left,
            ITypeConstructor<IState<TState>, T2> right,
            Func<T1, T2, T3> combinator)
        => left switch
        {
            IFunctionState<TState, T1> { Function: var f1 } =>
                Control.State.Of<TState, T3>(s0 =>
                    f1(s0) switch
                    {
                        var (t1, s1) =>
                            right switch
                            {
                                IFunctionState<TState, T2> { Function: var f2 } =>
                                    f2(s1) switch
                                    {
                                        var (t2, s2) =>
                                            (combinator(t1, t2), s2)
                                    }
                            }
                    })
        };
}