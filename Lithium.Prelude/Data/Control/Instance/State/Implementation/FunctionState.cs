using Lithium.Prelude.Data.Control.Instance.State.Type;

namespace Lithium.Prelude.Data.Control.Instance.State.Implementation;

internal sealed record FunctionState<TState, T>(
    Func<TState, (T, TState)> Function)
    : IFunctionState<TState, T>
    where T : notnull;