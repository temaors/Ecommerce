namespace eCommerce.APIObjects
{
    public class ApiCredentials
    {
        public ApiCredentials(){}
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

    public class SignUpCredentials : ApiCredentials
    {
        public SignUpCredentials(){}
        public SignUpCredentials(string firstName, string email, string password, string repeatedPassword) :
            base(email, password, repeatedPassword)
        {
            FirstName = firstName;
        }

        public string FirstName { get; set; }
    }
}