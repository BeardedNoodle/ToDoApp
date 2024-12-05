using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiLayer.Services.Base
{
    public class ErrorResult
    {
        public string Message { get; }

        public ErrorType ErrorId { get; }

        public string Title { get; }

        private ErrorResult(string message, string title, ErrorType errorId)
        {
            Message = message;
            ErrorId = errorId;
            Title = title;
        }

        public static ErrorResult NotFound(string message, string title) => new ErrorResult(message, title, ErrorType.NotFound);

        public static ErrorResult Validation(string message, string title) => new ErrorResult(message, title, ErrorType.Validation);

        public static ErrorResult Conflict(string message, string title) => new ErrorResult(message, title, ErrorType.Conflict);

        public static ErrorResult UnAuthorized(string message, string title) => new ErrorResult(message, title, ErrorType.UnAuthorized);

        public static ErrorResult Forbidden(string message, string title) => new ErrorResult(message, title, ErrorType.Forbidden);

    }


    public enum ErrorType
    {
        NotFound = 0,
        Validation = 1,
        Conflict = 2,
        UnAuthorized = 3,
        Forbidden = 4
    }
}