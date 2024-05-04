namespace eCommerce.APIObjects
{
    public class ApiCredentials
    {
        public ApiCredentials(string email, string password, string repeatedPassword)
        {
            Email = email;
            Password = password;
            RepeatedPassword = repeatedPassword;
        }

        public string Email { get; set; }
        public string Password { get; set; }
        public string RepeatedPassword { get; set; }
    }
}