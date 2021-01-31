using SimpleStore.ConsoleUI.MenuFrame;
using SimpleStore.ConsoleUI.MenuFrame.Menus;
using SimpleStore.ConsoleUI.MenusAction;
using SimpleStore.ConsoleUI.MenusLogic;
using SimpleStore.ConsoleUI.MenusLogic.AccessPermissions;
using SimpleStore.Domain.Accounts.Interfaces;
using SimpleStore.Domain.Manager.ManagerLogin;
using SimpleStore.Domain.Manager.ManagerOperations;
using SimpleStore.Domain.Manager.ManagerOperations.Interfaces;
using SimpleStore.Domain.Products.Interfaces;
using SimpleStore.Domain.Products.ProductsLogic;
using SimpleStore.Domain.UsersAuthenticator.Authenticator.UserLogin;
using SimpleStore.Domain.UsersAuthenticator.Authenticator.UserRegistration;
using SimpleStore.Models.Models;
using System.Collections.Generic;

namespace SimpleStore.ConsoleUI
{
    public class Application
    {
        private readonly IUserLogger _userLogger;
        private readonly IManagerLogger _managerLogger;
        private readonly IUserRegistrator _userRegistrator;
        private readonly IProductsLogic _productsLogic;
        private readonly IAccountsLogic _accountsLogic;
        private readonly ICategoryOperator _categoryOperator;
        private readonly IProductsOperator _productsOperator;
        private readonly IManagerCreator _managerCreator;
        private readonly IRegisteredUsersInfo _registeredUsersInfo;

        public Application(IUserLogger userLogger, IManagerLogger managerLogger, IUserRegistrator userRegistrator, IProductsLogic productsLogic, IAccountsLogic accountsLogic, ICategoryOperator categoryOperator, IProductsOperator productsOperator, IManagerCreator managerCreator, IRegisteredUsersInfo registeredUsersInfo)
        {
            _userLogger = userLogger;
            _managerLogger = managerLogger;
            _userRegistrator = userRegistrator;
            _productsLogic = productsLogic;
            _accountsLogic = accountsLogic;
            _categoryOperator = categoryOperator;
            _productsOperator = productsOperator;
            _managerCreator = managerCreator;
            _registeredUsersInfo = registeredUsersInfo;
        }

        public void RunApp()
        {
            var initialMenu = new MasterNavigatorMenu("Initial Menu", null);
            var loginMenu = new SimpleActionMenu("Login Menu", initialMenu);
            var managerLoginMenu = new SimpleActionMenu("Manager Login Menu", initialMenu);
            var registerMenu = new SimpleActionMenu("Register Menu", initialMenu);
            var mainMenu = new MasterNavigatorMenu("Main Menu", initialMenu);
            var managerMainMenu = new MasterNavigatorMenu("Manager Main Menu", initialMenu);
            var managerCreateManagerMenu = new SimpleActionMenu("Create Manager Menu", managerMainMenu);
            var managerRegisteredUsersMenu = new SimpleActionMenu("Registered Users Menu", managerMainMenu);
            var managerAddCategoryMenu = new SimpleActionMenu("Add Category Menu", managerMainMenu);
            var managerDeleteCategoryMenu = new SimpleActionMenu("Delete Category Menu", managerMainMenu);
            var managerAddProductMenu = new SimpleActionMenu("Add Product Menu", managerMainMenu);
            var managerDeleteProductMenu = new SimpleActionMenu("Delete Product Menu", managerMainMenu);
            var managerBuyProductMenu = new SimpleActionMenu("Buy Product Menu", managerMainMenu);
            var accountMenu = new MasterNavigatorMenu("Account Menu", mainMenu);
            var makeDepositMenu = new SimpleActionMenu("Make Deposit Menu", accountMenu);
            var makeWithdrawalMenu = new SimpleActionMenu("Make Withdrawal Menu", accountMenu);
            var storeCategoriesMenu = new MasterNavigatorMenu("Store Categories Menu", mainMenu);

            initialMenu.AddChildMenu(loginMenu);
            initialMenu.AddChildMenu(managerLoginMenu);
            initialMenu.AddChildMenu(registerMenu);
            initialMenu.SetReturnOption("0 - Exit");

            loginMenu.AddTextBox("Username");
            loginMenu.AddTextBox("Password");
            loginMenu.SetRenavigateMenu(mainMenu);
            loginMenu.MenuFuncLogic = new LoginLogic(_userLogger).Login;

            managerLoginMenu.AddTextBox("Username");
            managerLoginMenu.AddTextBox("Password");
            managerLoginMenu.SetRenavigateMenu(managerMainMenu);
            managerLoginMenu.MenuFuncLogic = new ManagerLoginLogic(_managerLogger).Login;

            registerMenu.AddTextBox("First Name");
            registerMenu.AddTextBox("Last Name");
            registerMenu.AddTextBox("Email");
            registerMenu.AddTextBox("Username");
            registerMenu.AddTextBox("Password");
            registerMenu.AddTextBox("Confirm Password");
            registerMenu.SetRenavigateMenu(initialMenu);
            registerMenu.MenuFuncLogic = new RegistrationLogic(_userRegistrator, new AccountOwner()).Register;

            mainMenu.AddChildMenu(accountMenu);
            mainMenu.AddChildMenu(storeCategoriesMenu);
            mainMenu.SetReturnOption("0 - Logout");
            mainMenu.ReturnMenuAction = new LoginLogic(_userLogger).Logout;
            mainMenu.MenuActionLogic = new AccountInfoLogic(_accountsLogic).PrintAccountInfoLogic;

            managerMainMenu.AddTextBlock("Welcome Manager");
            managerMainMenu.AddChildMenu(managerAddCategoryMenu);
            managerMainMenu.AddChildMenu(managerDeleteCategoryMenu);
            managerMainMenu.AddChildMenu(managerAddProductMenu);
            managerMainMenu.AddChildMenu(managerDeleteProductMenu);
            managerMainMenu.AddChildMenu(managerBuyProductMenu);
            managerMainMenu.AddChildMenu(managerCreateManagerMenu);
            managerMainMenu.AddChildMenu(managerRegisteredUsersMenu);
            managerMainMenu.SetReturnOption("0 - Logout");
            managerMainMenu.ReturnMenuAction = new ManagerLoginLogic(_managerLogger).Logout;

            managerCreateManagerMenu.AddTextBox("Manager username");
            managerCreateManagerMenu.AddTextBox("Manager permission (Super Admin or Admin)");
            managerCreateManagerMenu.AccessAllowedFunc = new AccessValidatorLogic().AllowSuperAdminOnly;
            managerCreateManagerMenu.MenuFuncLogic = new ManagerCreatorLogic(_managerCreator).CreateManager;

            managerRegisteredUsersMenu.MenuFuncLogic = new RegisteredUsersLogic(_registeredUsersInfo).DisplayRegisteredUsers;

            managerAddCategoryMenu.AddTextBox("Category Name");
            managerAddCategoryMenu.AccessAllowedFunc = new AccessValidatorLogic().AllowSuperAdminOnly;
            managerAddCategoryMenu.MenuFuncLogic = new ManagerLogic(_categoryOperator, _productsOperator).InsertCategory;

            managerDeleteCategoryMenu.AddTextBox("Category");
            managerDeleteCategoryMenu.AccessAllowedFunc = new AccessValidatorLogic().AllowSuperAdminOnly;
            managerDeleteCategoryMenu.MenuFuncLogic = new ManagerLogic(_categoryOperator, _productsOperator).DeleteCategory;

            managerAddProductMenu.AddTextBox("Name");
            managerAddProductMenu.AddTextBox("Brand");
            managerAddProductMenu.AddTextBox("Category");
            managerAddProductMenu.AddTextBox("Regular Price");
            managerAddProductMenu.AddTextBox("Discounted Price");
            managerAddProductMenu.AddTextBox("Description");
            managerAddProductMenu.MenuFuncLogic = new ManagerLogic(_categoryOperator, _productsOperator).InsertProduct;

            managerDeleteProductMenu.AddTextBox("Name");
            managerDeleteProductMenu.AccessAllowedFunc = new AccessValidatorLogic().AllowSuperAdminOnly;
            managerDeleteProductMenu.MenuFuncLogic = new ManagerLogic(_categoryOperator, _productsOperator).DeleteProduct;

            managerBuyProductMenu.AddTextBox("Name");
            managerBuyProductMenu.AddTextBox("Amount");
            managerBuyProductMenu.MenuFuncLogic = new ManagerLogic(_categoryOperator, _productsOperator).BuyProduct;

            accountMenu.AddChildMenu(makeDepositMenu);
            accountMenu.AddChildMenu(makeWithdrawalMenu);

            makeDepositMenu.AddTextBox("Deposit Amount");
            makeDepositMenu.SetRenavigateMenu(accountMenu);
            makeDepositMenu.MenuFuncLogic = new MakeDepositLogic(_accountsLogic).MakeDeposit;

            makeWithdrawalMenu.AddTextBox("Withdrawal Amount");
            makeWithdrawalMenu.SetRenavigateMenu(accountMenu);
            makeWithdrawalMenu.MenuFuncLogic = new MakeWithdrawalLogic(_accountsLogic).MakeWithdrawal;

            List<Category> categories = _productsLogic.GetCategories();
            foreach (var category in categories)
            {
                SimpleActionMenu productMenu = new SimpleActionMenu($"{category.Name} Menu", storeCategoriesMenu);
                productMenu.MenuFuncLogic = new BuyProductLogic(_accountsLogic, category, _productsLogic).BuyProduct;
                storeCategoriesMenu.AddChildMenu(productMenu);
            }

            initialMenu.Run();
        }
    }
}
