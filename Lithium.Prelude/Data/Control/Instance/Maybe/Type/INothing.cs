namespace Lithium.Prelude.Data.Control.Instance.Maybe.Type;

public interface INothing<out T>
    : IMaybe<T>
    where T : notnull;