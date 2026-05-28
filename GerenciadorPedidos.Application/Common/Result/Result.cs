namespace GerenciadorPedidos.Application.Common.Result;

public class Result
{
    public Result(bool isSuccess = true, string message = "")
    {
        IsSuccess = isSuccess;
        Message = message;
    }
    public bool IsSuccess { get; set; }
    public string? Message { get; set; }
    public static Result Success => new ();
    
    public static Result Failure(string message) => new Result (false, message);
}

public class Result<T> : Result
{
    public Result(T? data, bool isSuccess = true, string message = "") : base(isSuccess, message)
    {
        Data = data;
    }
    public T? Data { get; set; }
    public static Result<T> Success(T data) => new (data);
    public static Result<T> Failure(string message) => new (default,false,message);

}