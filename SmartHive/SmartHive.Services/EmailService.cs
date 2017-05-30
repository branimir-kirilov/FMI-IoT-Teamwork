using System.Threading.Tasks;
using System.Net.Mail;
using System.Text;
using System.Diagnostics;
using SmartHive.Services.Contracts;

namespace SmartHive.Services
{
    public class EmailService : IEmailService
    {
        public async Task SendAsync(string sendTo, string subject, string body)
        {
            SmtpClient client = new SmtpClient();
            client.Port = 465;
            client.Host = "smtp.gmail.com";
            client.EnableSsl = true;
            client.Timeout = 10000;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Credentials = new System.Net.NetworkCredential("smarthivebg@gmail.com", "123456smart");
            MailMessage message = new MailMessage("donotreply@domain.com", sendTo, subject, body);
            message.BodyEncoding = UTF8Encoding.UTF8;
            message.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;

            if (client != null)
            {
                await client.SendMailAsync(message);
            }
            else
            {
                Trace.TraceError("Failed to create a connection with smtp.");
                await Task.FromResult(0);
            }
        }
    }
}
