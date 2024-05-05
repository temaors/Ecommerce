namespace eCommerce.Extensions.ExceptionExtensions;

public class InvalidArgumentException : BaseException
{
    public string MethodName { get; set; }
    
    public InvalidArgumentException(string methodName, string message) : base(message)
    {
        MethodName = methodName;
    }
}