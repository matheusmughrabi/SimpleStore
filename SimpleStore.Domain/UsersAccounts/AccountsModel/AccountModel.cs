using SimpleStore.Domain.UsersAuthenticator.Users;

namespace SimpleStore.Domain.UsersAccounts.AccountsModel
{
    public class AccountModel
    {
        public int Id { get; set; }
        public UserModel User { get; set; }
        public decimal Balance { get; set; }

        public AccountModel()
        {

        }

        public AccountModel(UserModel user)
        {
            User = user;
        }
    }
}
