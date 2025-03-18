namespace Lithium.Prelude.Algebra.Trait.Poset;

public interface IOrderable<T>
    where T : IOrderable<T>
{
    static abstract bool operator <(T left, T right);

    static virtual bool operator <=(T left, T right)
        => left < right || left == right;

    static virtual bool operator >(T left, T right)
        => right < left;
    
    static virtual bool operator >=(T left, T right)
        => right <= left;

    static virtual bool operator ==(T left, T right)
        => left.Equals(right);
    
    static virtual bool operator !=(T left, T right)
        => !(left == right);
    
    static virtual T Minimum(T left, T right)
        => left < right ? left : right;
    
    static virtual T Maximum(T left, T right)
        => left >= right ? left : right;
}