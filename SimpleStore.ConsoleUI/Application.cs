using SimpleStore.ConsoleUI.MenuFrame;
using SimpleStore.ConsoleUI.MenuFrame.Menus;
using SimpleStore.ConsoleUI.MenusAction;
using SimpleStore.Domain.Products.Categories;
using SimpleStore.Domain.Services.ProductsServices;
using SimpleStore.Domain.UsersAccounts.AccountsLogic;
using SimpleStore.Domain.UsersAuthenticator.Authenticator.UserLogin;
using SimpleStore.Domain.UsersAuthenticator.Authenticator.UserRegistration;
using SimpleStore.Domain.UsersAuthenticator.Users;
using System.Collections.Generic;

namespace SimpleStore.ConsoleUI
{
    public class Application
    {
        private IUserLogger _userLogger;
        private IUserRegistrator _userRegistrator;
        private ICategoryService _categoryService;
        private IProductsService _productService;
        private AccountsLogic _accountsLogic;

        public Application(IUserLogger userLogger, IUserRegistrator userRegistrator, ICategoryService categoryService, 
            IProductsService productService, AccountsLogic accountsLogic)
        {
            _userLogger = userLogger;
            _userRegistrator = userRegistrator;
            _categoryService = categoryService;
            _productService = productService;
            _accountsLogic = accountsLogic;
        }

        public void RunApp()
        {
            var initialMenu = new NavigatorMenu("Initial Menu", null);
            var loginMenu = new ActionMenu("Login Menu", initialMenu);
            var registerMenu = new ActionMenu("Register Menu", initialMenu);
            var mainMenu = new NavigatorActionMenu("Main Menu", loginMenu);
            var accountMenu = new NavigatorMenu("Account Menu", mainMenu);
            var makeDepositMenu = new ActionMenu("Make Deposit Menu", accountMenu);
            var makeWithdrawalMenu = new ActionMenu("Make Withdrawal Menu", accountMenu);
            var storeCategoriesMenu = new NavigatorMenu("Store Categories Menu", mainMenu);
            var storeProductsMenu = new ActionMenu("Store Products Menu", mainMenu);

            initialMenu.AddChildMenu(loginMenu);
            initialMenu.AddChildMenu(registerMenu);

            loginMenu.AddTextBox("Username");
            loginMenu.AddTextBox("Password");
            loginMenu.SetRenavigateMenu(mainMenu);
            loginMenu.Func = new LoginLogic(_userLogger).Login;

            registerMenu.AddTextBox("First Name");
            registerMenu.AddTextBox("Last Name");
            registerMenu.AddTextBox("Username");
            registerMenu.AddTextBox("Password");
            registerMenu.AddTextBox("Confirm Password");
            registerMenu.SetRenavigateMenu(initialMenu);
            registerMenu.Func = new RegistrationLogic(_userRegistrator, new UserModel()).Register;

            mainMenu.AddChildMenu(accountMenu);
            mainMenu.AddChildMenu(storeCategoriesMenu);
            mainMenu.Action = new AccountInfoLogic(_accountsLogic).PrintAccountInfoLogic;
            //mainMenu.AddTextBlock($"{ UserLogger.CurrentAccount.User.FirstName } your balance is { UserLogger.CurrentAccount.Balance }$");

            accountMenu.AddChildMenu(makeDepositMenu);
            accountMenu.AddChildMenu(makeWithdrawalMenu);

            makeDepositMenu.AddTextBox("Deposit Amount");
            makeDepositMenu.SetRenavigateMenu(accountMenu);
            makeDepositMenu.Func = new MakeDepositLogic(_accountsLogic).MakeDeposit;

            makeWithdrawalMenu.AddTextBox("Withdrawal Amount");
            makeWithdrawalMenu.SetRenavigateMenu(accountMenu);
            makeWithdrawalMenu.Func = new MakeWithdrawalLogic(_accountsLogic).MakeWithdrawal;

            List<CategoryModel> categories = _categoryService.GetCategories();
            foreach (var category in categories)
            {
                ActionMenu productMenu = new ActionMenu($"{category.CategoryName} Menu", storeCategoriesMenu);
                productMenu.Func = new BuyProductLogic(_accountsLogic, category, _productService).BuyProduct;
                
                storeCategoriesMenu.AddChildMenu(productMenu);

                productMenu.AddTextBlock("Select Product");
                productMenu.Func = new BuyProductLogic(_accountsLogic, category, _productService).BuyProduct;
            }

            initialMenu.Run();
        }
    }
}
