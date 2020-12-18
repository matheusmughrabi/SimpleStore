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

        public RootMenuFactory(LoginMenuFactory loginMenuFactory, RegisterMenuFactory registerMenuFactory)
        {
            _loginMenuFactory = loginMenuFactory;
            _registerMenuFactory = registerMenuFactory;
        }

        public BaseMenu CreateMenu(MenuType menuType)
        {
            switch (menuType)
            {
                case MenuType.LoginMenu:
                    return _loginMenuFactory.CreateMenu();
                case MenuType.RegisterMenu:
                    return _registerMenuFactory.CreateMenu();
                default:
                    throw new ArgumentException("The MenuType does not have a Menu.", "menuType");
            }
        }
    }
}
