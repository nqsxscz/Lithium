using Lithium.Prelude.Data.Control.Instance.Identity.Type;

namespace Lithium.Prelude.Data.Control.Instance.Identity.Implementation;

internal sealed record Identity<T>(
    T Value)
    : IIdentity<T>
    where T : notnull;