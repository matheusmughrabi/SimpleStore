using SimpleStore.ConsoleUI.Control;
using SimpleStore.ConsoleUI.Factories.MenusFactories;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleStore.ConsoleUI.Factories.MenuFactories
{
    public interface IMenuFactory<T>
    {
        T CreateMenu(RootMenuFactory rootMenuFactory);
    }
}
