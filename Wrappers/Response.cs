namespace CafeSimpleManagementSystem.Wrappers;

public class Response<T>
{
    public Response() { }
    public Response(T data)
    {
        Status = 200;
        Message = String.Empty;
        Data = data;
    }
    public int Status { get; set; }
    public string? Message { get; set; }
    public T? Data { get; set; }
}