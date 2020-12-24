using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleStore.MenuManager.MenuFrame
{
    public class MenuRunner
    {
        private ConsoleMenu Root;

        public MenuRunner(ConsoleMenu root)
        {
            Root = root;
        }

        public void Run()
        {
            Root.Run();
        }
    }
}
