namespace Fathy.Startup;

public class Response
{
    public bool Succeeded { get; }
    public IEnumerable<Error>? Errors { get; }
    
    public Response(bool succeeded, IEnumerable<Error>? errors)
    {
        Succeeded = succeeded;
        Errors = errors;
    }
}

public class Response<T> : Response
{
    public T? Data { get; }
    
    public Response(bool succeeded, T? data, IEnumerable<Error>? errors) : base(succeeded, errors)
    {
        Data = data;
    }
}

public static class ResponseFactory
{
    public static Response Ok() => new(true, default);
    public static Response<T> Ok<T>(T? data = default) => new(true, data, default);
    
    public static Response Fail(Error error) => new(false, new[] {error});
    public static Response<T> Fail<T>(Error error, T? data = default) => new(false, data, new[] {error});
    public static Response<T> Fail<T>(IEnumerable<Error>? errors = default, T? data = default) => new(false, data, errors);
}