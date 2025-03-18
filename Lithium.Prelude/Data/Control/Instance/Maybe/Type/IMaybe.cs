using Lithium.Prelude.Data.Control.Instance.Maybe.TypeConstructor;
using Lithium.Prelude.Kind;

namespace Lithium.Prelude.Data.Control.Instance.Maybe.Type;

public interface IMaybe<out T>
    : ITypeConstructor<IMaybe, T>
    where T : notnull;