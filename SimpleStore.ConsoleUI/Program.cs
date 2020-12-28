using Autofac;
using SimpleStore.Domain.MailService;
using System;

namespace SimpleStore.ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //MailService mailService = new MailService();

            Console.Write("Username: ");
            string usernameTo = Console.ReadLine();

            Console.Write("Send to: ");
            string emailTo = Console.ReadLine();

            Console.Write("Subject: ");
            string subject = Console.ReadLine();

            Console.Write("Body: ");
            string body = Console.ReadLine();

            MailService.SendMail(usernameTo, emailTo, subject, body);
            //mailService.SendMail(usernameTo, emailTo, subject, body);

            IContainer container = new DependencyInjector().CreateContainer();

            using (var scope = container.BeginLifetimeScope())
            {
                var initialMenuRun = scope.Resolve<Application>();
                initialMenuRun.RunApp();
            }
        }
    }
}
