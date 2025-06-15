using Lithium.Prelude.Algebra.Trait.Group;
using Lithium.Prelude.Data.Control.Instance.Writer.Implementation;
using Lithium.Prelude.Data.Control.Instance.Writer.Type;
using Lithium.Prelude.Data.Control.Instance.Writer.TypeConstructor;
using Lithium.Prelude.Kind;

#pragma warning disable CS8509 // The switch expression does not handle all possible values of its input type (it is not exhaustive).

namespace Lithium.Prelude.Data.Control;

public static class Writer
{
    public static IWriter<TOutput, T> Of<TOutput, T>(
        TOutput output,
        T t)
        where TOutput : IMonoid<TOutput>
        where T : notnull
        => new PairWriter<TOutput,T>(
            output, 
            t);
    
    public static IWriter<TOutput, T> Of<TOutput, T>(
        T t)
        where TOutput : IMonoid<TOutput>
        where T : notnull
        => Of(
            TOutput.Identity, 
            t);
    
    public static IWriter<TOutput, T> ToWriter<TOutput, T>(this 
        ITypeConstructor<IWriter<TOutput>, T> writer)
        where TOutput : IMonoid<TOutput>
        where T : notnull
        => (IWriter<TOutput, T>) writer;
    
    public static IWriter<TOutput, T> ToWriter<TOutput, T>(this 
        T t)
        where TOutput : IMonoid<TOutput>
        where T : notnull
        => Of<TOutput, T>(t);
    
    public static IWriter<TOutput, T> ToWriter<TOutput, T>(this 
        (T, TOutput) p)
        where TOutput : IMonoid<TOutput>
        where T : notnull
        => Of(p.Item2, p.Item1);
    
    public static IWriter<TOutput, T> ToWriter<TOutput, T>(this 
        (TOutput, T) p)
        where TOutput : IMonoid<TOutput>
        where T : notnull
        => Of(p.Item1, p.Item2);
    
    public static (T, TOutput) Run<TOutput, T>(this 
        IWriter<TOutput, T> writer)
        where TOutput : IMonoid<TOutput>
        where T : notnull
        => writer switch
        {
            IPairWriter<TOutput, T> { Output: var output, Value: var t } =>
                (t, output)
        };

    public static TOutput Execute<TOutput, T>(this
        IWriter<TOutput, T> writer)
        where TOutput : IMonoid<TOutput>
        where T : notnull
        => writer.Run()
            .Item2;

    public static IWriter<TOutput2, T2> Map<TOutput1, TOutput2, T1, T2>(this
        IWriter<TOutput1, T1> writer,
        Func<(T1, TOutput1), (T2, TOutput2)> mapper)
        where TOutput1 : IMonoid<TOutput1>
        where TOutput2 : IMonoid<TOutput2>
        where T1 : notnull
        where T2 : notnull
        => mapper(writer.Run())
            .ToWriter();
    
    public static IWriter<TOutput2, T2> Map<TOutput1, TOutput2, T1, T2>(this
        IWriter<TOutput1, T1> writer,
        Func<T1, TOutput1, (T2, TOutput2)> mapper)
        where TOutput1 : IMonoid<TOutput1>
        where TOutput2 : IMonoid<TOutput2>
        where T1 : notnull
        where T2 : notnull
        => writer.Map(p => 
            mapper(
                p.Item1, 
                p.Item2));
}