using Lithium.Prelude.Data.Control.Instance.Constant.TypeConstructor;
using Lithium.Prelude.Kind;

namespace Lithium.Prelude.Data.Control.Instance.Constant.Type;

public interface IConstant<TResult, out T>
    : ITypeConstructor<IConstant<TResult>, T>
    where T : notnull
{
    TResult Value { get; }
}