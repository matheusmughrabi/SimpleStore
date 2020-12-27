using SimpleStore.Domain.UsersAuthenticator.Users;

namespace SimpleStore.Domain.Manager.ManagerModels
{
    public class ManagerModel
    {
        public int Id { get; set; }
        public UserModel User { get; set; }
        public ManagerPermissionModel ManagerPermission { get; set; }

        public ManagerModel()
        {

        }
        public ManagerModel(UserModel user)
        {
            User = user;
        }
    }
}
