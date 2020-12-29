using SimpleStore.Domain.Manager.ManagerLogin;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleStore.ConsoleUI.MenusLogic.AccessPermissions
{
    public class AccessValidator
    {
        public bool InvalidateAccess()
        {
            return false;
        }

        public bool AllowSuperAdminOnly()
        {
            if (ManagerLogger.CurrentManager.ManagerPermission.PermissionTitle == "Super Admin")
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
