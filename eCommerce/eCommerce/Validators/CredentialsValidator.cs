using System.Text.RegularExpressions;
using eCommerce.APIObjects;

namespace eCommerce.Validators
{
    public class CredentialsValidator<T> : BaseValidator<T>
    {
        private readonly Regex _passwordRegex = new("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d).{8,}$");
        private readonly Regex _emailRegex = new("^[^@\\s]+@[^@\\s]+\\.[^@\\s]+$");
        public bool IsValid(APICredentials apiCredentials)
        {
            if (!EnsureNotNull(apiCredentials)) return false;
            return ValidateLogin(apiCredentials.Email) && ValidatePassword(apiCredentials.Password);
        }

        private bool EnsureNotNull(APICredentials apiCredentials) => 
            !string.IsNullOrWhiteSpace(apiCredentials.Email) &&
            !string.IsNullOrWhiteSpace(apiCredentials.Password);
        
        private bool ValidatePassword(string password) =>
            _passwordRegex.IsMatch(password);

        private bool ValidateLogin(string email) =>
            _emailRegex.IsMatch(email);
    }
}