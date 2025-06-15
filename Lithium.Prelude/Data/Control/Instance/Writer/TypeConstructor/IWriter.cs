using Lithium.Prelude.Algebra.Trait.Group;
using Lithium.Prelude.Control.Trait;
using Lithium.Prelude.Kind;

namespace Lithium.Prelude.Data.Control.Instance.Writer.TypeConstructor;

public interface IWriter<TOutput> :
    IMonad<IWriter<TOutput>>
    where TOutput : IMonoid<TOutput>
{
    static ITypeConstructor<IWriter<TOutput>, T>
        IMonad<IWriter<TOutput>>.Return<T>(T t)
        => t.ToWriter<TOutput, T>();

    static ITypeConstructor<IWriter<TOutput>, T2>
        IMonad<IWriter<TOutput>>.FlatMap<T1, T2>(
            ITypeConstructor<IWriter<TOutput>, T1> operand,
            Func<T1, ITypeConstructor<IWriter<TOutput>, T2>> mapper)
        => operand.ToWriter().Run() switch
        {
            var (t1, output1) =>
                mapper(t1).ToWriter().Run() switch
                {
                    var (t2, output2) =>
                        Control.Writer.Of(
                            TOutput.Combine(
                                output1, 
                                output2), 
                            t2)
                }
        };

    static ITypeConstructor<IWriter<TOutput>, T3>
        IApplicative<IWriter<TOutput>>.Lift<T1, T2, T3>(
            ITypeConstructor<IWriter<TOutput>, T1> left,
            ITypeConstructor<IWriter<TOutput>, T2> right,
            Func<T1, T2, T3> combinator)
        => (left.ToWriter().Run(), right.ToWriter().Run()) switch
        {
            var ((t1, output1), (t2, output2)) =>
                Control.Writer.Of(
                    TOutput.Combine(
                        output1,
                        output2),
                    combinator(t1, t2))
        };
}