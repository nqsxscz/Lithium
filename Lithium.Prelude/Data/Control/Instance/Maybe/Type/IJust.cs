namespace Lithium.Prelude.Data.Control.Instance.Maybe.Type;

public interface IJust<out T>
    : IMaybe<T>
    where T : notnull
{
    T Value { get; }
}