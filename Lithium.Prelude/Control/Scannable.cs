using Lithium.Prelude.Algebra;
using Lithium.Prelude.Algebra.Trait.Bound;
using Lithium.Prelude.Algebra.Trait.Group;
using Lithium.Prelude.Algebra.Trait.Group.Additive;
using Lithium.Prelude.Algebra.Trait.Group.Multiplicative;
using Lithium.Prelude.Algebra.Trait.Poset;
using Lithium.Prelude.Control.Trait;
using Lithium.Prelude.Kind;
using Lithium.Prelude.Utils;
// ReSharper disable MemberCanBePrivate.Global

namespace Lithium.Prelude.Control;

public static class Scannable
{
    public static ITypeConstructor<TC, T2> 
        ScanRight<TC, T1, T2>(this 
            ITypeConstructor<TC, T1> operand, 
            T2 init, 
            Func<T1, T2, T2> accumulator)
        where TC : IScannable<TC>
        where T1 : notnull
        where T2 : notnull
        => TC.ScanRight(operand, init, accumulator);

    public static ITypeConstructor<TC, T3> 
        ScanRight<TC, T1, T2, T3>(this 
            ITypeConstructor<TC, T1> operand1, 
            ITypeConstructor<TC, T2> operand2,
            T3 init,
            Func<T1, T2, T3, T3> accumulator)
        where TC : 
            IScannable<TC>, 
            IApplicative<TC>
        where T1 : notnull
        where T2 : notnull
        where T3 : notnull
        => operand1
            .Zip(operand2)
            .ScanRight(init,
                (t, x) =>
                    accumulator(
                        t.Item1,
                        t.Item2,
                        x));
    
    public static ITypeConstructor<TC, T4> 
        ScanRight<TC, T1, T2, T3, T4>(this 
            ITypeConstructor<TC, T1> operand1,
            ITypeConstructor<TC, T2> operand2,
            ITypeConstructor<TC, T3> operand3,
            T4 init,
            Func<T1, T2, T3, T4, T4> accumulator)
        where TC : 
            IScannable<TC>, 
            IApplicative<TC>
        where T1 : notnull
        where T2 : notnull
        where T3 : notnull
        where T4 : notnull
        => operand1
            .Zip(
                operand2, 
                operand3)
            .ScanRight(init,
                (t, x) =>
                    accumulator(
                        t.Item1,
                        t.Item2,
                        t.Item3,
                        x));
    
    public static ITypeConstructor<TC, T5> 
        ScanRight<TC, T1, T2, T3, T4, T5>(this 
            ITypeConstructor<TC, T1> operand1,
            ITypeConstructor<TC, T2> operand2,
            ITypeConstructor<TC, T3> operand3,
            ITypeConstructor<TC, T4> operand4,
            T5 init,
            Func<T1, T2, T3, T4, T5, T5> accumulator)
        where TC : 
            IScannable<TC>, 
            IApplicative<TC>
        where T1 : notnull
        where T2 : notnull
        where T3 : notnull
        where T4 : notnull
        where T5 : notnull
        => operand1
            .Zip(
                operand2, 
                operand3, 
                operand4)
            .ScanRight(init,
                (t, x) =>
                    accumulator(
                        t.Item1,
                        t.Item2,
                        t.Item3,
                        t.Item4,
                        x));

    public static ITypeConstructor<TC, T2> 
        ScanLeft<TC, T1, T2>(this 
            ITypeConstructor<TC, T1> operand,
            T2 init,
            Func<T2, T1, T2> accumulator)
        where TC : IScannable<TC>
        where T1 : notnull
        where T2 : notnull
        => ScanRight(
            operand,
            init,
            accumulator.Flip());
    
    public static ITypeConstructor<TC, T3> 
        ScanLeft<TC, T1, T2, T3>(this 
            ITypeConstructor<TC, T1> operand1,
            ITypeConstructor<TC, T2> operand2,
            T3 init,
            Func<T3, T1, T2, T3> accumulator)
        where TC : 
            IScannable<TC>,
            IApplicative<TC>
        where T1 : notnull
        where T2 : notnull
        where T3 : notnull
        => operand1
            .Zip(operand2)
            .ScanLeft(
                init,
                (x, t) => 
                    accumulator(
                        x, 
                        t.Item1, 
                        t.Item2));
    
    public static ITypeConstructor<TC, T4> 
        ScanLeft<TC, T1, T2, T3, T4>(this 
            ITypeConstructor<TC, T1> operand1,
            ITypeConstructor<TC, T2> operand2,
            ITypeConstructor<TC, T3> operand3,
            T4 init,
            Func<T4, T1, T2, T3, T4> accumulator)
        where TC : 
            IScannable<TC>,
            IApplicative<TC>
        where T1 : notnull
        where T2 : notnull
        where T3 : notnull
        where T4 : notnull
        => operand1
            .Zip(
                operand2,
                operand3)
            .ScanLeft(
                init,
                (x, t) => 
                    accumulator(
                        x, 
                        t.Item1, 
                        t.Item2,
                        t.Item3));
    
    public static ITypeConstructor<TC, T5> 
        ScanLeft<TC, T1, T2, T3, T4, T5>(this 
            ITypeConstructor<TC, T1> operand1,
            ITypeConstructor<TC, T2> operand2,
            ITypeConstructor<TC, T3> operand3,
            ITypeConstructor<TC, T4> operand4,
            T5 init,
            Func<T5, T1, T2, T3, T4, T5> accumulator)
        where TC : 
            IScannable<TC>,
            IApplicative<TC>
        where T1 : notnull
        where T2 : notnull
        where T3 : notnull
        where T4 : notnull
        where T5 : notnull
        => operand1
            .Zip(
                operand2,
                operand3,
                operand4)
            .ScanLeft(
                init,
                (x, t) => 
                    accumulator(
                        x, 
                        t.Item1, 
                        t.Item2,
                        t.Item3,
                        t.Item4));

    public static ITypeConstructor<TC, T> 
        Scan<TC, T>(this 
            ITypeConstructor<TC, T> operand)
        where TC : IScannable<TC>
        where T : IMonoid<T>
        => operand.ScanRight(
            T.Identity,
            T.Combine);

    public static ITypeConstructor<TC, TM> 
        ScanMap<TC, TM, T>(this 
            ITypeConstructor<TC, T> operand,
            Func<T, TM> accumulator)
        where TC : IScannable<TC>
        where TM : IMonoid<TM>
        where T : notnull
        => operand.ScanRight(
            TM.Identity,
            (t, m) =>
                TM.Combine(accumulator(t), m));

    public static ITypeConstructor<TC, bool> 
        Any<TC, T>(this 
            ITypeConstructor<TC, T> operand,
            Func<T, bool> predicate)
        where TC : IScannable<TC>
        where T : notnull
        => operand.ScanRight(
            false,
            (t, p) => p || predicate(t));
    
    public static ITypeConstructor<TC, bool> 
        All<TC, T>(this 
            ITypeConstructor<TC, T> operand,
            Func<T, bool> predicate)
        where TC : IScannable<TC>
        where T : notnull
        => operand.ScanRight(
            true,
            (t, p) => p && predicate(t));
    
    public static ITypeConstructor<TC, bool> 
        Contains<TC, T>(this 
            ITypeConstructor<TC, T> operand,
            T item)
        where TC : IScannable<TC>
        where T : notnull
        => operand
            .Any(t => t.Equals(item));
    
    public static ITypeConstructor<TC, bool> 
        And<TC>(this 
            ITypeConstructor<TC, bool> operand)
        where TC : IScannable<TC>
        => operand.ScanRight(
            true,
            (t, p) => p && t);
    
    public static ITypeConstructor<TC, bool> 
        Or<TC>(this 
            ITypeConstructor<TC, bool> operand)
        where TC : IScannable<TC>
        => operand.ScanRight(
            false,
            (t, p) => p || t);

    public static ITypeConstructor<TC, int> 
        Length<TC, T>(this 
            ITypeConstructor<TC, T> operand)
        where TC : IScannable<TC>
        where T : notnull
        => operand.ScanRight(
            0,
            (_, i) => i + 1);
    
    public static ITypeConstructor<TC, T> 
        Minimum<TC, T>(this 
            ITypeConstructor<TC, T> operand)
        where TC : IScannable<TC>
        where T : 
            IBottomable<T>, 
            IOrderable<T>
        => operand.ScanRight(
            T.Bottom,
            T.Minimum);

    public static ITypeConstructor<TC, T> 
        Maximum<TC, T>(this 
            ITypeConstructor<TC, T> operand)
        where TC : IScannable<TC>
        where T : 
            IToppable<T>, 
            IOrderable<T>
        => operand.ScanRight(
            T.Top,
            T.Maximum);

    public static ITypeConstructor<TC, T> 
        Sum<TC, T>(this 
            ITypeConstructor<TC, T> operand)
        where TC : IScannable<TC>
        where T : IAdditiveMonoid<T>
        => operand.ScanRight(
            T.Zero,
            Semigroup.Add);

    public static ITypeConstructor<TC, T> 
        Product<TC, T>(this 
            ITypeConstructor<TC, T> operand)
        where TC : IScannable<TC>
        where T : IMultiplicativeMonoid<T>
        => operand.ScanRight(
            T.One,
            Semigroup.Multiply);
}