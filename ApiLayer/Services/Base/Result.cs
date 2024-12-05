using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiLayer.Services.Base;
public class Result<T>
{
    public bool IsSuccess { get; }
    public T? Value { get; }
    public ErrorResult? Error { get; }

    private Result(T? value)
    {
        Value = value;
        IsSuccess = true;
    }

    private Result(ErrorResult error)
    {
        IsSuccess = false;
        Error = error;
    }

    public static Result<T> Success(T? value) => new Result<T>(value);
    public static Result<T> Failure(ErrorResult error) => new Result<T>(error);
}
