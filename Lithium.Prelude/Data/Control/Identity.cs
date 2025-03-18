using Lithium.Prelude.Data.Control.Instance.Identity.Implementation;
using Lithium.Prelude.Data.Control.Instance.Identity.Type;
using Lithium.Prelude.Data.Control.Instance.Identity.TypeConstructor;
using Lithium.Prelude.Kind;

namespace Lithium.Prelude.Data.Control;

public static class Identity
{
    public static IIdentity<T> Of<T>(T t)
        where T : notnull
        => new Identity<T>(t);
    
    public static IIdentity<T> ToIdentity<T>(this T t)
        where T : notnull
        => Of(t);
    
    public static IIdentity<T> ToIdentity<T>(this 
        ITypeConstructor<IIdentity, T> identity)
        where T : notnull
        => (IIdentity<T>) identity;
}