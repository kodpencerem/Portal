using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Threading.Tasks;

namespace VedasPortal.Entities.Models.ToplantiTakvimi
{
    public class EmailSender : IEmailSender
    {
        public EmailSender(IOptions<AuthMessageSenderOptions> optionsAccessor)
        {
            Options = optionsAccessor.Value;
        }

        public AuthMessageSenderOptions Options { get; }


        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            return Execute(Options.SendGridKey, subject, htmlMessage, email);
        }

        public Task Execute(string key, string subject, string message, string email)
        {
            if (key != null)
            {
                var client = new SendGridClient(key);
                var msg = new SendGridMessage()
                {
                    From = new EmailAddress("mail@vedas.com.tr", Options.SendGridUser),
                    Subject = subject,
                    PlainTextContent = message,
                    HtmlContent = message
                };
                msg.AddTo(new EmailAddress(email));

                msg.SetClickTracking(false, false);

                return client.SendEmailAsync(msg);
            }
            return default;
        }
    }
}
