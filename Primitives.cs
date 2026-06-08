namespace Revyne.Engine.Api;

/// <summary>Unit type — the absence of a meaningful return value.</summary>
public readonly struct Unit
{
    public static readonly Unit Value = new();
}

/// <summary>
/// Functional result. Mirrors the convention used across Revyne services so the
/// engine speaks the same shape without depending on any service assembly.
/// </summary>
public class Result<V, E> where E : struct, Enum
{
    public bool IsSuccess { get; }
    public bool IsFailure => !IsSuccess;

    public V? Value { get; }
    public E? Error { get; }

    private Result(bool isSuccess, V? value, E? error)
    {
        IsSuccess = isSuccess;
        Value = value;
        Error = error;
    }

    public static Result<V, E> Success(V value) => new(true, value, null);
    public static Result<V, E> Failure(E error) => new(false, default, error);

    public static implicit operator Result<V, E>(V value) => Success(value);
    public static implicit operator Result<V, E>(E error) => Failure(error);
}
