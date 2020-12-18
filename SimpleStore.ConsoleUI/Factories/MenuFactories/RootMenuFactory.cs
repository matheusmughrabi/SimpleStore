using SimpleStore.ConsoleUI.Control;
using SimpleStore.ConsoleUI.Factories.MenuFactories;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleStore.ConsoleUI.Factories.MenusFactories
{
    public class RootMenuFactory
    {
        private readonly LoginMenuFactory _loginMenuFactory;
        private readonly RegisterMenuFactory _registerMenuFactory;
        private readonly MainMenuFactory _mainMenuFactory;

        public RootMenuFactory(LoginMenuFactory loginMenuFactory, RegisterMenuFactory registerMenuFactory, MainMenuFactory mainMenuFactory)
        {
            _loginMenuFactory = loginMenuFactory;
            _registerMenuFactory = registerMenuFactory;
            _mainMenuFactory = mainMenuFactory;
        }

        public BaseMenu CreateMenu(MenuType menuType)
        {
            switch (menuType)
            {
                case MenuType.LoginMenu:
                    return _loginMenuFactory.CreateMenu(this);
                case MenuType.RegisterMenu:
                    return _registerMenuFactory.CreateMenu(this);
                case MenuType.MainMenu:
                    return _mainMenuFactory.CreateMenu(this);
                default:
                    throw new ArgumentException("The MenuType does not have a Menu.", "menuType");
            }
        }
    }
}
