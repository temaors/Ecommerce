namespace eCommerce.Extensions.ExceptionExtensions;

public static class ExceptionsFactory
{
    public static DbObjectIsNullException DbObjectIsNullException(string methodName, string message) =>
        new DbObjectIsNullException(methodName, message);
    
    public static Exception InvArgException(string methodName, string message) =>
        new InvalidArgumentException(methodName, message);
    
}