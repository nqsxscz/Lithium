using Lithium.Prelude.Control.Trait;
using Lithium.Prelude.Data.Control.Instance.Reader.Type;
using Lithium.Prelude.Kind;
using Lithium.Prelude.Utils;
#pragma warning disable CS8509 // The switch expression does not handle all possible values of its input type (it is not exhaustive).

namespace Lithium.Prelude.Data.Control.Instance.Reader.TypeConstructor;

public interface IReader<TEnv> :
    IMonad<IReader<TEnv>>
{
    static ITypeConstructor<IReader<TEnv>, T>
        IMonad<IReader<TEnv>>.Return<T>(T t)
        => t.ToReader<TEnv, T>();

    static ITypeConstructor<IReader<TEnv>, T2>
        IMonad<IReader<TEnv>>.FlatMap<T1, T2>(
            ITypeConstructor<IReader<TEnv>, T1> operand,
            Func<T1, ITypeConstructor<IReader<TEnv>, T2>> mapper)
        => operand switch
        {
            IFunctionReader<TEnv, T1> { Runner: var runner } =>
                Control.Reader.Of<TEnv, T2>(env =>
                    runner.AndThen(mapper)(env)
                        .ToReader()
                        .Run(env))
        };
    
    static ITypeConstructor<IReader<TEnv>, T3>
        IApplicative<IReader<TEnv>>.Lift<T1, T2, T3>(
            ITypeConstructor<IReader<TEnv>, T1> left,
            ITypeConstructor<IReader<TEnv>, T2> right,
            Func<T1, T2, T3> combinator)
        => Control.Reader.Of<TEnv, T3>(env =>
            combinator(
                left.ToReader().Run(env), 
                right.ToReader().Run(env)));
}