using MailKit.Net.Smtp;
using Microsoft.Extensions.Configuration;
using MimeKit;
using System.IO;

namespace SimpleStore.Domain.MailService
{
    public static class MailService
    {
        private static IConfiguration Configuration;
        private static readonly string _textPart = "plain";

        private static void GetConfigurationSettings()
        {
            var builder = new ConfigurationBuilder()
                        .SetBasePath(Directory.GetCurrentDirectory())
                        .AddJsonFile("appsettings.json");

            Configuration = builder.Build();
        }

        public static void SendMail(string toUsername, string toEmail, string subject, string body)
        {
            GetConfigurationSettings();

            var mailMessage = new MimeMessage();

            mailMessage.From.Add(new MailboxAddress(Configuration["Smtp:Username"], Configuration["Smtp:Email"]));
            mailMessage.To.Add(new MailboxAddress(toUsername, toEmail));
            mailMessage.Subject = subject;
            mailMessage.Body = new TextPart(_textPart)
            {
                Text = body
            };

            using (var smtpClient = new SmtpClient())
            {
                smtpClient.Connect(Configuration["Smtp:Host"], int.Parse(Configuration["Smtp:Port"]));
                smtpClient.Authenticate(Configuration["Smtp:Email"], Configuration["Smtp:Password"]);
                smtpClient.Send(mailMessage);
                smtpClient.Disconnect(true);
            }
        }
    }
}
