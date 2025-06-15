using Lithium.Prelude.Data.Control.Instance.Reader.TypeConstructor;
using Lithium.Prelude.Kind;

namespace Lithium.Prelude.Data.Control.Instance.Reader.Type;

public interface IReader<TEnv, out T> 
    : ITypeConstructor<IReader<TEnv>, T>
    where T : notnull;