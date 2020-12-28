using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleStore.ConsoleUI.MenuFrame.Menus
{
    public class MasterNavigatorMenu : BaseMenu
    {
        protected List<BaseMenu> _childMenus = new List<BaseMenu>();

        public Action Action { get; set; }

        public MasterNavigatorMenu(string menuName, BaseMenu root) : base(menuName, root)
        {
        }

        public void AddChildMenu(BaseMenu childMenu)
        {
            _childMenus.Add(childMenu);
        }

        public override void Run()
        {
            PrintMenu();

            uint userInput = GetValidOptionInput();

            if (userInput == 0)
            {
                if (_root != null)
                {
                    if (ReturnMenuFunc != null)
                    {
                        ReturnMenuFunc();
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

            if (Action != null)
            {
                Action();
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
