using MailKit.Net.Smtp;
using Microsoft.Extensions.Configuration;
using MimeKit;
using System;
using System.IO;

namespace SimpleStore.Utils.Services
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

        private static bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        public static bool SendMail(string toUsername, string toEmail, string subject, string body)
        {
            bool isValidEmail = IsValidEmail(toEmail);
            if (isValidEmail == false)
            {
                return false;
            }

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
                bool emailSend = true;
                try
                {
                    smtpClient.Connect(Configuration["Smtp:Host"], int.Parse(Configuration["Smtp:Port"]));
                    smtpClient.Authenticate(Configuration["Smtp:Email"], Configuration["Smtp:Password"]);
                    smtpClient.Send(mailMessage);
                }
                catch (Exception)
                {
                    emailSend = false;
                }
                finally
                {
                    smtpClient.Disconnect(true);
                }

                return emailSend;
            }
        }
    }
}
