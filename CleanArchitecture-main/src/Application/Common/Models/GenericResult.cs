using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Application.Common.Models;
public class Result<T> : Result where T : class
{
    internal Result(bool succeeded, IEnumerable<string> errors, T? value) : base(succeeded, errors)
    {
        Value = value;
    }

    public T? Value { get; set; }

    public static Result<T> Success(T value)
    {
        return new Result<T>(true, Array.Empty<string>(), value);
    }

    public static Result<T> Failure(IEnumerable<string> errors, T? value)
    {
        return new Result<T>(false, errors, value);
    }
}
