﻿using System;
using System.Collections.Generic;

namespace SimpleStore.ConsoleUI.MenuFramework.Menus
{
    public abstract class BaseMenu
    {
        protected readonly string _separator = new string('-', 100);
        private string _returnMessage = "0 - Return";

        protected readonly BaseMenu _root;
        protected List<string> _textBlocks = new List<string>();

        public Action ReturnMenuAction { get; set; }
        public Func<bool> AccessAllowedFunc { get; set; }

        public string MenuName { get; }

        public BaseMenu(string menuName, BaseMenu root)
        {
            MenuName = menuName;
            _root = root;
        }

        public virtual void Run()
        {
            bool isAccessAllowed = true;
            if (AccessAllowedFunc != null)
            {
                isAccessAllowed = AccessAllowedFunc();
            }

            if (isAccessAllowed == false)
            {
                Console.WriteLine("Access denied");
                Console.ReadLine();
                _root.Run();
            }

            PrintMenu();
        }

        protected abstract void PrintMenu();

        protected void PrintMenuHeader()
        {
            Console.WriteLine($"This is the { MenuName }");
        }

        protected void PrintTextBlocks()
        {
            foreach (var textblock in _textBlocks)
            {
                Console.WriteLine(textblock);
            }
        }

        public void SetReturnOption(string message)
        {
            _returnMessage = message;
        }

        protected void ReturnOption()
        {
            Console.WriteLine(_returnMessage);
        }

        protected void InvalidOptionMessage()
        {
            Console.WriteLine("Invalid option, press 'Enter' to try again");
            Console.ReadLine();
        }

        public void AddTextBlock(string text)
        {
            _textBlocks.Add(text);
        }

    }
}
