using Autofac;

namespace SimpleStore.ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            IContainer container = new Startup().ConfigureServices();

            using (var scope = container.BeginLifetimeScope())
            {
                var initialMenuRun = scope.Resolve<Application>();
                initialMenuRun.RunApp();
            }
        }
    }
}

/*
  0 - Melhorar nomenclatura
  1 - Alterar tabela Users para conter Roles
  2 - Criar NUnits
  3 - Melhorar ConsoleUI framework (e publicar como Nuget)
  4 - Criar User Interface com Razor Pages
  5 - Criar User Interface com MVC
  6 - Criar Web API
  7 - Utilizar Vue.js
*/
