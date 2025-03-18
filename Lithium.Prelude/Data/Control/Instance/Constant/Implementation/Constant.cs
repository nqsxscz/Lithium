using Lithium.Prelude.Data.Control.Instance.Constant.Type;

namespace Lithium.Prelude.Data.Control.Instance.Constant.Implementation;

internal sealed record Constant<TResult, T>(
    TResult Value)
    : IConstant<TResult, T>
    where T : notnull;