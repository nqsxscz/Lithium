using Lithium.Prelude.Algebra.Trait.Group;
using Lithium.Prelude.Data.Control.Instance.Writer.TypeConstructor;
using Lithium.Prelude.Kind;

namespace Lithium.Prelude.Data.Control.Instance.Writer.Type;

public interface IWriter<TOutput, out T>
    : ITypeConstructor<IWriter<TOutput>, T>
    where TOutput : IMonoid<TOutput>
    where T : notnull;