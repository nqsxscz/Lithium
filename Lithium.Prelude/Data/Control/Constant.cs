using Lithium.Prelude.Data.Control.Instance.Constant.Implementation;
using Lithium.Prelude.Data.Control.Instance.Constant.Type;
using Lithium.Prelude.Data.Control.Instance.Constant.TypeConstructor;
using Lithium.Prelude.Kind;
// ReSharper disable MemberCanBePrivate.Global

namespace Lithium.Prelude.Data.Control;

public static class Constant
{
    public static IConstant<TResult, T> Of<TResult, T>(
        TResult value)
        where T : notnull
        => new Constant<TResult, T>(value);
    
    public static IConstant<TResult, T> ToConstant<TResult, T>(
        this TResult value)
        where T : notnull
        => Of<TResult, T>(value);
    
    public static IConstant<TResult, T> ToConstant<TResult, T>(
        this ITypeConstructor<IConstant<TResult>, T> constant)
        where T : notnull
        => (IConstant<TResult, T>) constant;
}