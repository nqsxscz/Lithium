using Lithium.Prelude.Data.Control.Instance.Reader.Implementation;
using Lithium.Prelude.Data.Control.Instance.Reader.Type;
using Lithium.Prelude.Data.Control.Instance.Reader.TypeConstructor;
using Lithium.Prelude.Kind;

#pragma warning disable CS8509 // The switch expression does not handle all possible values of its input type (it is not exhaustive).

namespace Lithium.Prelude.Data.Control;

public static class Reader
{
    public static IReader<TEnv, T> Of<TEnv, T>(
        Func<TEnv, T> f)
        where T : notnull
        => new FunctionReader<TEnv, T>(f);

    public static IReader<TEnv, T> Of<TEnv, T>(
        T t)
        where T : notnull
        => Of<TEnv, T>(_ => t);
    
    public static IReader<TEnv, T> ToReader<TEnv, T>(this 
        ITypeConstructor<IReader<TEnv>, T> reader)
        where T : notnull
        => (IReader<TEnv, T>) reader;
    
    public static IReader<TEnv, T> ToReader<TEnv, T>(this 
        Func<TEnv, T> f)
        where T : notnull
        => Of(f);
    
    public static IReader<TEnv, T> ToReader<TEnv, T>(this 
        T t)
        where T : notnull
        => Of<TEnv, T>(t);

    public static T Run<TEnv, T>(this 
        IReader<TEnv, T> reader,
        TEnv env)
        where T : notnull
        => reader switch
        {
            IFunctionReader<TEnv, T> { Runner: var runner } =>
                runner(env)
        };

    public static IReader<TEnv2, T> With<TEnv1, TEnv2, T>(this
        IReader<TEnv1, T> reader,
        Func<TEnv2, TEnv1> f)
        where T : notnull
        => Of<TEnv2, T>(env =>
            reader.Run(f(env)));
}