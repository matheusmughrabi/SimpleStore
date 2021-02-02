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
  0 - Melhorar nomenclatura OK
  1 - Refatorar OK
  2 - Alterar tabela Users para conter Roles OK
  3 - Criar NUnits
  4 - Melhorar ConsoleUI framework (e publicar como Nuget)
  5 - Criar User Interface com Razor Pages
  6 - Criar User Interface com MVC
  7 - Criar Web API
  8 - Utilizar Vue.js
*/
