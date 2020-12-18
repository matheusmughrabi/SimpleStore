using SimpleStore.ConsoleUI.Control.InitialMenu;
using SimpleStore.ConsoleUI.Factories;
using SimpleStore.Domain.Services.AccountServices;
using SimpleStore.Domain.Services.AuthenticationServices;
using SimpleStore.Domain.UsersAuthenticator.Authenticator.UserLogin;
using SimpleStore.Domain.UsersAuthenticator.Authenticator.UserRegistration;
using SimpleStore.Domain.UsersAuthenticator.Authenticator.UsersRegistration;

namespace SimpleStore.ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            // TODO - Dependency Injection Container
            IAuthenticationService authenticationService = ServicesSimpleFactory.CreateAuthenticationService();
            IAccountsService accountsService = ServicesSimpleFactory.CreateAccountsService();
            IUserLogger userLogger = new UserLogger(authenticationService);
            IUserRegistrator userRegistrator = new UserRegistrator(authenticationService, accountsService);

            InitialMenu initialMenu = new InitialMenu(userLogger, userRegistrator);

            bool isActive = true;
            while (isActive)
            {
                isActive = initialMenu.RunInitialMenu();
            }
        }
    }

}
