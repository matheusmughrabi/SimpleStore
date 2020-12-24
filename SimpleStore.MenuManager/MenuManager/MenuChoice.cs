using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleStore.MenuManager.MenuFrame
{
    public class MenuChoice
    {
        public string Title { get; private set; }
        public Action Action { get; private set; }

        public MenuChoice(string title, Action action)
        {
            Title = title;
            Action = action;
        }
    }
}
