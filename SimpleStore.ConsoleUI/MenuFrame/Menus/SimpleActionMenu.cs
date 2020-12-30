using System;
using System.Collections.Generic;

namespace SimpleStore.ConsoleUI.MenuFrame
{
    public class SimpleActionMenu : BaseMenu
    {
        private bool _isActionSuccess = false;
        protected BaseMenu _renavigateMenu;
        protected List<string> _textBoxes = new List<string>();
        List<string> textBoxInputs;

        public Func<List<string>, bool> MenuFuncLogic { get; set; }

        public SimpleActionMenu(string menuName, BaseMenu root) : base(menuName, root)
        {
        }

        public override void Run()
        {
            base.Run();

            if (_renavigateMenu == null)
            {
                _root.Run();
            }
            else
            {
                if (_isActionSuccess)
                {
                    _renavigateMenu.Run();
                }
                else
                {
                    _root.Run();
                }
            }
        }

        public void AddTextBox(string text)
        {
            _textBoxes.Add(text);
        }

        public void SetRenavigateMenu(BaseMenu renavigateMenu)
        {
            _renavigateMenu = renavigateMenu;
        }

        protected override void PrintMenu()
        {
            Console.Clear();
            Console.WriteLine(_separator);
            PrintMenuHeader();
            PrintTextBlocks();
            Console.WriteLine();
            PrintTextBoxes();
            if (MenuFuncLogic != null)
            {
                _isActionSuccess = MenuFuncLogic(textBoxInputs);
            }
            Console.WriteLine(_separator);
        }

        private void PrintTextBoxes()
        {
            textBoxInputs = new List<string>();
            foreach (var textBox in _textBoxes)
            {
                Console.Write($"{ textBox }: ");
                GetTextBoxInput();
            }
        }

        private void GetTextBoxInput()
        {
            textBoxInputs.Add(Console.ReadLine());
        }
    }
}
