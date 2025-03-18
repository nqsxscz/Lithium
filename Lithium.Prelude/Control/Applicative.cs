using Lithium.Prelude.Control.Trait;
using Lithium.Prelude.Kind;
using Lithium.Prelude.Utils;
// ReSharper disable MemberCanBePrivate.Global

namespace Lithium.Prelude.Control;

public static class Applicative
{
    public static ITypeConstructor<TC, T3> 
        Lift<TC, T1, T2, T3>(this 
            ITypeConstructor<TC, T1> left,
            ITypeConstructor<TC, T2> right,
            Func<T1, T2, T3> combinator) 
        where TC : IApplicative<TC>
        where T1 : notnull
        where T2 : notnull
        where T3 : notnull
        => TC.Lift(left, right, combinator);
    
    public static ITypeConstructor<TC, T4> 
        Lift<TC, T1, T2, T3, T4>(this 
            ITypeConstructor<TC, T1> operand1,
            ITypeConstructor<TC, T2> operand2,
            ITypeConstructor<TC, T3> operand3,
            Func<T1, T2, T3, T4> combinator)
        where TC : IApplicative<TC>
        where T1 : notnull
        where T2 : notnull
        where T3 : notnull
        where T4 : notnull
        => Lift(
                operand1, 
                operand2, 
                combinator.Curry())
            .Apply(operand3);
    
    public static ITypeConstructor<TC, T5> 
        Lift<TC, T1, T2, T3, T4, T5>(this 
            ITypeConstructor<TC, T1> operand1,
            ITypeConstructor<TC, T2> operand2,
            ITypeConstructor<TC, T3> operand3,
            ITypeConstructor<TC, T4> operand4,
            Func<T1, T2, T3, T4, T5> combinator)
        where TC : IApplicative<TC>
        where T1 : notnull
        where T2 : notnull
        where T3 : notnull
        where T4 : notnull
        where T5 : notnull
        => Lift(
                operand1, 
                operand2, 
                operand3,
                combinator.Curry())
            .Apply(operand4);
    
    public static ITypeConstructor<TC, T2> 
        Apply<TC, T1, T2>(this 
            ITypeConstructor<TC, Func<T1, T2>> f,
            ITypeConstructor<TC, T1> operand)
        where TC : IApplicative<TC>
        where T1 : notnull
        where T2 : notnull
        => Apply(f)(operand);
    
    public static ITypeConstructor<TC, T2> 
        Apply<TC, T1, T2>(this 
            ITypeConstructor<TC, T1> operand,
            ITypeConstructor<TC, Func<T1, T2>> f)
        where TC : IApplicative<TC>
        where T1 : notnull
        where T2 : notnull
        => f.Apply(operand);

    public static Func<ITypeConstructor<TC, T1>, ITypeConstructor<TC, T2>>
        Apply<TC, T1, T2>(this 
            ITypeConstructor<TC, Func<T1, T2>> f)
        where TC : IApplicative<TC>
        where T1 : notnull
        where T2 : notnull
        => operand
            => Lift(
                f,
                operand,
                (g, t1) => g(t1));
    
    public static ITypeConstructor<TC, (T1, T2)> 
        Zip<TC, T1, T2>(this 
            ITypeConstructor<TC, T1> left,
            ITypeConstructor<TC, T2> right)
        where TC : IApplicative<TC>
        where T1 : notnull
        where T2 : notnull
        => Lift(
            left, 
            right, 
            Function.Tuple2);
    
    public static ITypeConstructor<TC, (T1, T2, T3)> 
        Zip<TC, T1, T2, T3>(this 
            ITypeConstructor<TC, T1> operand1, 
            ITypeConstructor<TC, T2> operand2,
            ITypeConstructor<TC, T3> operand3)
        where TC : IApplicative<TC>
        where T1 : notnull
        where T2 : notnull
        where T3 : notnull
        => Lift(
            operand1, 
            operand2, 
            operand3, 
            Function.Tuple3);
    
    public static ITypeConstructor<TC, (T1, T2, T3, T4)> 
        Zip<TC, T1, T2, T3, T4>(this 
            ITypeConstructor<TC, T1> operand1, 
            ITypeConstructor<TC, T2> operand2,
            ITypeConstructor<TC, T3> operand3,
            ITypeConstructor<TC, T4> operand4)
        where TC : IApplicative<TC>
        where T1 : notnull
        where T2 : notnull
        where T3 : notnull
        where T4 : notnull
        => Lift(
            operand1, 
            operand2, 
            operand3, 
            operand4, 
            Function.Tuple4);
}