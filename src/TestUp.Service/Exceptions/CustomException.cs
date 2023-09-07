namespace TestUp.Service.Exceptions;

public class CustomException : Exception
{
    public CustomException(int statusCode, string message) : base(message)
    {
        this.StatusCode = statusCode;
    }
    
    public int StatusCode { get; set; }
}