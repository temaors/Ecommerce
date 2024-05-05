namespace eCommerce.Extensions.ExceptionExtensions;

public abstract class BaseException : Exception
{
    public BaseException(string message) : base(message)
    {
    }
}