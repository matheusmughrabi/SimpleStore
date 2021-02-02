using SimpleStore.DataAccess.Data.Repository.IRepository;
using SimpleStore.Domain.Manager.ManagerLogin;
using SimpleStore.Models.Models;
using System;
using System.Collections.Generic;

namespace SimpleStore.Domain.Manager.ManagerOperations
{
    public class ManagerCategoryCreator : ICategoryOperator
    {
        private readonly IUnityOfWork _unityOfWork;
        private IEnumerable<Category> _registeredCategories;

        public ManagerCategoryCreator(IUnityOfWork unityOfWork)
        {
            _unityOfWork = unityOfWork;
        }

        public bool InsertCategory(Category category)
        {
            if (ManagerLogger.CurrentManager.Role.RoleTitle != "Super Admin")
            {
                throw new Exception("Only Super Admin is allowed");
            }

            _registeredCategories = _unityOfWork.Category.GetAll();

            foreach (var registeredCategory in _registeredCategories)
            {
                if (registeredCategory.Name == category.Name)
                {
                    return false;
                }
                if (string.IsNullOrEmpty(category.Name))
                {
                    return false;
                }
            }

            _unityOfWork.Category.Add(category);
            _unityOfWork.Save();

            return true;
        }

        public bool DeleteCategory(string name)
        {
            if (ManagerLogger.CurrentManager.Role.RoleTitle != "Super Admin")
            {
                throw new Exception("Only Super Admin is allowed");
            }

            Category category = _unityOfWork.Category.GetFirstOrDefault(c => c.Name == name);

            if (category == null)
            {
                return false;
            }

            if (category.Id == 0)
            {
                return false;
            }

            _unityOfWork.Category.Remove(category);
            _unityOfWork.Save();

            return true;
        }
    }
}
