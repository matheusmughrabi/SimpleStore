using SimpleStore.ConsoleUI.MenuFrame;
using SimpleStore.ConsoleUI.MenuFrame.Menus;
using SimpleStore.ConsoleUI.MenusAction;
using SimpleStore.ConsoleUI.MenusLogic;
using SimpleStore.Domain.Manager.ManagerLogin;
using SimpleStore.Domain.Manager.ManagerOperations;
using SimpleStore.Domain.Manager.ManagerOperations.Interfaces;
using SimpleStore.Domain.Products;
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
        private IManagerLogger _managerLogger;
        private IUserRegistrator _userRegistrator;
        private ICategoryService _categoryService;
        private IProductsService _productService;
        private AccountsLogic _accountsLogic;
        private readonly ICategoryOperator _categoryOperator;
        private readonly IProductsOperator _productsOperator;
        private readonly IManagerCreator _managerCreator;

        public Application(IUserLogger userLogger, IManagerLogger managerLogger, IUserRegistrator userRegistrator, ICategoryService categoryService, 
            IProductsService productService, AccountsLogic accountsLogic, ICategoryOperator categoryOperator, IProductsOperator productsOperator, IManagerCreator managerCreator)
        {
            _userLogger = userLogger;
            _managerLogger = managerLogger;
            _userRegistrator = userRegistrator;
            _categoryService = categoryService;
            _productService = productService;
            _accountsLogic = accountsLogic;
            _categoryOperator = categoryOperator;
            _productsOperator = productsOperator;
            _managerCreator = managerCreator;
        }

        public void RunApp()
        {
            var initialMenu = new SimpleNavigatorMenu("Initial Menu", null);
            var loginMenu = new SimpleActionMenu("Login Menu", initialMenu);
            var managerLoginMenu = new SimpleActionMenu("Manager Login Menu", initialMenu);
            var registerMenu = new SimpleActionMenu("Register Menu", initialMenu);           
            var mainMenu = new MasterNavigatorMenu("Main Menu", initialMenu);
            var managerMainMenu = new MasterNavigatorMenu("Manager Main Menu", initialMenu);
            var managerCreateManagerMenu = new SimpleActionMenu("Create Manager Menu", managerMainMenu);
            var managerAddCategoryMenu = new SimpleActionMenu("Add Category Menu", managerMainMenu);
            var managerAddProductMenu = new SimpleActionMenu("Add Product Menu", managerMainMenu);
            var accountMenu = new SimpleNavigatorMenu("Account Menu", mainMenu);
            var makeDepositMenu = new SimpleActionMenu("Make Deposit Menu", accountMenu);
            var makeWithdrawalMenu = new SimpleActionMenu("Make Withdrawal Menu", accountMenu);
            var storeCategoriesMenu = new SimpleNavigatorMenu("Store Categories Menu", mainMenu);

            initialMenu.AddChildMenu(loginMenu);
            initialMenu.AddChildMenu(managerLoginMenu);
            initialMenu.AddChildMenu(registerMenu);         

            loginMenu.AddTextBox("Username");
            loginMenu.AddTextBox("Password");
            loginMenu.SetRenavigateMenu(mainMenu);
            loginMenu.Func = new LoginLogic(_userLogger).Login;

            managerLoginMenu.AddTextBox("Username");
            managerLoginMenu.AddTextBox("Password");
            managerLoginMenu.SetRenavigateMenu(managerMainMenu);
            managerLoginMenu.Func = new ManagerLoginLogic(_managerLogger).Login;

            registerMenu.AddTextBox("First Name");
            registerMenu.AddTextBox("Last Name");
            registerMenu.AddTextBox("Username");
            registerMenu.AddTextBox("Password");
            registerMenu.AddTextBox("Confirm Password");
            registerMenu.SetRenavigateMenu(initialMenu);
            registerMenu.Func = new RegistrationLogic(_userRegistrator, new UserModel()).Register;

            mainMenu.AddChildMenu(accountMenu);
            mainMenu.AddChildMenu(storeCategoriesMenu);
            mainMenu.SetReturnOption("0 - Logout");
            mainMenu.ReturnMenuFunc = new LoginLogic(_userLogger).Logout;
            mainMenu.Action = new AccountInfoLogic(_accountsLogic).PrintAccountInfoLogic;

            managerMainMenu.AddTextBlock("Welcome Manager");
            managerMainMenu.AddChildMenu(managerAddCategoryMenu);
            managerMainMenu.AddChildMenu(managerAddProductMenu);
            managerMainMenu.AddChildMenu(managerCreateManagerMenu);

            managerCreateManagerMenu.AddTextBox("Manager username");
            managerCreateManagerMenu.AddTextBox("Manager permission (Super Admin or Admin)");
            managerCreateManagerMenu.Func = new ManagerCreatorLogic(_managerCreator).CreateManager;


            managerAddCategoryMenu.AddTextBox("Category Name");
            managerAddCategoryMenu.Func = new ManagerLogic(_categoryOperator, _productsOperator).InsertCategory;

            managerAddProductMenu.AddTextBox("Name");
            managerAddProductMenu.AddTextBox("Brand");
            managerAddProductMenu.AddTextBox("Category");
            managerAddProductMenu.AddTextBox("Regular Price");
            managerAddProductMenu.AddTextBox("Discounted Price");
            managerAddProductMenu.AddTextBox("Description");
            managerAddProductMenu.Func = new ManagerLogic(_categoryOperator, _productsOperator).InsertProduct;
            //managerAddProductMenu.AddTextBox("Status");
    
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
                SimpleActionMenu productMenu = new SimpleActionMenu($"{category.CategoryName} Menu", storeCategoriesMenu);
                productMenu.Func = new BuyProductLogic(_accountsLogic, category, _productService).BuyProduct;
                storeCategoriesMenu.AddChildMenu(productMenu);  
            }

            initialMenu.Run();
        }
    }
}
