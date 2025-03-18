using Lithium.Prelude.Data.Control.Instance.Identity.TypeConstructor;
using Lithium.Prelude.Kind;

namespace Lithium.Prelude.Data.Control.Instance.Identity.Type;

public interface IIdentity<out T>
    : ITypeConstructor<IIdentity, T>
    where T : notnull
{
    T Value { get; }
}