using SimpleStore.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleStore.Models.Factories
{
    public static class ModelsFactory
    {
        public static Account CreateAccountInstance()
        {
            return new Account();
        }

        public static AccountOwner CreateAccountOwnerInstance()
        {
            return new AccountOwner();
        }

        public static Category CreateCategoryInstance()
        {
            return new Category();
        }

        public static Product CreateProductInstance()
        {
            return new Product();
        }

        public static Roles CreateRolesInstance()
        {
            return new Roles();
        }
    }
}
