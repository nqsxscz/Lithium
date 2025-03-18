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

public static class Foldable
{
    public static T2 FoldRight<TC, T1, T2>(this 
        ITypeConstructor<TC, T1> operand,
        T2 init,
        Func<T1, T2, T2> accumulator)
        where TC : IFoldable<TC>
        where T1 : notnull
        where T2 : notnull
        => TC.FoldRight(
            operand, 
            init, 
            accumulator);

    public static T2 FoldLeft<TC, T1, T2>(this 
        ITypeConstructor<TC, T1> operand,
        T2 init,
        Func<T2, T1, T2> accumulator)
        where TC : IFoldable<TC>
        where T1 : notnull
        where T2 : notnull
        => TC.FoldRight(
            operand,
            init,
            accumulator.Flip());

    public static T Fold<TC, T>(this 
        ITypeConstructor<TC, T> operand)
        where TC : IFoldable<TC>
        where T : IMonoid<T>
        => operand.FoldRight(
            T.Identity,
            T.Combine);

    public static TM FoldMap<TC, TM, T>(this 
        ITypeConstructor<TC, T> operand,
        Func<T, TM> selector)
        where TC : IFoldable<TC>
        where TM : IMonoid<TM>
        where T : notnull
        => operand.FoldRight(
            TM.Identity,
            (t, m) =>
                TM.Combine(selector(t), m));

    public static IEnumerable<T> Enumerate<TC, T>(this 
        ITypeConstructor<TC, T> operand)
        where TC : IFoldable<TC>
        where T : notnull
        => operand.FoldRight(
            Enumerable.Empty<T>(),
            (t, ts) => ts.Append(t));

    public static bool IsEmpty<TC, T>(this 
        ITypeConstructor<TC, T> operand)
        where TC : IFoldable<TC>
        where T : notnull
        => operand.FoldRight(
            true,
            (_, _) => false);

    public static bool IsNotEmpty<TC, T>(this 
        ITypeConstructor<TC, T> operand)
        where TC : IFoldable<TC>
        where T : notnull
        => !operand.IsEmpty();

    public static bool Any<TC, T>(this 
        ITypeConstructor<TC, T> operand,
        Func<T, bool> predicate)
        where TC : IFoldable<TC>
        where T : notnull
        => operand.FoldRight(
            false,
            (t, p) => p || predicate(t));
    
    public static bool All<TC, T>(this 
        ITypeConstructor<TC, T> operand,
        Func<T, bool> predicate)
        where TC : IFoldable<TC>
        where T : notnull
        => operand.FoldRight(
            true,
            (t, p) => p && predicate(t));

    public static bool Contains<TC, T>(this 
        ITypeConstructor<TC, T> operand,
        T item)
        where TC : IFoldable<TC>
        where T : notnull
        => operand
            .Any(t => t.Equals(item));
    
    public static bool And<TC>(this 
        ITypeConstructor<TC, bool> operand)
        where TC : IFoldable<TC>
        => operand.FoldRight(
            true,
            (t, p) => p && t);
    
    public static bool Or<TC>(this 
        ITypeConstructor<TC, bool> operand)
        where TC : IFoldable<TC>
        => operand.FoldRight(
            false,
            (t, p) => p || t);
    
    public static int Length<TC, T>(this 
        ITypeConstructor<TC, T> operand)
        where TC : IFoldable<TC>
        where T : notnull
        => operand.FoldRight(
            0,
            (_, i) => i + 1);

    public static T Minimum<TC, T>(this 
        ITypeConstructor<TC, T> operand)
        where TC : IFoldable<TC>
        where T : 
            IBottomable<T>, 
            IOrderable<T>
        => operand.FoldRight(
            T.Bottom,
            T.Minimum);

    public static T Maximum<TC, T>(this 
        ITypeConstructor<TC, T> operand)
        where TC : IFoldable<TC>
        where T : 
            IToppable<T>, 
            IOrderable<T>
        => operand.FoldRight(
            T.Top,
            T.Maximum);

    public static T Sum<TC, T>(this 
        ITypeConstructor<TC, T> operand)
        where TC : IFoldable<TC>
        where T : IAdditiveMonoid<T>
        => operand.FoldRight(
            T.Zero,
            Semigroup.Add);

    public static T Product<TC, T>(this 
        ITypeConstructor<TC, T> operand)
        where TC : IFoldable<TC>
        where T : IMultiplicativeMonoid<T>
        => operand.FoldRight(
            T.One,
            Semigroup.Multiply);
}