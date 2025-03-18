using Lithium.Prelude.Numeric.Trait;

namespace Lithium.Prelude.Data.Numeric.Instance;

#pragma warning disable CS8981
// ReSharper disable once InconsistentNaming
public readonly record struct integer(long Value)
    : IInteger<integer>
{
    public static implicit operator integer(long n) 
        => Of(n);
    
    public static integer Of(long n)
        => new(n);
    
    public static integer Zero
        => 0;
    
    public static integer One
        => 1;
    
    public static integer operator -(integer operand)
        => -operand.Value;
    
    public static integer operator +(integer left, integer right)
        => left.Value + right.Value;

    public static integer operator *(integer left, integer right)
        => left.Value * right.Value;
    
    public static bool operator <(integer left, integer right)
        => left.Value < right.Value;

    public static bool operator >(integer left, integer right)
        => right < left;
}