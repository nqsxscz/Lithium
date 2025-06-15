using Lithium.Prelude.Data.Control.Instance.State.TypeConstructor;
using Lithium.Prelude.Kind;

namespace Lithium.Prelude.Data.Control.Instance.State.Type;

public interface IState<TState, out T>
    : ITypeConstructor<IState<TState>, T>
    where T : notnull;