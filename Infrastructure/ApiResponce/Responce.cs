using System.Net;

namespace Infrastructure.ApiResponce;

public class Responce<T>
{
    public Responce(T data)
    {
        Data = data;
        StatusCode = 200;
        Message = string.Empty;
    }

    public Responce(HttpStatusCode statusCode, string message)
    {
        Data = default;
        StatusCode = (int)statusCode;
        Message = message;
    }
    
    public int StatusCode { get; set; }
    public T Data { get; set; }
    public string Message { get; set; }
}