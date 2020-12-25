using Autofac;

namespace SimpleStore.ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            IContainer container = new DependencyInjector().CreateContainer();

            using (var scope = container.BeginLifetimeScope())
            {
                var initialMenuRun = scope.Resolve<Application>();
                initialMenuRun.RunApp();
            }
        }
    }
}
