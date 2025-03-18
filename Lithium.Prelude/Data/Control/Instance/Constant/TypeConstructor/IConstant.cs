using Lithium.Prelude.Control.Trait;
using Lithium.Prelude.Kind;

namespace Lithium.Prelude.Data.Control.Instance.Constant.TypeConstructor;

public interface IConstant<TResult>
    : IFunctor<IConstant<TResult>>
{
    static ITypeConstructor<IConstant<TResult>, T2>
        IFunctor<IConstant<TResult>>.Map<T1, T2>(
            ITypeConstructor<IConstant<TResult>, T1> operand,
            Func<T1, T2> selector)
        => operand
            .ToConstant()
            .Value
            .ToConstant<TResult, T2>();
}