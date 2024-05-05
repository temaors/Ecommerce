namespace eCommerce.Extensions.ExceptionExtensions;

public class DbObjectIsNullException : BaseException
{
    public string MethodName { get; set; }
    public DbObjectIsNullException(string methodName, string message) 
        : base(message)
    {
        MethodName = methodName;
    }
}