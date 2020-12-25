using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleStore.ConsoleUI.MenuFrame
{
    public class ActionMenu : BaseMenu
    {
        protected BaseMenu _renavigateMenu;
        protected List<string> _textBoxes = new List<string>();
        List<string> textBoxInputs;

        public Func<List<string>, bool> Func { get; set; }

        public ActionMenu(string menuName, BaseMenu root) : base(menuName, root)
        {
        }

        public override void Run()
        {
            PrintMenu();
            bool success = false;

            if (Func != null)
            {
                success = Func(textBoxInputs);
            }

            if (_renavigateMenu == null)
            {
                _root.Run();
            }
            else
            {
                if (success)
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
