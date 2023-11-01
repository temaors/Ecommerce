using Microsoft.Extensions.Options;

namespace eCommerce.Validators;

public class BaseValidator<T>
{
    protected void DoValidate(T obj)
    { }  

    public bool EnsureNotNull(string? str) =>
        !string.IsNullOrWhiteSpace(str);
}