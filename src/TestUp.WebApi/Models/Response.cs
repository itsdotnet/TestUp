namespace TestUp.WebApi.Models;

public class Response
{
    #pragma warning disable CS8618
    
    public int StatusCode { get; set; }
    public string Message { get; set; }
    public object Data { get; set; }
}