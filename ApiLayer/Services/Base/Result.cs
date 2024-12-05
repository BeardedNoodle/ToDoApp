using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace ApiLayer.Services.Base;

public interface IResult
{
    public bool IsSuccess { get; }

}
public class Result<T> : IResult
{
    public bool IsSuccess { get; }
    public T? Data { get; }
    public ErrorResult? Error { get; }

    private Result(T? value)
    {
        Data = value;
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

