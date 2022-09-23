namespace CafeSimpleManagementSystem.Wrappers;

public class Response<T>
{
    public Response() { }
    public Response(T data)
    {
        Success = true;
        Message = String.Empty;
        Data = data;
    }

    public T? Data { get; set; }
    public bool Success { get; set; }
    public string? Message { get; set; }
}