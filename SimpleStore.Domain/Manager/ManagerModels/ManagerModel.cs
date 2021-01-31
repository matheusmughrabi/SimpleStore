using SimpleStore.Domain.UsersAuthenticator.Users;

namespace SimpleStore.Domain.Manager.ManagerModels
{
    public class ManagerModel
    {
        public int Id { get; set; }
        public AccountOwner User { get; set; }
        public ManagerPermissionModel ManagerPermission { get; set; }

        public ManagerModel()
        {

        }
        public ManagerModel(AccountOwner user)
        {
            User = user;
        }
    }
}
