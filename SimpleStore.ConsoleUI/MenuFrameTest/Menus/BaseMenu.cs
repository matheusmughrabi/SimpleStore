using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleStore.ConsoleUI.MenuFrameTest
{
    public abstract class BaseMenu
    {
        private readonly string _menuName;
        private readonly BaseMenu _root; 

        public BaseMenu ReloadMenu { get; set; }
        public Action Action { get; set; }

        public BaseMenu(string menuName, BaseMenu root)
        {
            _menuName = menuName;
            _root = root;
        }

        public void Run()
        {
            PrintMenu();
            Action();

            if (ReloadMenu != null)
            {
                ReloadMenu.Run();
            }
            else
            {
                Run();
            }           
        }

        protected abstract void PrintMenu();
    }
}
