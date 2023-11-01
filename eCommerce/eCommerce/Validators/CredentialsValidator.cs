using System.Text.RegularExpressions;
using eCommerce.APIObjects;

namespace eCommerce.Validators
{
    public class CredentialsValidator<T> : BaseValidator<T>
    {
        private readonly Regex _passwordRegex = new("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d).{8,}$");
        private readonly Regex _emailRegex = new("^[^@\\s]+@[^@\\s]+\\.[^@\\s]+$");
        public bool IsValid(Credentials credentials)
        {
            if (!EnsureNotNull(credentials)) return false;
            return ValidateLogin(credentials.Email) && ValidatePassword(credentials.Password);
        }

        private bool EnsureNotNull(Credentials credentials) => 
            !string.IsNullOrWhiteSpace(credentials.Email) &&
            !string.IsNullOrWhiteSpace(credentials.Password);
        
        private bool ValidatePassword(string password) =>
            _passwordRegex.IsMatch(password);

        private bool ValidateLogin(string email) =>
            _emailRegex.IsMatch(email);
    }
}