using Lithium.Prelude.Numeric.Trait;

namespace Lithium.Prelude.Data.Numeric.Instance;

#pragma warning disable CS8981
// ReSharper disable once InconsistentNaming
public readonly record struct natural(ulong Value)
    : INatural<natural>
{
    public static implicit operator natural(ulong n) 
        => Of(n);
    
    public static natural Of(ulong n)
        => new(n);
    
    public static natural Zero
        => 0;
    
    public static natural One
        => 1;
    
    public static natural operator +(natural left, natural right)
        => left.Value + right.Value;

    public static natural operator *(natural left, natural right)
        => left.Value * right.Value;
    
    public static bool operator <(natural left, natural right)
        => left.Value < right.Value;

    public static bool operator >(natural left, natural right)
        => right < left;
}