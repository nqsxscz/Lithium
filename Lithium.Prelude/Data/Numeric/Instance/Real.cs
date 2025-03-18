using Lithium.Prelude.Numeric.Trait;

namespace Lithium.Prelude.Data.Numeric.Instance;

#pragma warning disable CS8981
// ReSharper disable once InconsistentNaming
public readonly record struct real(double Value)
    : IReal<real>
{
    public static implicit operator real(double x) 
        => Of(x);
    
    public static real Of(double x)
        => new(x);
    
    public static real Zero
        => 0;

    public static real One
        => 1;
    
    public static real Pi
        => double.Pi;

    public static real E
        => double.E;
    
    public static real Invert(real operand)
        => 1/operand.Value;

    public static real operator ^(real left, real right)
        => double.Pow(left.Value, right.Value);
    
    public static real Sqrt(real operand)
        => double.Sqrt(operand.Value);

    public static real Log(real operand)
        => double.Log(operand.Value);

    public static real Exp(real operand)
        => double.Exp(operand.Value);

    public static real Sin(real operand)
        => double.Sin(operand.Value);

    public static real Cos(real operand)
        => double.Cos(operand.Value);

    public static real Tan(real operand)
        => double.Tan(operand.Value);

    public static real Asin(real operand)
        => double.Asin(operand.Value);

    public static real Acos(real operand)
        => double.Acos(operand.Value);

    public static real Atan(real operand)
        => double.Atan(operand.Value);
    
    public static real operator -(real operand)
        => -operand.Value;
    
    public static real operator +(real left, real right)
        => left.Value + right.Value;

    public static real operator *(real left, real right)
        => left.Value * right.Value;
    
    public static bool operator <(real left, real right)
        => left.Value < right.Value;

    public static bool operator >(real left, real right)
        => right < left;
}