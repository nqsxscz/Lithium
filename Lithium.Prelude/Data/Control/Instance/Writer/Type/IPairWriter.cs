using Lithium.Prelude.Algebra.Trait.Group;

namespace Lithium.Prelude.Data.Control.Instance.Writer.Type;

public interface IPairWriter<TOutput, out T> 
    : IWriter<TOutput, T>
    where TOutput : IMonoid<TOutput>
    where T : notnull
{
    TOutput Output { get; }
    
    T Value { get; }
}