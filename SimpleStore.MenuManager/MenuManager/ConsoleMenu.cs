using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleStore.MenuManager.MenuFrame
{
    public class ConsoleMenu
    {
        private readonly string Separator = new string('-', 100);
        public readonly string Header;
        protected List<MenuChoice> Choices;
        protected ConsoleMenu Root;

        public ConsoleMenu(string header, List<MenuChoice> choices, ConsoleMenu root)
        {
            Header = header;
            Choices = choices;
            Root = root;
        }

        private void PrintOptions()
        {
            for (int index = 0; index < Choices.Count; index++)
                Console.WriteLine($"Press {index + 1} {Choices[index].Title}");
            Console.WriteLine($"Press 0 to go to previous menu");
        }

        private void PrintHeader()
        {
            Console.WriteLine(Header);
        }

        private void PrintMenu()
        {
            Console.Clear();
            Console.WriteLine(Separator);
            PrintHeader();
            PrintOptions();
            Console.WriteLine(Separator);
        }

        public void RunNextMenu(ConsoleMenu nextMenu)
        {
            nextMenu.Run();
        }

        public void Run()
        {
            PrintMenu();

            uint choice = GetUserChoice();
            if (choice == 0)
                if (Root == null)
                {
                    Console.WriteLine("Goodbye :)");
                    return;
                }
                else
                {
                    Root.Run();
                }
            else
            {
                var action = Choices[(int)choice - 1].Action;
                if (action != null)
                {
                    action();
                }
                else
                {
                    Console.WriteLine("Not implemented yet, press a key to continue.");
                    Console.ReadKey();
                    Run();
                }
            }
        }

        uint GetUserChoice()
        {
            uint choice = 0;
            var result = uint.TryParse(Console.ReadLine(), out choice);
            while (choice > Choices.Count || result == false)
            {
                Console.WriteLine();
                InvalidOptionMessage();
                PrintMenu();
                result = uint.TryParse(Console.ReadLine(), out choice);
            }
            return choice;
        }

        private void InvalidOptionMessage()
        {
            Console.WriteLine("Invalid option, press 'Enter' to try again");
            Console.ReadLine();
        }
    }
}
