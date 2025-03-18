// ReSharper disable UnusedTypeParameter
namespace Lithium.Prelude.Kind;

public interface ITypeConstructor<TC, out T>
    where TC : notnull
    where T : notnull;