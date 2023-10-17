using System.Text.RegularExpressions;
using eCommerce.APIObjects;

namespace eCommerce.Validators
{
    public class CredentialsValidator<T> : BaseValidator<T>
    {
        private static readonly Regex PasswordRegex = new("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d).{8,}$");
        
        public bool IsValid(Credentials credentials)
        {
            if (!EnsureNotNull(credentials)) return false;
            return ValidateLogin(credentials.Email) && ValidatePassword(credentials.Password);
        }

        private bool EnsureNotNull(Credentials credentials) => 
            !string.IsNullOrWhiteSpace(credentials.Email) &&
            !string.IsNullOrWhiteSpace(credentials.Password);
        
        private bool ValidatePassword(string password) =>
            PasswordRegex.IsMatch(password);

        private bool ValidateLogin(string email)
        {
            if (!string.IsNullOrEmpty(email))
            {
                return true;
            }

            return false;
        }
    }
}