using Lithium.Prelude.Data.Control.Instance.State.Implementation;
using Lithium.Prelude.Data.Control.Instance.State.Type;
using Lithium.Prelude.Data.Control.Instance.State.TypeConstructor;
using Lithium.Prelude.Kind;
using Lithium.Prelude.Utils;

#pragma warning disable CS8509 // The switch expression does not handle all possible values of its input type (it is not exhaustive).

namespace Lithium.Prelude.Data.Control;

public static class State
{
    public static IState<TState, T> Of<TState, T>(
        Func<TState, (T, TState)> f)
        where T : notnull
        => new FunctionState<TState, T>(f);
    
    public static IState<TState, T> Of<TState, T>(
        T t)
        where T : notnull
        => Of<TState, T>(s => (t, s));
    
    public static IState<TState, T> ToState<TState, T>(this 
        ITypeConstructor<IState<TState>, T> state)
        where T : notnull
        => (IState<TState, T>) state;
    
    public static IState<TState, T> ToState<TState, T>(this 
        Func<TState, (T, TState)> f)
        where T : notnull
        => Of(f);
    
    public static IState<TState, T> ToState<TState, T>(this 
        T t)
        where T : notnull
        => Of<TState, T>(t);

    public static (T, TState) Run<TState, T>(this
        IState<TState, T> state,
        TState s)
        where T : notnull
        => state switch
        {
            IFunctionState<TState, T> { Function: var function } =>
                function(s)
        };
    
    public static T Evaluate<TState, T>(this
        IState<TState, T> state,
        TState s)
        where T : notnull
        => state.Run(s)
            .Item1;
    
    public static TState Execute<TState, T>(this
        IState<TState, T> state,
        TState s)
        where T : notnull
        => state.Run(s)
            .Item2;

    public static IState<TState, T2> Map<TState, T1, T2>(this
        IState<TState, T1> state,
        Func<(T1, TState), (T2, TState)> mapper)
        where T1 : notnull
        where T2 : notnull
        => state switch
        {
            IFunctionState<TState, T1> { Function: var function } =>
                function.AndThen(mapper)
                    .ToState()
        };
    
    public static IState<TState, T> With<TState, T>(this
        IState<TState, T> state,
        Func<TState, TState> mapper)
        where T : notnull
        => state switch
        {
            IFunctionState<TState, T> { Function: var function } =>
                mapper.AndThen(function)
                    .ToState()
        };
}