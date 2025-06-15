namespace Lithium.Prelude.Data.Control.Instance.State.Type;

public interface IFunctionState<TState, T> 
    : IState<TState, T>
    where T : notnull
{
    Func<TState, (T, TState)> Function { get; }
}