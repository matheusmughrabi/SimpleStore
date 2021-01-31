namespace SimpleStore.Domain.UsersAuthenticator.Users
{
    public class AccountOwner
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }

        public string FullName
        {
            get { return $"{ FirstName } { LastName }"; }
        }

    }
}
