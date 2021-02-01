using SimpleStore.Domain.Manager.ManagerLogin;

namespace SimpleStore.ConsoleUI.MenusLogic.AccessPermissions
{
    public class AccessValidatorLogic
    {
        public bool InvalidateAccess()
        {
            return false;
        }

        public bool AllowSuperAdminOnly()
        {
            if (ManagerLogger.CurrentManager.Role.PermissionTitle == "Super Admin")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
