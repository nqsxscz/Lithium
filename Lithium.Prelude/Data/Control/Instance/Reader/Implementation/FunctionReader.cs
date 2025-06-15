using Lithium.Prelude.Data.Control.Instance.Reader.Type;

namespace Lithium.Prelude.Data.Control.Instance.Reader.Implementation;

internal sealed record FunctionReader<TEnv, T>(
    Func<TEnv, T> Runner)
    : IFunctionReader<TEnv, T>
    where T : notnull;