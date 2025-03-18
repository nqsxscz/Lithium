using Lithium.Prelude.Data.Control.Instance.Maybe.Type;

namespace Lithium.Prelude.Data.Control.Instance.Maybe.Implementation;

internal sealed record Nothing<T>
    : INothing<T>
    where T : notnull;