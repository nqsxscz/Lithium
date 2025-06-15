using Lithium.Prelude.Algebra.Trait.Group;
using Lithium.Prelude.Data.Control.Instance.Writer.Type;

namespace Lithium.Prelude.Data.Control.Instance.Writer.Implementation;

internal sealed record PairWriter<TOutput, T>(
    TOutput Output,
    T Value)
    : IPairWriter<TOutput, T>
    where TOutput : IMonoid<TOutput>
    where T : notnull;