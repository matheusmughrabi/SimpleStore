﻿using System;
using System.Collections.Generic;

namespace SimpleStore.ConsoleUI.MenuFramework.Menus
{
    public class MasterNavigatorMenu : BaseMenu
    {
        protected List<BaseMenu> _childMenus = new List<BaseMenu>();

        public Action MenuActionLogic { get; set; }

        public MasterNavigatorMenu(string menuName, BaseMenu root) : base(menuName, root)
        {
        }

        public void AddChildMenu(BaseMenu childMenu)
        {
            _childMenus.Add(childMenu);
        }

        public override void Run()
        {
            base.Run();

            uint userInput = GetValidOptionInput();

            if (userInput == 0)
            {
                if (_root != null)
                {
                    if (ReturnMenuAction != null)
                    {
                        ReturnMenuAction();
                    }
                    _root.Run();
                }
            }
            else
            {
                _childMenus[(int)userInput - 1].Run();
            }
        }

        protected override void PrintMenu()
        {
            Console.Clear();
            Console.WriteLine(_separator);
            PrintMenuHeader();

            if (MenuActionLogic != null)
            {
                MenuActionLogic();
            }

            PrintTextBlocks();
            Console.WriteLine();
            PrintChildMenus();
            Console.WriteLine(_separator);
        }

        private void PrintChildMenus()
        {
            int i = 1;
            foreach (BaseMenu childMenu in _childMenus)
            {
                Console.WriteLine($"{i} - { childMenu.MenuName }");
                i += 1;
            }
            ReturnOption();
        }

        protected virtual uint GetValidOptionInput()
        {
            uint choice = 0;
            var result = uint.TryParse(Console.ReadLine(), out choice);
            while (choice > _childMenus.Count || result == false)
            {
                Console.WriteLine();
                InvalidOptionMessage();
                PrintMenu();
                result = uint.TryParse(Console.ReadLine(), out choice);
            }
            return choice;
        }
    }
}
