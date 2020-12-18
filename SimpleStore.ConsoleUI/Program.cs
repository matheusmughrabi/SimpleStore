using Autofac;
using SimpleStore.ConsoleUI.Control.InitialMenu;

namespace SimpleStore.ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            IContainer container = new DependencyInjector().CreateContainer();

            using (var scope = container.BeginLifetimeScope())
            {
                var initialMenu = scope.Resolve<InitialMenu>();

                bool isActive = true;
                while (isActive)
                {
                    isActive = initialMenu.RunMenu();
                }
            } 
        }
    }
}
