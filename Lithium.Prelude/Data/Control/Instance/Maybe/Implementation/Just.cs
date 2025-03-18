using Lithium.Prelude.Data.Control.Instance.Maybe.Type;

namespace Lithium.Prelude.Data.Control.Instance.Maybe.Implementation;

internal sealed record Just<T>(T Value)
    : IJust<T>
    where T : notnull;