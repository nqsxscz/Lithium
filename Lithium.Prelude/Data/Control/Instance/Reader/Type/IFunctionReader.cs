namespace Lithium.Prelude.Data.Control.Instance.Reader.Type;

public interface IFunctionReader<TEnv, out T> 
    : IReader<TEnv, T>
    where T : notnull
{
    Func<TEnv, T> Runner { get; }
}